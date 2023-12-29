import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Injectable({
    providedIn: 'root'
  })


  export class AppointmentService{
    
  constructor(private http:HttpClient) {}

   public getallAppointmentDetails(){
    return this.http.get('https://localhost:7083/api/Appointments');
   }

  }