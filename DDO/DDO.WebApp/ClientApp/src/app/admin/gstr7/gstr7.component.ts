import { Component, OnInit } from '@angular/core';
import { MonthList } from '../../month-list';
import { StateList } from '../../state-list';
import { ActivatedRoute } from '@angular/router';
import { UserProfileService } from '../../user-profile/userprofile.service';
import { Gstr7Service } from '../gstr7.service';

@Component({
  selector: 'app-gstr7',
  templateUrl: './gstr7.component.html',
  styleUrls: ['./gstr7.component.css']
})
export class Gstr7Component implements OnInit {
  currentYear = new Date();
  displayYear: string;
  monthId: number;
  monthList = MonthList;
  gstr7;
  gstr7Details;
  yearId : number;
  
  accountingUnit : number;

  stateList = StateList

  constructor(private route : ActivatedRoute,
    private userProfileService : UserProfileService,
    private gstr7service: Gstr7Service) { }

  ngOnInit()
  {
    this.displayYear = this.userProfileService.getYearDisplaySettings();
    this.route.params.subscribe(params => {

    this.monthId = params['monthId'];
    this.yearId = params['yearId'];
    this.accountingUnit = params['accountingUnitId']

    this.gstr7service.getGstr7Details(this.accountingUnit).subscribe(response => {
      this.gstr7Details = response;
    
    });

       this.gstr7service.getSingle(this.monthId,this.yearId,this.accountingUnit).subscribe(response => {
         this.gstr7 = response;
         console.log(response);
        });

         });
        
        }

  getPlaceOfSupply(id:string):string{
    return this.stateList.find(s => s.value == id).label
}

getMonthName(monthId: number): string {
  return this.monthList.find(m => m.value == monthId).label
}


}
