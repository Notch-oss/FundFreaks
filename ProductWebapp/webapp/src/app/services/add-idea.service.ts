import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/models/product';
import { EntrepreneurProfile } from '../models/entrepreneur-profile';

@Injectable({
  providedIn: 'root'
})
export class AddIdeaService {
  email: string | null;


  constructor(private http:HttpClient) { }
  addIdea(product:any){
    return this.http.post<Product>("https://localhost:7054/api/Product/Create",product);
  }

  getemail(){
    this.email=localStorage.getItem('email');
    return this.email;
  }
  getByEmail(): Observable<EntrepreneurProfile>  {
    this.email=localStorage.getItem('email');
    return this.http.get<EntrepreneurProfile>("https://localhost:7054/api/GetUserByEmail?email="+this.email);
  }

}
