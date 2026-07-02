import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EntDataService {
  url = "https://localhost:7295/api/User"

  constructor(
    private http:HttpClient
  ) { }
  getOne(id:string): Observable<any> {
     return this.http.get('https://localhost:7054/api/GetUserById?id='+id);
  }
}
