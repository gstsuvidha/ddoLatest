import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/components/common/menuitem';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  items: MenuItem[];

  constructor() { }

  ngOnInit() {
    this.items = [
      {
          label: 'Master',expanded : true,
          
          items: [
                  
                  {label: 'Supplier', routerLink:['/authenticated/supplier']},
                           ]
      },
     
      


      {
        label: 'TDS',  expanded : true,
         
         items: [
                 {label: 'TDS', routerLink:['/authenticated/tds']},
                 // {label: 'Receipt Note'},
                 // {label: 'Advanced Paid'}
         ]
     },

      
     
    ];
  
}
}