import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { UserDTOModel } from '../Models/userDTO.model';
import { DocModel } from '../Models/Doc.model';
@Injectable({
    providedIn: 'root'
  })

  export class Docterservice{
    
  constructor(private httpClient:HttpClient) {
}

userlogin(user:UserDTOModel){
 return this.httpClient.post("https://localhost:7083/api/Users/LogIN/login",user);
}

userRegister(intern:DocModel){
 return this.httpClient.post("https://localhost:7083/api/Users/Register",intern);
}

doctorRegister(intern:DocModel):Observable<any>
{
 return this.httpClient.post("https://localhost:7083/api/Users/doctorRegister/doctor",intern);

}
getdoctor():Observable<any>
{
 return this.httpClient.get("https://localhost:7083/api/Users/View_All_doctorRequest");

}

deletedoctorInList(intern:DocModel):Observable<any>
{
 return this.httpClient.post("https://localhost:7083/api/Users/deletedoctorinlist/deleteDoctorinlist",intern);
}
  }