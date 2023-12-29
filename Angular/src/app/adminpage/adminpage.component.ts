import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserDTOModel } from '../Models/userDTO.model';
import { DocModel } from '../Models/Doc.model';
import { Docterservice } from '../Services/Doctorservice.service';
import { AppointmentService } from '../Services/Appoinment.service';

@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.css']
})
export class AdminpageComponent {
  intern:DocModel;
  userdto:UserDTOModel;
  public doctor:any;
  public newstaff:any;
  public deleteStaff:any;
  public remove:any;
public applist:any;
  constructor(private userInternService:Docterservice,//Injections
              private router:Router,private api:AppointmentService
              )
  {
    this.intern = new DocModel();
    this.userdto=new UserDTOModel();
  }

  sendRequest()
  {
    
      if(this.doctor){
        this.doctor=null;
      }
      else{
        this.userInternService.getdoctor().subscribe(data=>
          {
            this.doctor=data;  
              console.log(this.userdto);
          });
      }
  }

  viewappointment(){
    if (this.applist) {
      this.applist = null; // Clear the applist variable if it's already populated
    } else {
      this.api.getallAppointmentDetails().subscribe(data => {
        this.applist = data;
      });
    }
}

  addRow(obj:any)
  {
    this.newstaff=obj;
    this.userInternService.userRegister(this.newstaff).subscribe(data=>
    {
      this.userdto = data as UserDTOModel;//copying the returned data into userdto object
      localStorage.setItem("token",this.userdto.token);//set token into localStorage
      localStorage.setItem("this.internID",(this.userdto.userName).toString());//set ID into localStorage
      alert('Registration Successful');
      this.sendRequest();
    });

  }
  deleteRow(obj:any)
  {
    this.deleteStaff=obj;
    this.userInternService.deletedoctorInList(this.deleteStaff).subscribe(data=>
      {
              this.remove=data;
              this.sendRequest();

      });
  }
}
