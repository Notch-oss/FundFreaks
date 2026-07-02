import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Product } from '../models/product';
import { RecomendationProduct } from '../models/recomendation-product';
import { Inv } from '../models/updateinvestor.model';
import { ProductService } from '../services/product.service';
import { StartupRecommendationService } from '../services/startup-recommendation.service';
@Component({
  selector: 'app-startup-recommendation',
  templateUrl: './startup-recommendation.component.html',
  styleUrls: ['./startup-recommendation.component.css']
})
export class StartupRecommendationComponent implements OnInit {
recommendation:any;
investorId :any;
  category: string|null;
  location: string|null;
  stage: string|null;
  model: string|null;
  products: Product[];
  categoryProducts:Product[];
  stageProducts :Product[];
  locationProducts:Product[];
  modelProducts:Product[];
  title ='pagination';
  page:number=1;
  count:number =0;
  cardsPerPage:number=1;
  cardsPerPages :any=[1,2,3];
  public product:Product;
public images : any [];
public i : number=0;
  recomendationProducts: RecomendationProduct[];
  productId: string;
  inv: Inv;
  constructor(private recommendationdata:StartupRecommendationService,private productService :ProductService,private sanitizer: DomSanitizer) { 
    this.products = [];
    this.categoryProducts=[];
    this.modelProducts=[];
    this.locationProducts=[];
    this.stageProducts=[];
    this.recomendationProducts=[];
    this.images = [];
    this.product = new Product();
    this.inv =new Inv();

  }

  ngOnInit(): void {
    this.i =0;
    this.images=[];
    this.products=[];
    this.recomendationProducts =[];
  this.productService.getInvestorByEmail().subscribe((data:Inv)=>{
    this.inv = data;
    this.investorId= this.inv.id;
  
    this.category = this.inv.category;
    this.location = this.inv.location;
    this.stage = this.inv.stage;
    this.model = this.inv.model;
  })

 
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

  categoryRecomendation(){
    this.ngOnInit();
    this.images=[];
    this.products=[];
    this.i =0;
    this.recomendationProducts =[];
    this.recommendationdata.categoryRecomendation(this.investorId).subscribe((data:Array<RecomendationProduct>)=>{
      this.recomendationProducts=data;
      this.i=0;
      this.products=[];
      this.categoryProducts=[];
      this.recomendationProducts.forEach(element => {

        this.productId = element.productId;
       this.productService.getProduct(this.productId).subscribe((data:Product)=>{
        this.product=data;
        let objectURL = 'data:image/png;base64,' + this.product.imageFile;
        this.images[this.i] =  this.sanitizer.bypassSecurityTrustUrl(objectURL); 
        this.categoryProducts[this.i] = this.product;
        this.i++;
       });  
       
       this.product = new Product();
       this.products =[];
       this.products=this.categoryProducts;
      });
     } );
    
  }
  locationRecomendation(){
    this.ngOnInit();
    this.images=[];
    this.products=[];
    this.i =0;
    this.recomendationProducts =[];
    this.recommendationdata.locationRecomendation(this.investorId).subscribe((data:Array<RecomendationProduct>)=>{
      this.recomendationProducts=data;
      this.i=0;
     this.products=[];
     this.locationProducts=[];
      this.recomendationProducts.forEach(element => {

        this.productId = element.productId;
       this.productService.getProduct(this.productId).subscribe((data:Product)=>{
        this.product=data;
        let objectURL = 'data:image/png;base64,' + this.product.imageFile;
        this.images[this.i] =  this.sanitizer.bypassSecurityTrustUrl(objectURL); 
        this.locationProducts[this.i] = this.product;
        this.i++;
       });  
       
       this.product = new Product();
       this.products=[];
       this.products = this.locationProducts;
      });
     } );
    
  }
  stageRecomendation(){
    this.ngOnInit();
    this.images=[];
    this.products=[];
    this.stageProducts=[];
    this.i =0;
    this.recomendationProducts =[];
    this.recommendationdata.stageRecomendation(this.investorId).subscribe((data:Array<RecomendationProduct>)=>{
      this.recomendationProducts=data;
      this.i=0;
      this.products=[];
      this.stageProducts=[];
      this.recomendationProducts.forEach(element => {

        this.productId = element.productId;
       this.productService.getProduct(this.productId).subscribe((data:Product)=>{
        this.product=data;
        let objectURL = 'data:image/png;base64,' + this.product.imageFile;
        this.images[this.i] =  this.sanitizer.bypassSecurityTrustUrl(objectURL); 
        this.stageProducts[this.i] = this.product;
        this.i++;
       });  
       
       this.product = new Product();
       this.products =[];
       this.products=this.stageProducts;
      });
     } );
    
  }
  modelRecomendation(){
    this.ngOnInit();
    this.images=[];
    this.products=[];
    this.modelProducts=[];
    this.i =0;
    this.recomendationProducts =[];
    this.recommendationdata.modelRecomendation(this.investorId).subscribe((data:Array<RecomendationProduct>)=>{
      this.recomendationProducts=data;
      this.i=0;
      this.products=[];
      this.modelProducts=[];
      this.recomendationProducts.forEach(element => {

        this.productId = element.productId;
       this.productService.getProduct(this.productId).subscribe((data:Product)=>{
        this.product=data;
        let objectURL = 'data:image/png;base64,' + this.product.imageFile;
        this.images[this.i] =  this.sanitizer.bypassSecurityTrustUrl(objectURL); 
        this.modelProducts[this.i] = this.product;
        this.i++;
       });  
       
       this.product = new Product();
       this.products=[];
       this.products=this.modelProducts;
      });
     } );
    
  }

}