import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PrimeNgModule } from './prime-ng/prime-ng.module';
import { SupplierService } from './components/suppliers/supplier.service';
import { TdsService } from './components/tds/tds.service';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticatedUserComponent } from './authenticated-user/authenticated-user.component';
import { SupplierFormComponent } from './components/suppliers/supplier-form/supplier-form.component';
import { SupplierListComponent } from './components/suppliers/supplier-list/supplier-list.component';
import { TdsListComponent } from './components/tds/tds-list/tds-list.component';
import { TdsFormComponent } from './components/tds/tds-form/tds-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TopMenuComponent } from './top-menu/top-menu.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import {  HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserProfileService } from './user-profile/userprofile.service';
import { UserProfileComponent } from './user-profile/user-profile/user-profile.component';
import { JwtModule } from '@auth0/angular-jwt';
import { SignInFormComponent } from './login/sign-in-form/sign-in-form.component';
import { LoginService } from './login/login.service';
import { AuthGuardService } from './guard/auth-guard.service';
import { TokenInterceptor } from './login/token-interceptor';
import { Gstr7Service } from './admin/gstr7.service';
import { AdminModule } from './admin/admin.module';
import { TdsPrintComponent } from './components/tds/tds-print/tds-print.component';

export function tokenGetter() {
  return localStorage.getItem("token");
}



@NgModule({
  declarations: [
    AppComponent,
    TdsFormComponent, 
    TdsListComponent,
    SupplierFormComponent,
    SupplierListComponent,
    AuthenticatedUserComponent,
    UserProfileComponent,
    DashboardComponent,
    TopMenuComponent,
    SidebarComponent,
    DashboardComponent,
    SignInFormComponent,
    TdsPrintComponent,

  ],


  imports: [
    BrowserModule,
    PrimeNgModule,
    FormsModule,
    HttpClientModule,
    AdminModule,
    ReactiveFormsModule,

    
    
    RouterModule.forRoot([
      { path: 'authenticated',
        component : AuthenticatedUserComponent,

        canActivate: [AuthGuardService],
        data : {
          permission: {
            only: ["User"],
            redirectTo: 'login'
        }
        },
    

        children : [
          
      {path: 'supplier/:id', component: SupplierFormComponent},
      {path: 'supplier', component: SupplierListComponent},
      {path: 'tds', component: TdsListComponent },
      {path: 'tds/:id', component: TdsFormComponent },
      {path: 'tds-print/:id', component: TdsPrintComponent },
      {path: 'dash-board', component: DashboardComponent },
      { path: 'user-profile/detail', component: UserProfileComponent},
       ]
      
      
      },
        {path : 'login', component : SignInFormComponent},
        { path: '', redirectTo: 'authenticated/dash-board', pathMatch: 'full' },
      { path: '**', redirectTo: 'authenticated/dash-board' }
      
    
    ]),

       JwtModule.forRoot({
       config: {

        headerName: 'Authorization',
        authScheme: 'Bearer ',
        tokenGetter: tokenGetter,

      }
    })

  ],
  
  
  providers: [SupplierService,
              TdsService,
            UserProfileService,
            LoginService,
          AuthGuardService, 
          Gstr7Service,
          {
            provide: HTTP_INTERCEPTORS,
            useClass: TokenInterceptor,
            multi: true
          }],
  
  bootstrap: [AppComponent]
})

export class AppModule { }
