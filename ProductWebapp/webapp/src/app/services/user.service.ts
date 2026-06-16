import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { loginUser } from '../models/loginUser.model';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl='https://localhost:7035/api/UserAuthentication'

  constructor(private http:HttpClient) { }

  //register method
  addUser(user:User):Observable<User>{
    return this.http.post<User>('https://localhost:7035/api/UserAuthentication/Register',user)
  }

  //loginmethod
  loginUser(user:loginUser):Observable<loginUser>{
    return this.http.post<loginUser>('https://localhost:7035/api/UserAuthentication/login',user)
  }
}
