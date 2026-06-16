import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Inv } from '../models/updateinvestor.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvestorDataServiceService {
    url = "https://localhost:7295/api/User"
    // url =  'https://localhost:7295/api/User/GetById'
  constructor(private http: HttpClient) { }
  // users() {
  //   return this.http.get(this.url)
  // }
  getOne(id:string): Observable<any> {
    return this.http.get('https://localhost:7295/api/User/GetById?id='+id);
  }


  
}
