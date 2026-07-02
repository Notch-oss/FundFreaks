import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Inv } from '../models/updateinvestor.model';
import { InvestorDataServiceService } from '../services/investor-data-service.service';

@Component({
  selector: 'app-display-investor-detail',
  templateUrl: './display-investor-detail.component.html',
  styleUrls: ['./display-investor-detail.component.css']
})
export class DisplayInvestorDetailComponent implements OnInit {
users:any=[];
user:any;
image:any;
id:string|undefined|null;
   constructor(private readonly investorData:InvestorDataServiceService, private readonly route: ActivatedRoute,private sanitizer: DomSanitizer)
   {


  }
    // constructor(private route:ActivatedRoute,
 

  ngOnInit(): void {
    this.route.paramMap.subscribe(

      (params)=>{
this.id = params.get("id");
if(this.id){
  this.investorData.getOne(this.id)
  .subscribe(
    (investorData)=>{
      this.user=investorData;
      let objectURL = 'data:image/png;base64,' + this.user.file;
      this.image = this.sanitizer.bypassSecurityTrustUrl(objectURL);
    }
  )

}
      }
    )
  }

     
    


  getOne(id: string){
    this.investorData.getOne(id)
    .subscribe(
      response => {
        this.user = response;

      }
    );

  }
  display(){
    

    let temp:any=localStorage.getItem('email');
    return temp;
   
 }



}
