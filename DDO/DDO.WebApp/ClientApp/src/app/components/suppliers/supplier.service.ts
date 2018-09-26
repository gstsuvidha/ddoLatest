import { Injectable } from "@angular/core";
import { ServiceBase } from "../../service-base";
import { ISupplier, RegistrationType } from "./isupplier";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class SupplierService extends ServiceBase<ISupplier>{
  
  supplier:ISupplier[];

  constructor(private http:HttpClient) { 
    super(http, 'api/Suppliers')
  }


//   initializeObject():ISupplier{
//     return{
//       id: 0,
//       supplierOpeningDate: new Date(),
//       name: "",
//       gstin: "",
//       address: "",
//       state: "",
//       contactNumber: "",
//       registrationType: RegistrationType.Registered,
//       openBalance: 0,
//       email : ""
//     }
// }

intializeObject(): ISupplier {
  return{

        id: 0,
        supplierOpeningDate: new Date(),
        name: "",
        gstin: "",
        address: "",
        state: "",
        contactNumber: "",
        registrationType: RegistrationType.Registered,
        openBalance: 0,
        email : ""
      }
  }
  
    

getRegisteredSuppliers():Observable<ISupplier[]>{
  return this.http.get<ISupplier[]>(`${this.baseUrl}/RegisteredSuppliers`)
}
}