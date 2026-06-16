import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EntrepreneurProfile } from 'src/app/models/entrepreneur-profile'

@Injectable({
  providedIn: 'root'
})
export class EntrepreneurProfileService {

  constructor(private http:HttpClient) { }
  addUpateprofileen(entrepreneur:any){

    return this.http.post<EntrepreneurProfile>('https://localhost:7054/api/User/Create',entrepreneur)
}
}