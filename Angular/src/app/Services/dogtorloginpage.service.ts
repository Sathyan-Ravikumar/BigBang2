import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
  })

  export class DocterLoginPageservice{
    
  constructor(private httpClient:HttpClient) {
}

public GetAppoitnmentDetails(del:any):Observable<any>
{
  return this.httpClient.get('https://localhost:7083/api/Appointments/Get_Appointment_Details_For_Particular_Doctor?doctorid='+del)
}

PostDoctor(add:any):Observable<any>{
  return this.httpClient.post('https://localhost:7083/api/DoctorDetails',add);
}
putDoctor(id:any,updatedoc:any):Observable<any>{
    return this.httpClient.put('https://localhost:7083/api/DoctorDetails/doctorname?doctorid='+id,updatedoc);
}
finddocid(name:string):Observable<any>{
  return this.httpClient.get('https://localhost:7083/api/DoctorDetails/doctorname?doctorName='+name);
}
}