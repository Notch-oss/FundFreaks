import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EntrepreneurProfile } from 'src/app/models/entrepreneur-profile';
import {Product } from 'src/app/models/product'
import { AddIdeaService } from 'src/app/services/add-idea.service';

interface Category{
  value:string;
  viewValue:string;
}
interface Stage{
  value:string;
  viewValue:string;
}
interface BusinessModel{
  value:string;
  viewValue:string;
}

@Component({
  selector: 'app-add-idea',
  templateUrl: './add-idea.component.html',
  styleUrls: ['./add-idea.component.css'],
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: {showError: true},
    },
  ],
})
export class AddIdeaComponent implements OnInit {
product :Product;
selectedImg:any;
selectedPdf: any;
  isLinear = false;
projectCategory: Category[] = [
  {value: 'Health', viewValue: 'Health'},
  {value: 'Education', viewValue: ' Education'},
  {value: 'Clothing', viewValue: 'Clothing'},
  {value: 'Electronics', viewValue: 'Electronics'},
  {value: 'Food', viewValue: 'Food'},
  {value: 'Finance', viewValue: 'Finance'},
  
]
projectStage: Stage[] = [
  {value: 'Idea', viewValue: 'Idea'},
  {value: 'Earning', viewValue: 'Earning'}
  
]
projectBusinessModel:BusinessModel[]=[
  {value: 'B2B', viewValue: 'B2B'},
  {value: 'B2C', viewValue: 'B2C'}
]
  email: any;
  ent: EntrepreneurProfile;
  firstName: string;

 
  

  constructor(private formBuilder: FormBuilder,private addIdeaService:AddIdeaService) {
    this.product=new Product;
   }

  ngOnInit(): void {
    this.addIdeaService.getByEmail().subscribe((data:EntrepreneurProfile)=>{
      this.ent=data;
      this.firstName=this.ent.firstName;
    })
    
  }
  onSelectImg(fileInput: any) {
    this.selectedImg = <File>fileInput.target.files[0];
  }
  onSelectPdf(fileInput: any) {
    this.selectedPdf = <File>fileInput.target.files[0];
  }
  
    
  
  addIdea() {
      this.email=localStorage.getItem('email');
      const formData = new FormData();
      formData.append('Title', this.product.title);
      formData.append('Category', this.product.category);
      formData.append('BusinessModel', this.product.businessModel);
      formData.append('Stage', this.product.stage);
      formData.append('Location', this.product.location);
      formData.append('SharePrice', this.product.sharePrice);
      formData.append('Description', this.product.description);
      formData.append('ImageFile', this.selectedImg);
      formData.append('PdfFile', this.selectedPdf);
      formData.append('Email',this.email);
      formData.append('Owners',this.firstName);
    this.addIdeaService.addIdea(formData).subscribe(
     data => { });
     this.product = new Product();
      
  }


}
