import { Component, OnInit } from '@angular/core';

import { HappyCustomerService } from 'src/app/services/happy-customer.service';

@Component({
  selector: 'app-happy-customer',
  templateUrl: './happy-customer.component.html',
  styleUrls: ['./happy-customer.component.css']
})
export class HappyCustomerComponent implements OnInit {
  temp:any;
  name:any;
  // user:happyCustomer={
  //   username:''
  // }
  constructor(private happycustomerService:HappyCustomerService){}
  ngOnInit(): void { }

  /*registerSubmit(){
    
     }*/
     display(){
      this.temp=localStorage.getItem('email');
          this.name=this.temp.split('@',2)[0];
       console.log(this.name,'name of the user');
      return this.name;
      console.log(this.temp);
    }
}