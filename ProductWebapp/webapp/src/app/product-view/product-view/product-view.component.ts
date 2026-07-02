import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute } from '@angular/router';
import { Notification } from 'src/app/models/emailService.model';
import { EmailService } from 'src/app/services/email.service';
@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {
  temp:any;
  name:any; 
  notification:Notification={
    userEmailId:'',
    emailBody:''
  }
  errMessage: string;
  public product: Product;
  productId: any;
  image: any;
  iframeSrc: any;


  constructor(private productService: ProductService, private sanitizer: DomSanitizer,private route : ActivatedRoute,private emailService :EmailService) {
    this.product = new Product();
    this.errMessage = '';
    this.productId = '';
  }

  ngOnInit(): void {
    this.productId=this.route.snapshot.params['productId'];
    this.productService.getProduct(this.productId).subscribe(
      (data: Product) => {
        this.product = data;
        let objectURL = 'data:image/png;base64,' + this.product.imageFile;
        this.image = this.sanitizer.bypassSecurityTrustUrl(objectURL);  
        }  
    )
  }
  download() {
       this.productService.downloadpdf(this.productId).subscribe(
        response =>{
          const blob = new Blob([(response as any).body], {type: 'application/pdf'});
          const fileName ='documentation.pdf'
          let a = document.createElement('a');
          a.download=fileName;
          a.href= window.URL.createObjectURL(blob);
          a.click();
        }
       )
    }
    sendNotification(){
      this.temp=localStorage.getItem('email');
      this.name=this.temp.split('@',2)[0];
      this.notification.userEmailId=this.product.email;
      this.notification.emailBody=this.name+ " is interested on your idea. Investor emailId :"+this.temp;
    
      this.emailService.sendNotification(this.notification).subscribe(res=>{console.log(res);this.notification={userEmailId:'',emailBody:''}})
    }
}
