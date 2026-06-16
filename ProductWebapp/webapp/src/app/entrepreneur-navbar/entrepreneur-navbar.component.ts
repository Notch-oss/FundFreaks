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
    // this.productId=this.dataservice.getproductId();
    this.productId=123
    console.log(this.productId);
    // this.productId=this.route.snapshot.params['productId'];
  }
  display(){

   
    this.temp=localStorage.getItem('email');
        this.name=this.temp.split('@',2)[0];
     console.log(this.name,'name of the user');
    return this.name;
    console.log(this.temp);}
 
 
    clearLocal(){
      localStorage.clear();
    }



}
