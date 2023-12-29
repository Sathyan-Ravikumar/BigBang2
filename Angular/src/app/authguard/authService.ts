import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { tap } from 'rxjs';




@Injectable({
  providedIn: 'root'
})
export class AuthService {
 

  constructor(private http: HttpClient,private router : Router) { }
  signIn(Id: string, password: string) {
    const signInData = { Id, password };
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text' as 'json'  // Treat the response as plain text
    };

    return this.http.post<string>('https://localhost:7192/api/User/Login', signInData, httpOptions)
      .pipe(
        tap((jwtToken) => {
          localStorage.setItem('jwtToken', jwtToken);
          // localStorage.setItem('role',role);
        })
      );
  }
  
  

  getToken()
  {
    return localStorage.getItem('token');
  }

  
  logout(){
     localStorage.removeItem("userId");
     localStorage.removeItem("token");
     localStorage.removeItem("role");
     this.router.navigate(['login']);
  }

 


  

}