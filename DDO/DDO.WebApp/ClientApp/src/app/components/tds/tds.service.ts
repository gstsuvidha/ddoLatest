import { Injectable } from '@angular/core';

import { Itds } from './Itds';
import { HttpClient } from '@angular/common/http';
import { ServiceBase } from '../../service-base';
import { Observable } from 'rxjs';

@Injectable()
export class TdsService extends ServiceBase<Itds>{
  intializeObject(): Itds {

      return{
        id: 0,
        supplierId: 0,
        date:new Date(),
        placeOfSupply: "",
        reference: "",
        amountPaid:0,
        cgstAmount: 0,
        sgstAmount: 0,
        igstAmount: 0,
        tdsAmount: 0,
        netAmount: 0,
       }
    
  }
  tds:Itds[];

  constructor(private http:HttpClient) {
    super(http, 'api/Tds')
   }

   
   getAllByMonth(monthId:number,year:number):Observable<Itds[]>{
       
          

    if(monthId == 1 || monthId ==2 || monthId == 3) //fINANCIAL YEAR CONVERSION
     year++;  
    
    
    return this.http.get<Itds[]>(`${this.baseUrl}?searchMonth=${monthId}&year=${year}`);
  
  }
  
  }
  
  
  


