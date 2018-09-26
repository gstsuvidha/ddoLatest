import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { map, filter, tap, catchError } from 'rxjs/operators';



import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';





@Injectable()
export class LoginService {

    private baseUrl = '/api/Auth';
    private token: ITokenResponse;
    profile: IUserProfile;


    constructor(private http: HttpClient,private jwtHelper: JwtHelperService) {

    }

  isAuthenticated(): boolean {

    const token = localStorage.getItem("token");

        return !this.jwtHelper.isTokenExpired(token);
    }

    public getToken(loginModel : ILogin): Observable<ITokenResponse> {

        const url = `${this.baseUrl}/token`;

        return this.http.post<ITokenResponse>(url,loginModel).pipe(
            tap((data) => {
                this.token = data;
                console.log("token", this.token);
                localStorage.setItem("token", this.token.access_token);
                localStorage.setItem('profile', JSON.stringify(this.token.userProfile));
                localStorage.setItem('role',JSON.stringify(this.token.userProfile.role));
                
                      },
            
            err => {
                    if (err.status === 400)
                    alert("Invalid Login Credentials");
                   }

            
        ));
    } 

    
    public getUserProfile(): IUserProfile {

        return this.profile = JSON.parse(localStorage.getItem('profile'));

    }

    public getRole():IUserProfile {
        return this.profile = JSON.parse(localStorage.getItem('role')); 
    }

    private readUserFromLocalStorage() {

        this.profile = JSON.parse(localStorage.getItem('profile'));
    }

    public logOut(): void {
        localStorage.removeItem('token');
        localStorage.removeItem('profile');
            }


}

export interface ITokenResponse {
    access_token: string;
    refresh_token: string;
    userProfile: IUserProfile;
}

export interface IUserProfile {
    sub: string;
    name: string;
    email: string;
    role : string;

}

export interface ILogin{
  userName: string;
  password: string;
  
}