import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  } from '@angular/common/http';


import { ILogin } from './login.service';
import { Observable } from 'rxjs';



@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    login : ILogin;
    constructor() {} 

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

      const token = localStorage.getItem("token");
      
      const authReq = request.clone({ setHeaders: { Authorization: "Bearer " + token } });
  
          return next.handle(authReq);
        
    }
}

