import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { BookingpageComponent } from './bookingpage/bookingpage.component';
import { LoginComponent } from './login/login.component';
import { LandingpageComponent } from './landingpage/landingpage.component';
import { DocterdetailsComponent } from './docterdetails/docterdetails.component';
import { RegisterComponent } from './register/register.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { DoctorlogpageComponent } from './doctorlogpage/doctorlogpage.component';
import { AuthGuard } from './authguard/authGuard';

const routes: Routes = [
  {path:'head',component:NavbarComponent},
  {path:'book',component:BookingpageComponent},
{path:'login',component:LoginComponent},
{path:'Register',component:RegisterComponent},
  {path:'home',component:LandingpageComponent},
  {path:'DocDe',component:DocterdetailsComponent},
  {path:'Register/login',component:LoginComponent},
  {path:'login/Register',component:RegisterComponent},
  {path:'adminpage',component:AdminpageComponent, canActivate: [AuthGuard], data:{roles:['admin']}},
  {path:'docpage',component:DoctorlogpageComponent, canActivate:[AuthGuard], data:{roles:['doctor']}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
