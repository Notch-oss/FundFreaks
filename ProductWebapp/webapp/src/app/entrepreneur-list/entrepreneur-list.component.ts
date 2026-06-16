import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { EntrepreneurProfile } from '../models/entrepreneur-profile';

import { EntlistService } from '../services/entlist.service';

@Component({
  selector: 'app-entrepreneur-list',
  templateUrl: './entrepreneur-list.component.html',
  styleUrls: ['./entrepreneur-list.component.css']
})
export class EntrepreneurListComponent implements OnInit {
  title ='pagination';
  page:number=1;
  count:number =0;
  cardsPerPage:number=3;
  cardsPerPages :any=[1,2,3,4];
  public entrepreneurs:EntrepreneurProfile[];
public ent:EntrepreneurProfile
public images : any [];
public i : number=0;
  constructor(private listService:EntlistService,private sanitizer:DomSanitizer) { 
  this.ent = new EntrepreneurProfile();
  this.entrepreneurs = [];
  this.images = [];
}
  ngOnInit(): void {
    this.listService.getAll().subscribe((data:Array<EntrepreneurProfile>)=>{
      this.entrepreneurs=data;
      console.log(this.entrepreneurs);
      this.entrepreneurs.forEach(element =>{
        let objectURL = 'data:image/png;base64,'+ element.img;
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
