import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EntrepreneurProfile } from 'src/app/models/entrepreneur-profile';
import { EntrepreneurProfileService} from 'src/app/services/entrepreneur-profile.service';

interface Experience {
  value: string;
  viewValue: string;
}
interface Gender{
  value:string;
  viewValue:string;
}
interface Qualifications{
  value:string;
  viewValue:string;
}

@Component({
  selector: 'app-entrepreneur-profile',
  templateUrl: './entrepreneur-profile.component.html',
  styleUrls: ['./entrepreneur-profile.component.css'],
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: {showError: true},
    },
  ],
})
export class EntrepreneurProfileComponent implements OnInit {
entrepreneur:EntrepreneurProfile;
// firstFormGroup !: FormGroup;
// secondFormGroup !: FormGroup;
// thirdFormGroup !:FormGroup;
// isEditable = false ;
Gender: string[] = ['Male', 'Female', 'Others'];
foods: Experience[] = [
  {value: 'less than 1 year', viewValue: '<1 year'},
  {value: '1-2 years', viewValue: '1-2 Years'},
  {value: '2-3 years', viewValue: '2-3 Years'},
  {value: '3-4 years', viewValue: '3-4 Years'},
  {value: '4-5 years', viewValue: '4-5 Years'},
  {value: '5-6 years', viewValue: '5-6 Years'},
  {value: '6-7 years', viewValue: '6-7 Years'},
  {value: '7-8 years', viewValue: '7-8 Years'},
  {value: '8-9 years', viewValue: '8-9 Years'},
  {value: '9-10 years', viewValue: '9-10 Years'},
  {value: '>10 years', viewValue: '10+ Years'},
];
genderofent:Gender[]=[
  {value:'Male',viewValue:'Male'},
  {value:'Female',viewValue:'Female'},
  {value:'Others',viewValue:'Others'},
]
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
  selectedImg: any;
  email: any ;


  constructor(  private formBuilder: FormBuilder ,
    private entrepreneurProfileService:EntrepreneurProfileService) { 
      this.entrepreneur = new EntrepreneurProfile;
    }

  ngOnInit(): void {
  }
  onSelectImg(fileInput: any) {
    this.selectedImg = <File>fileInput.target.files[0];
  }
  addEntrepreneur(){
      this.email=localStorage.getItem('email');
      const formData = new FormData();
      formData.append('FirstName', this.entrepreneur.firstName);
      formData.append('LastName', this.entrepreneur.lastName);
      formData.append('Contact', this.entrepreneur.contact);
      formData.append('Gender', this.entrepreneur.gender);
      
      formData.append('Email',this.email);
      formData.append('Profession', this.entrepreneur.profession);
      formData.append('Img', this.selectedImg);
      formData.append('DateOfBirth', this.entrepreneur.dateofBirth);
      formData.append('HouseNo', this.entrepreneur.houseNo);
      
      formData.append('Pincode',this.entrepreneur.pincode);
      formData.append('AddressLine1', this.entrepreneur.addressLine1);
      formData.append('City', this.entrepreneur.city);
      formData.append('State', this.entrepreneur.state);
      formData.append('Country', this.entrepreneur.country);
      formData.append('Education', this.entrepreneur.education);
      formData.append('About', this.entrepreneur.about);
      formData.append('Work', this.entrepreneur.work);
      formData.append('Pincode', this.entrepreneur.pincode);


    this.entrepreneurProfileService.addUpateprofileen(formData).subscribe(

      data => { })
      this.entrepreneur= new EntrepreneurProfile();
    }
  }

