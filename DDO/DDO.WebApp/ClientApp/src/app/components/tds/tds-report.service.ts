import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class TdsReportService {
  baseUrl = 'api/TdsReport'

  constructor(private http : HttpClient) { }

  getTotalTdsSummary(){
    return this.http.get(this.baseUrl);
  }

}
