import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { UserProfileService } from '../../user-profile/userprofile.service';
import { Iuserprofile } from '../../user-profile/iuserprofile';
import { Month } from '../../month-list';
import { UserSetting } from '../../user-setting';


@Component({
  selector: 'app-admin-userwise-report-dashboard',
  templateUrl: './admin-userwise-report-dashboard.component.html',
  styleUrls: ['./admin-userwise-report-dashboard.component.css']
})
export class AdminUserwiseReportDashboardComponent implements OnInit {

 id :number;
 userProfile;
  
  usersSelectList : SelectItem[];
  userName;
  month = Month;
  selectedMonth: number;
  financialYear : number;
  financialYearList : SelectItem[];

  constructor(private userProfileService: UserProfileService,
    private _router : Router) { }

  ngOnInit() {
    this. userProfileService.getAccountingUnits().subscribe(response=> {
      this.userProfile = response;
      this.usersSelectList = this.userProfile.map(us =>({
        label : us.businessName,
        value : us.id
      }))
    
      
    
    })

    this.financialYearList = [
      {label : "2018-19",value : 2018},
      {label : "2019-20",value : 2019},
      {label : "2020-21",value : 2020},
      {label : "2021-22",value : 2021},
      {label : "2022-23",value : 2022}
    ]
   

    
    this.financialYear = 2018;
    this.getReportingForSelectedMonth(UserSetting.getReportingMonth());
  }

  
  gstr7(){
    this._router.navigate(['admin/Gstr7',this.month,this.financialYear,this.userName]);
  }
  adminUserMarketingCompanyReporting(){
    this._router.navigate(['admin/user_profile_marketing_reporting',this.userName]);
  }

  getReportingForSelectedMonth(monthId : number){
    UserSetting.setReportingMonth(monthId);
    this.selectedMonth = monthId;
 }

 

}
