import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Inv } from '../models/updateinvestor.model';
import { InvestorlistService } from '../services/investorlist.service';

@Component({
  selector: 'app-investor-list',
  templateUrl: './investor-list.component.html',
  styleUrls: ['./investor-list.component.css']
})
export class InvestorListComponent implements OnInit {
  title ='pagination';
  page:number=1;
  count:number =0;
  cardsPerPage:number=3;
  cardsPerPages :any=[1,2,3,4];
public investors:Inv[];
public inv:Inv;
public images : any [];
public i : number=0;

  constructor(private listService:InvestorlistService,private sanitizer:DomSanitizer ) { 
    this.inv = new Inv();
    this.investors = [];
    this.images = [];
  }

  ngOnInit(): void {
    this.listService.getAll().subscribe((data:Array<Inv>)=>{
      this.investors=data;
      this.investors.forEach(element =>{
        let objectURL =  'data:image/png;base64,'+ element.file;
        this.images[this.i]=this.sanitizer.bypassSecurityTrustUrl(objectURL);
        this.i++;
      });
    });
    
  }

  onPageChange(event:any){
    this.page=event;
    this.ngOnInit();
  }
  onPageSizeChange(event:any):void{
    this.cardsPerPage=event.target.value;
    this.page=1;
    this.ngOnInit();
  }

}
