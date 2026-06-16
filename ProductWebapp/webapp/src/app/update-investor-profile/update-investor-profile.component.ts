import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { Component, OnInit } from '@angular/core';
import { Inv } from '../models/updateinvestor.model'
import { UpdateinvestorService} from '../services/updateinvestor.service'
interface Experience {
  value: string;
  viewValue: string;
}
interface Qualifications {
  value: string;
  viewValue: string;
}
interface Gender {
  value: string;
  viewValue: string;
}
import {FormBuilder, FormGroup, Validators,} from '@angular/forms';
import {MatChipInputEvent} from '@angular/material/chips';

export interface Fruit {
  name: string;
}
export interface Apple {
  name: string;
}
export interface Eye {
  name: string;
}
export interface Bye {
  name: string;
}



@Component({
  selector: 'app-update-investor-profile',
  templateUrl: './update-investor-profile.component.html',
  styleUrls: ['./update-investor-profile.component.css']
})
export class UpdateInvestorProfileComponent implements OnInit {

  inv:Inv;
  selectedImg: File;



  
  firstFormGroup !: FormGroup;
  // secondFormGroup !: FormGroup;
  // thirdFormGroup !: FormGroup;
  // title='investordetails';
  // cards: Card[] = [];
  // card: Card = {
  //   name: '',
  // }


  // isLinear = true;
  Gender: string| undefined;
  gender: string[] = ['Male', 'Female', 'Other'];
  foods: Experience[] = [
    {value: '0-1 years', viewValue: '0-1 Year'},
    {value: '1-2 years', viewValue: '1-2 Years'},
    {value: '2-3 years', viewValue: '2-3 Years'},
    {value: '3-4 years', viewValue: '3-4 Years'},
    {value: '4-5 years', viewValue: '4-5 Years'},
    {value: '5-6 years', viewValue: '5-6 Years'},
    {value: '6-7 years', viewValue: '6-7 Years'},
    {value: '7-8 years', viewValue: '7-8 Years'},
    {value: '8-9 years', viewValue: '8-9 Years'},
    {value: '9-10 years', viewValue: '9-10 Years'},
    {value: '10+ years', viewValue: '10+ Years'},
  ];
  foos: Qualifications[] = [
    {value: 'No Formal Education', viewValue: 'No Formal Education'},
    {value: 'Primary Education', viewValue: 'Primary Education'},
    {value: 'Secondary Education', viewValue: 'Secondary Education'},
    {value: 'Matriculation', viewValue: 'Matriculation'},
    {value: 'Intermediate', viewValue: 'Intermediate'},
    {value: 'Bachelors Degree', viewValue: 'Bachelors Degree'},
    {value: 'Masters Degree', viewValue: 'Masters Degree'},
    {value: 'Doctorate or Higher', viewValue: 'Doctorate or Higher'},
  ]
  fos: Gender[] =[
    {value: 'Male', viewValue: 'Male'},
    {value: 'Female', viewValue: 'Female'},
    {value: 'Other', viewValue: 'Other'},
  ]

  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  fruits: Fruit[] = [];
  apples: Apple[] = [];
  eyes: Eye[] = [];
  byes: Bye[] = [];
  investorId: string;
  interestedCategory: string;
  interestedLocation: string;
  interestedStage: string;
  interestedModel: string;
  email:any;

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.fruits.push({name: value});
    }

    event.chipInput!.clear();
  }

  remove(fruit: Fruit): void {
    const index = this.fruits.indexOf(fruit);

    if (index >= 0) {
      this.fruits.splice(index, 1);
    }
  }
  add2(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.apples.push({name: value});
    }

    event.chipInput!.clear();
  }
  remove2(apple: Apple): void {
    const index = this.apples.indexOf(apple);

    if (index >= 0) {
      this.apples.splice(index, 1);
    }
  }
  add3(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.eyes.push({name: value});
    }

    event.chipInput!.clear();
  }

  remove3(eye: Eye): void {
    const index = this.eyes.indexOf(eye);

    if (index >= 0) {
      this.eyes.splice(index, 1);
    }
  }
  add4(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.byes.push({name: value});
    }

    event.chipInput!.clear();
  }

  remove4(bye: Bye): void {
    const index = this.byes.indexOf(bye);

    if (index >= 0) {
      this.byes.splice(index, 1);
    }
  }
  
  constructor(
    private formBuilder: FormBuilder,
    private service: UpdateinvestorService) {
      this.inv=new Inv;
    }

  ngOnInit(): void {
    this.firstFormGroup = this.formBuilder.group({
      name: ['', Validators.required],
      // lastname: ['', Validators.required],
      // dateofbirth: ['', Validators.required],
      // gender: ['', Validators.required],
      // contact:['',Validators.required],
      // profession:['',Validators.required],
      // image:['',Validators.required]

    });
  //   this.secondFormGroup = this.formBuilder.group({
  //     houseno: ['', Validators.required],
  //     streetno: ['', Validators.required],
  //     address: ['', Validators.required],
  //     city: ['', Validators.required],
  //     pincode: ['', Validators.required],
  //     state: ['', Validators.required],
  //     country: ['', Validators.required]
  //   });
  //   this.thirdFormGroup=this.formBuilder.group({
  //     education: ['', Validators.required],
  //     about: ['', Validators.required],
  //     work: ['', Validators.required],
  //     category: ['', Validators.required],
  //     location: ['', Validators.required],
  //     stage: ['', Validators.required],
  //     model: ['', Validators.required]
  // });
}


onSelectImg(fileInput: any) {
  this.selectedImg = <File>fileInput.target.files[0];
}

  addInv(){
    this.email=localStorage.getItem('email');
    console.log(this.inv.category);
      const formData = new FormData();
      formData.append('Name', this.inv.name);
      formData.append('LastName', this.inv.lastname);
      formData.append('Contact', this.inv.contact);
      formData.append('Stage', this.inv.stage);
      formData.append('Location', this.inv.location);
      formData.append('Gender', this.inv.gender);
      formData.append('Profession', this.inv.profession);
      formData.append('File', this.selectedImg);
      formData.append('DateOfBirth', this.inv.dateofBirth);
      formData.append('HouseNo', this.inv.houseno);
      formData.append('StreetNo', this.inv.streetno);
      formData.append('Address', this.inv.address);
      formData.append('City', this.inv.city);
      formData.append('State', this.inv.state);
      formData.append('Country', this.inv.country);
      formData.append('Education', this.inv.education);
      formData.append('About', this.inv.about);
      formData.append('Work', this.inv.work);
      formData.append('Category', this.inv.category);
      formData.append('Model', this.inv.model);
      formData.append('Email',this.email);
      formData.append('Pincode',this.inv.pincode);
    this.service.addUpdateprofileinv(formData).subscribe(
     data => {
      this.investorId = data.id;
      this.interestedCategory = data.category;
      this.interestedLocation = data.location;
      this.interestedStage = data.stage;
      this.interestedModel = data.model;
      // this.sharedData.setInvestorId(this.investorId);
      // this.sharedData.setCategory(this.interestedCategory);
      // this.sharedData.setLocation(this.interestedLocation);
      // this.sharedData.setModel(this.interestedModel);
      // this.sharedData.setStage(this.interestedStage);
      });
     this.inv = new Inv();
  
  }};
   
