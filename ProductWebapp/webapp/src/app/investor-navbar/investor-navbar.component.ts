import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-investor-navbar',
  templateUrl: './investor-navbar.component.html',
  styleUrls: ['./investor-navbar.component.css']
})
export class InvestorNavbarComponent implements OnInit {
  temp: any;
  name: string;

  constructor() { }

  ngOnInit(): void {
  }
  display(){
    localStorage.getItem('email')
  }


  display1(){

   
    this.temp=localStorage.getItem('email');
        this.name=this.temp.split('@',2)[0];
    return this.name;
 
  }
  clearLocal(){
    localStorage.clear();
  }
}
