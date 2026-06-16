import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

import { EntrepreneurProfile } from '../models/entrepreneur-profile';

@Injectable({
  providedIn: 'root'
})
export class EntlistService {

  constructor(private httpClient: HttpClient) { }
  getAll():Observable<Array<EntrepreneurProfile>>{
  return this.httpClient.get<Array<EntrepreneurProfile>>('https://localhost:7054/api/GetAllUser')
}}
