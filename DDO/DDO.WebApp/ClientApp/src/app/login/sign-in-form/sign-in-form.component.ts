
import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { Event, NavigationStart,NavigationEnd,NavigationCancel,NavigationError} from '@angular/router';

import { Router, ActivatedRoute } from '@angular/router';
import { LoginService, ILogin } from '../login.service';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.css']
})
export class SignInFormComponent implements OnInit {
  
  constructor(
              private _router: Router,
              private spinnerService: Ng4LoadingSpinnerService,
              private _activatedRoute: ActivatedRoute,
              private loginService : LoginService) { 
              
              }

  ngOnInit() {
    
  }

  login: ILogin;


    doLogin(userName: string, password: string): void {
        this.spinnerService.show();
        var online= navigator.onLine;
        if(!online){
            
        }


        this.login = {
            userName: userName,
            password: password
        };


            this.loginService.getToken(this.login)
                .subscribe(res => {
                    // if (res. === 200)
                        this.onGettingRole();
                },
                ()=>this.spinnerService.hide()
            );
           
            // error => alert("Failed" + error));


    }

   

    onGettingRole() {
       let role = JSON.parse(localStorage.getItem('role'));
       console.log(role);
       if(role == 'Admin'){
           return this._router.navigate(['admin/dashboard']);
       }else if(role == 'User'){
           return this._router.navigate(['authenticated/dash-board']);
       }
    }

}

  


