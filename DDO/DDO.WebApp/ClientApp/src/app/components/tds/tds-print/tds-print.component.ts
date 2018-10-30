import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TdsService } from '../tds.service';
import { SupplierService } from '../../suppliers/supplier.service';
import { UserProfileService } from '../../../user-profile/userprofile.service';

@Component({
  selector: 'app-tds-print',
  templateUrl: './tds-print.component.html',
  styleUrls: ['./tds-print.component.css']
})
export class TdsPrintComponent implements OnInit {
  id: number;
  tds;
  supplier;
 userProfile;
  constructor(private route: ActivatedRoute,
    private _router : Router, private tdsService:TdsService ,
  private supplierService:SupplierService,
private userProfileService:UserProfileService) { }

  ngOnInit() {

    this.userProfileService.getProfile().subscribe(resp=>this.userProfile=resp);

    this.route.params.subscribe(params => 
      {this.id = params['id'];
            this.getPrint(this.id);
       
    })
  } 
  tdsList(){
this._router.navigate(['authenticated/tds']);
   
  }

  getPrint(id: number)
  {
      this.tdsService.getOne(id).subscribe(resp=>this.tds=resp);
      this.supplierService.getOne(id).subscribe(resp=>this.supplier=resp);
      
  }
  print(): void {
    let printContents, popupWin;
    printContents = document.getElementById('print-section').innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          
          <style type="text/css" media="print">
          .container{
            height:620px !important;
            width:820px !important;
           
            }
            div.container {
                font: normal 16px Arial,Bell Mt !important;
                background: white;
                padding: 20px;
                
            }
           
            textarea { border: 0 !important;
              font-size: 16px !important;
              font-family: Helvetica, Sans-Serif;
              text-decoration: uppercase;
               overflow: hidden !important;
                resize: none !important; 
               }
            .headerDown{
                text-align: center;
            }
            .hup{
                 height: 25px !important; 
                 width: 100% !important; 
                 margin: 20px 0 !important; 
                 background:#fff !important;
                 text-align: center  !important; 
                 color: black !important; 
                 font-weight:600;
                 font: bold 15px !important;
                 font-family: Helvetica, Sans-Serif !important;
                  text-decoration: uppercase !important;
                  letter-spacing:20px;
                   padding: 8px 0px;
            
            }.hdown1
            {
                font-size: 25px !important ;
                font-weight:600 !important;
                color :#234782;
                text-align: center;
            }
            .hdown2
            {
                font-size:20px !important ;
                color:black !important ;;
                font-family:Arial Round Mt;
                width:380px !important ;;
                text-align: center !important ;;
            }
            .invoice-title h2, .invoice-title h3 {
                display: inline-block;
            }
            
            .table > tbody > tr > .no-line {
                border-top: none;
            }
            
            .table > thead > tr > .no-line {
                border-bottom: none;
            }
            
            .table > tbody > tr > .thick-line {
                border-top: 2px solid;
            }
            table { border-collapse: collapse; 
              margin-top:12px;
              min-width:750px;
            min-height:40px;}

            table td, table th {
                 border: 2px solid black;
                  padding: 5px; 
                  padding-left:3px;
                  font-size: bold 12px;
                }
            button{
                margin-left:380px !important;
            }
          

 

 
.text-left{
  margin-top:5px;
  text-align:left !important;
  }
  .text-right{
    
  text-align:right !important;
  }
  .panel-default {
    border-color: #ddd;
}
.panel {
  margin-top:30px
  margin-bottom: 20px;
  background-color: #fff;
  border: 0px solid transparent;
  border-radius: 4px;
  box-shadow: 0 1px 1px rgba(0,0,0,.05);
  margin-left:60px;
}
.panel-title {
  margin-top: 50px;
  margin-bottom: 0;
  font-size: 18px !important;
  color: inherit;
  text-align: center;
}
div {
  display:block;
}
.sp{
  display:inline-block;
  padding-right:4px;
}
.lefthead{
  font-style: normal;
  font-family:Arial, Helvetica, Sans-Serif;
  margin-top:50px;
  text-align:left;
}
.righthead{
  font-style: normal;
  font-family:Arial, Helvetica, Sans-Serif;
  margin-top:-30px;
  
  text-align:right;
}

panel-body {
  padding: 15px;
}
body {
  font-style: normal !important;
  padding-top: 32px;
  font-size: 13px;
  font-family: Helvetica, Sans-Serif;
  text-decoration: uppercase;
  line-height: 1.42857143;
  color: #333;
  background-color: #fff;
}
 
.btn {
  display: inline-block;
  padding: 6px 12px;
  margin-top:10px;
  margin-bottom: 5px;
  font-size: 14px;
  font-weight: 400;
  line-height: 1.42857143;
  text-align: center;
  white-space: nowrap;
  vertical-align: middle;
  touch-action: manipulation;}
  .pdate{
   
    margin-right:49px;
  }
  .psup{
    margin-right:14px;
  }
  #printbutton{
    display:none;
  }
  .ref{
    margin-top:20px;
  }
  .authorised{
    padding-right:30px;
 margin-right:80px;
 margin-top:10px;
  }
  .textpower{
           
    margin-top: 2vh;
    float: right !important;
    font-weight: 600;
    font-size: 13px;
    opacity: .70;
  
    }
          </style>
        </head>
    <body onload="window.print();window.close()">${printContents}</body>
      </html>`
    );
    popupWin.document.close();
}
}
