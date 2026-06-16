import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';
import { Inv } from '../models/updateinvestor.model';
@Injectable({
  providedIn: 'root'
})
export class InvestorlistService {

  constructor(private httpClient: HttpClient) { }
  getAll():Observable<Array<Inv>>{
    return this.httpClient.get<Array<Inv>>('https://localhost:7295/api/User/GetAll')
  }
}
