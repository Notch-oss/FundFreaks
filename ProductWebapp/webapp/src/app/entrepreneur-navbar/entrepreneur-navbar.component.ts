import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectIdDataService } from '../services/project-id-data.service';


@Component({
  selector: 'app-entrepreneur-navbar',
  templateUrl: './entrepreneur-navbar.component.html',
  styleUrls: ['./entrepreneur-navbar.component.css']
})
export class EntrepreneurNavbarComponent implements OnInit {
  productId: any;
  name:string;
  emailId:any;
  temp:any;

  constructor(private route : ActivatedRoute,private dataservice:ProjectIdDataService) { }

  ngOnInit(): void {
    this.productId=123
  }
  display(){

   
    this.temp=localStorage.getItem('email');
        this.name=this.temp.split('@',2)[0];
    return this.name;
    console.log(this.temp);}
 
 
    clearLocal(){
      localStorage.clear();
    }



}
