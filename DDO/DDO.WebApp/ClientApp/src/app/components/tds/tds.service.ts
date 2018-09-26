import { Injectable } from '@angular/core';

import { Itds } from './Itds';
import { HttpClient } from '@angular/common/http';
import { ServiceBase } from '../../service-base';

@Injectable()
export class TdsService extends ServiceBase<Itds>{
  intializeObject(): Itds {

      return{
        id: 0,
        supplierId: 0,
        date:new Date(),
        placeOfSupply: "",
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

   
}



