import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { loginUser } from 'src/app/models/loginUser.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user:loginUser={
    email:'',
    password:'',
    token:'',
    role:''
  }

  constructor(private userService:UserService,
    private _activateRoute:ActivatedRoute,
             private _router:Router){

  }

  ngOnInit(): void {
  }

 

  /*loginSubmit(){
    console.log(this.loginForm.value);
    this.loginForm.reset();
  }*/

  loginSubmit(){
    this.userService.loginUser(this.user)
    .subscribe(
      res=>{
        localStorage.setItem('email',res.email)
        console.log(res)
        localStorage.setItem('token',res.token)

        if(res.role=='Investor'){
          this._router.navigate(['/InvestorNavbar/ProductList'])
         }
         else{
          this._router.navigate(['/EntrepreneurNavbar/HappyCustomers'])
         }
        
        
        
        
      }
    )  
  }

}
