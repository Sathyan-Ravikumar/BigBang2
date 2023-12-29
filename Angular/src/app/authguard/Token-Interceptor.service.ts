import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './authService';


@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor(private injector:Injector) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let auth=this.injector.get(AuthService);
    let tokenizedReq=req.clone({
      setHeaders:{
        Authorization: `Bearer ${auth
          .getToken()}`      }
    });
    return next.handle(tokenizedReq);
  }
}