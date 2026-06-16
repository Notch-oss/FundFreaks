import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../models/product';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-entrepreneur-projects',
  templateUrl: './entrepreneur-projects.component.html',
  styleUrls: ['./entrepreneur-projects.component.css']
})
export class EntrepreneurProjectsComponent implements OnInit {
  email: any;
  title ='pagination';
  page:number=1;
  count:number =0;
  cardsPerPage:number=3;
  cardsPerPages :any=[1,2,3,4];
public products:Product[];
public product:Product;
public images : any [];
public i : number=0;
  

  constructor(private route : ActivatedRoute,private productService : ProductService,private sanitizer: DomSanitizer) { 
    this.product = new Product();
    this.products = [];
    this.images = [];
  }

  ngOnInit(): void {
    this.email=this.route.snapshot.params['email'];
    this.productService.getProductsByEmail(this.email).subscribe((data:Array<Product>)=>{
      this.products=data;
      this.products.forEach(element => {
        let objectURL = 'data:image/png;base64,' + element.imageFile;
         this.images[this.i] =  this.sanitizer.bypassSecurityTrustUrl(objectURL); 
         this.i++;
      });
     } );
  }

  onPageChange(event:any){
    this.page=event;
    this.ngOnInit();
  }
  onPageSizeChange(event:any):void{
    this.cardsPerPage=event.target.value;
    this.page =1;
    this.ngOnInit();
  }

}
