import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Product } from 'src/app/models/product';
import { EmailService } from 'src/app/services/email.service';
import { ProductService } from 'src/app/services/product.service';
import { Notification } from 'src/app/models/emailService.model';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  temp : any;
  name:any;
  notification:Notification={
    userEmailId:'',
    emailBody:''
  }

  title ='pagination';
  page:number=1;
  count:number =0;
  cardsPerPage:number=3;
  cardsPerPages :any=[1,2,3,4];
public products:Product[];
public product:Product;
public images : any [];
public i : number=0;
  constructor(private productService:ProductService,private sanitizer: DomSanitizer,private emailService:EmailService) { 
    this.product = new Product();
 
    this.products = [];
    this.images = [];
  }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe((data:Array<Product>)=>{
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
  sendNotification(productEmail:any){
    this.temp=localStorage.getItem('email');
    this.name=this.temp.split('@',2)[0];
    this.notification.userEmailId=productEmail;
    this.notification.emailBody=this.name+ " is interested on your idea. Investor emailId :"+this.temp;
  
    this.emailService.sendNotification(this.notification).subscribe(res=>{console.log(res);this.notification={userEmailId:'',emailBody:''}})
  }
}
