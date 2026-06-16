import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Notification } from '../models/emailService.model';

@Injectable({
  providedIn: 'root'
})
export class EmailService {
  constructor(private http:HttpClient) { }
  sendNotification(notification:any){
    return this.http.post<Notification>('https://localhost:7290/api/EmailMessage',notification)
  }
}
