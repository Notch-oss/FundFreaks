import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule} from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon'
import {MatListModule} from '@angular/material/list'
import {MatButtonModule} from '@angular/material/button'
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatMenuModule} from '@angular/material/menu';
import { EntrepreneurNavbarComponent } from './entrepreneur-navbar/entrepreneur-navbar.component';
import { InvestorNavbarComponent } from './investor-navbar/investor-navbar.component';
import {MatRadioModule} from '@angular/material/radio';
import { HomepageComponent } from './homepage/homepage.component';
//
import { CommonModule } from '@angular/common';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import {MatInputModule} from '@angular/material/input';
import {MatCardModule} from '@angular/material/card';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatSelectModule} from '@angular/material/select';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatChipsModule} from '@angular/material/chips';
import {MatDividerModule} from '@angular/material/divider';
import { AddIdeaComponent } from './add-idea/add-idea/add-idea.component';
//add idea
import {MatProgressBarModule} from '@angular/material/progress-bar';
//entrepreneur profile
import { EntrepreneurProfileComponent } from './entrepreneur-profile/entrepreneur-profile/entrepreneur-profile.component';
import { ProductListComponent } from './product-list/product-list/product-list.component';
//product list
import {MatPaginatorModule} from '@angular/material/paginator';
import { ProductViewComponent } from './product-view/product-view/product-view.component';
import {NgxPaginationModule} from 'ngx-pagination'

import { HappyCustomerComponent } from './happy-customer/happy-customer.component';

import { DisplayEntrepreneurDetailsComponent } from './display-entrepreneur-details/display-entrepreneur-details.component';
import { StartupRecommendationComponent } from './startup-recommendation/startup-recommendation.component';
import { UpdateInvestorProfileComponent } from './update-investor-profile/update-investor-profile.component';
import { DisplayInvestorDetailComponent } from './display-investor-detail/display-investor-detail.component';

import { EntrepreneurListComponent } from './entrepreneur-list/entrepreneur-list.component';
import { InvestorListComponent } from './investor-list/investor-list.component';
import { YourProjectsComponent } from './your-projects/your-projects.component';
import { EntrepreneurProjectsComponent } from './entrepreneur-projects/entrepreneur-projects.component';
@NgModule({
   declarations: [
    AppComponent,
  RegisterComponent,
  LoginComponent,
  EntrepreneurNavbarComponent,
  InvestorNavbarComponent,
  HomepageComponent,
  AddIdeaComponent,
  EntrepreneurProfileComponent,
  ProductListComponent,
  ProductViewComponent,
  UpdateInvestorProfileComponent,
  HappyCustomerComponent,
  DisplayInvestorDetailComponent,
  DisplayEntrepreneurDetailsComponent,
  StartupRecommendationComponent,
  EntrepreneurListComponent,
  InvestorListComponent,
  YourProjectsComponent,
  EntrepreneurProjectsComponent,
   ],  
 
  
   imports:[
     BrowserModule,
     AppRoutingModule,
     ReactiveFormsModule,
     MatSidenavModule,
     MatIconModule,
     MatToolbarModule,
     HttpClientModule,
     FormsModule,
     BrowserAnimationsModule,
     MatMenuModule,
     MatListModule,
     MatButtonModule,
     MatRadioModule,
     //Homepage
     CommonModule,
    MatStepperModule,
    FormsModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatCardModule,
    MatInputModule,
    MatDatepickerModule,
    MatSelectModule,
    MatGridListModule,
    MatChipsModule,
    MatDividerModule,
    //add idea
    MatProgressBarModule,
    //productlist
    MatPaginatorModule,
    NgxPaginationModule
    //productview


   ],
   providers: [],
   bootstrap: [AppComponent]
})
export class AppModule { }
