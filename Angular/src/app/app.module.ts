import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { LandingpageComponent } from './landingpage/landingpage.component';
import { BookingpageComponent } from './bookingpage/bookingpage.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DocterdetailsComponent } from './docterdetails/docterdetails.component';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { Docterservice } from './Services/Doctorservice.service';
import { HttpClientModule } from '@angular/common/http';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { DoctorlogpageComponent } from './doctorlogpage/doctorlogpage.component';

@NgModule({
  declarations: [
  AppComponent,
    NavbarComponent,
    FooterComponent,
    LandingpageComponent,
    BookingpageComponent,
    DocterdetailsComponent,
 
    LoginComponent,
    RegisterComponent,
    AdminpageComponent,
    DoctorlogpageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [Docterservice],
  bootstrap: [AppComponent]
})
export class AppModule { }
