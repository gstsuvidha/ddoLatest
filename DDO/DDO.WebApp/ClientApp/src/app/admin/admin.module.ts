import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticatedComponent } from './authenticated/authenticated.component';
import { AdminTopMenuComponent } from './admin-top-menu/admin-top-menu.component';
import { AdminUserwiseReportDashboardComponent } from './admin-userwise-report-dashboard/admin-userwise-report-dashboard.component';
import { Gstr7Component } from './gstr7/gstr7.component';
import { Gstr7ConsolidatedComponent } from './gstr7-consolidated/gstr7-consolidated.component';
import { PrimeNgModule } from '../prime-ng/prime-ng.module';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from '../guard/auth-guard.service';
import { UserProfileComponent } from '../user-profile/user-profile/user-profile.component';

const appRoutes: Routes = [
  {path: 'admin',
    component : AuthenticatedComponent,
    canActivate: [AuthGuardService],
    data : {
      permission: {
        only: ["Admin"],
        redirectTo: 'login'
    }
    },
   
  children :[
    { path: 'dashboard', component: AdminUserwiseReportDashboardComponent},
    { path: 'Gstr7/:monthId/:yearId/:accountingUnitId', component: Gstr7Component},
    { path: 'Gstr7/Consolidated/:monthId/:yearId/:accountingUnitId', component: Gstr7ConsolidatedComponent},
    { path: 'user-profile/detail', component: UserProfileComponent},
    
     
  ]}
  
];
@NgModule({
  imports: [
    CommonModule,
    PrimeNgModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)

  ],
  declarations: [AuthenticatedComponent, AdminTopMenuComponent, AdminUserwiseReportDashboardComponent,
  Gstr7Component, Gstr7ConsolidatedComponent]
})
export class AdminModule { }
