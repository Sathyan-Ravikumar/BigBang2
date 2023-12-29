import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserDTOModel } from '../Models/userDTO.model';
import { DocModel } from '../Models/Doc.model';
import { Docterservice } from '../Services/Doctorservice.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  intern: DocModel;
  userdto: UserDTOModel;
  response: DocModel;
  result: any;


  constructor(private userInternService: Docterservice,//Injections
    private router: Router
  ) {
    this.intern = new DocModel();
    this.userdto = new UserDTOModel();
    this.response = new DocModel();
  }



  addIntern() {
    if (this.intern.role === "doctor") {
      console.log(this.intern)
      this.userInternService.doctorRegister(this.intern).subscribe(
        (data) => {
          // Success response
          
          this.response = data;
          this.response = data;
          if (data && data.name !== "") {
            this.result = "wait for admin approval";
            alert('Request Sent Successful');
          } else {
            this.result = "change the user name";
            alert('Error in Resuest Sent');
          }
        },
        (error) => {
          // Error response
          console.log(error); // Log the error for debugging purposes
          // Handle the error or display an error message to the user
        }
      );
    }
    if (this.intern.role === "user") {
      this.userInternService.userRegister(this.intern).subscribe(data =>//Entered details inserted into database
      {
        this.userdto = data as UserDTOModel;//copying the returned data into userdto object
        localStorage.setItem("token", this.userdto.token);//set token into localStorage
        localStorage.setItem("this.internID", (this.userdto.userName).toString());//set ID into localStorage
        if (this.userdto.role == "user")//If user is intern navigate to intern restricted page
        {
          this.router.navigate(['login']);
        }
        else if (this.userdto.role == "Admin")//If user is Admin navigate to intern restricted page
        {
          this.router.navigate(['admin']);
        }

        console.log(this.userdto);
      },

        err => {
          console.log(err)
        });

    }


  }


}
