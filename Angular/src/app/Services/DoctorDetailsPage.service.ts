import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Injectable({
    providedIn: 'root'
  })


  export class DoctorDetailsService{
    
  constructor(private http:HttpClient) {}

   public getallDoctorDetails(){
    return this.http.get('https://localhost:7083/api/DoctorDetails');
   }

  }