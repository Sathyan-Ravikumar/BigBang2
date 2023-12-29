import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDTOModel } from '../Models/userDTO.model';
import { Docterservice } from '../Services/Doctorservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{
  
  user:UserDTOModel;
  toggle:boolean;
  constructor(private userInterService:Docterservice,
              private router:Router)
  {
    this.user=new UserDTOModel();
    
    this.toggle=false;
  }

  addUser()
  {
    this.userInterService.userlogin(this.user).subscribe(data=>
    {
      this.user=data as UserDTOModel;
      localStorage.setItem("token",this.user.token);
      localStorage.setItem("userid",(this.user.userid).toString());
      localStorage.setItem("this.internID",(this.user.userName).toString());
      localStorage.setItem("role",this.user.role);
      console.log(this.user);

  
      if(this.user.role=="user")
      {
        
        this.router.navigate(['home']).then(() => {
          // Optional: Scroll to the top of the page
          window.scrollTo(0, 0);
          location.reload();
        });
  
      }
      
      else if(this.user.role=="admin")
      {
        
        this.router.navigate(['adminpage']).then(() => {
          // Optional: Scroll to the top of the page
          window.scrollTo(0, 0);
          location.reload();
        });
     
      }
      else if(this.user.role=="doctor")
      {
        
        this.router.navigate(['docpage']).then(() => {
          // Optional: Scroll to the top of the page
          window.scrollTo(0, 0);
          location.reload();
        });
  
      }
      
      else{
        this.toggle=!this.toggle;
        
      }
    },
    err=>{
      console.log(err);
    });
    
  }

  register()
  {
    this.router.navigate(['register']);
  }

  
}
