import { Component, OnInit, ElementRef } from '@angular/core';
import { IUserProfile, LoginService } from '../../login/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-top-menu',
  templateUrl: './admin-top-menu.component.html',
  styleUrls: ['./admin-top-menu.component.css']
})
export class AdminTopMenuComponent implements OnInit {

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