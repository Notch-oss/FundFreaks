import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class HappyCustomerService {

  baseUrl=''
  constructor(private http:HttpClient) { }

  

  
}
