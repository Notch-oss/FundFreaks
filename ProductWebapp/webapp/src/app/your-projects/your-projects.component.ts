import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Product } from '../models/product';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-your-projects',
  templateUrl: './your-projects.component.html',
  styleUrls: ['./your-projects.component.css']
})
export class YourProjectsComponent implements OnInit {
  title ='pagination';
  page:number=1;
  count:number =0;
  cardsPerPage:number=3;
  cardsPerPages :any=[1,2,3,4];
public products:Product[];
public product:Product;
public images : any [];
public i : number=0;

  constructor(private productService:ProductService,private sanitizer: DomSanitizer) { 
    this.product = new Product();
    this.products = [];
    this.images = [];
  }

  ngOnInit(): void {
    this.productService.yourProjects().subscribe((data:Array<Product>)=>{
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
