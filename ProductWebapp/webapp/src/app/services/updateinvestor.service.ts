import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inv } from '../models/updateinvestor.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UpdateinvestorService {
  baseUrl='https://localhost:7295/api/User';

  constructor(private http:HttpClient) { }
  addUpdateprofileinv(inv:any){
return this.http.post<Inv>('https://localhost:7295/api/User/Create',inv)
  }
}


