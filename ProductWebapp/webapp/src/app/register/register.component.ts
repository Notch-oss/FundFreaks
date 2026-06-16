import { formatCurrency } from '@angular/common';
import { ConditionalExpr } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { resetFakeAsyncZone } from '@angular/core/testing';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  user:User={
    email:'',
    password:'',
    confirmPassword:'',
    role:'',
    token:''
   
  }

  constructor(private userService:UserService,
             private _activateRoute:ActivatedRoute,
             private _router:Router) {}

  ngOnInit(): void {
    
  }  
  //to check if entry is coming to console
  // registerSubmit(){
  //   console.log(this.user)
  // }

  //to add in db
  /*registerSubmit(){
    this.userService.addUser(this.user)
    .subscribe(
      res=>{let str=String(res);
        if(str='User Added Successfully'){
          this.routerService.routeToTrial();
        }
        else{
          this.routerService.routeToLogin();
        }
      }
      
    );*/

  //to reset form and add in db
  registerSubmit(){
    
    this.userService.addUser(this.user)

   .subscribe(
       res=>{
        localStorage.setItem('email',res.email)
        //  console.log(res)
         localStorage.setItem('token',res.token)
        localStorage.setItem('role',this.user.role)
        console.log(res)

        let temp=res.role;
         if(this.user.role=='Investor'){
          this._router.navigate(['/Login'])
         }
         else{
          this._router.navigate(['/Login'])

        
         
         //this._router.navigate(['/InvestorNavbar/HappyCustomer'])
         
       }
      }
     )
     }}
    

