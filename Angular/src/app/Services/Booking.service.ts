import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Injectable({
    providedIn: 'root'
  })


  export class BookingServices{
    
  constructor(private http:HttpClient) {}

   public posttheDetails(book:any){
    return this.http.post('https://localhost:7083/api/Appointments',book);
   }

  }