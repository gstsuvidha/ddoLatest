import { Component, OnInit, ElementRef } from '@angular/core';
import { Router } from "@angular/router";
import { IUserProfile, LoginService } from '../login/login.service';

// import { LoginService, IUserProfile } from '../login/login.service';


@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',
  host: {
    '(document:click)': 'handleClick($event)',
},
  styleUrls: ['./top-menu.component.css']
})
export class TopMenuComponent implements OnInit {
  
  userProfile: IUserProfile =this.loginService.getUserProfile();
  toggleMenu:boolean=false;


  constructor(private router : Router,
              private loginService : LoginService,
              private elementRef: ElementRef) { }

  ngOnInit() {
  }
  
  handleClick(event){
    if (!this.elementRef.nativeElement.contains(event.target)) {
        this.toggleLogin =false;
      this.toggleMenu=false;
    }
}
 
  toggleLogin:boolean=false;
  onToggleLogin():void{
    
    this.toggleLogin = !this.toggleLogin;     
  }

  logOut(): void {        
    localStorage.removeItem('token');
    localStorage.removeItem('profile');
    localStorage.removeItem('role');      
    this.router.navigate(['/login']);
}

}
