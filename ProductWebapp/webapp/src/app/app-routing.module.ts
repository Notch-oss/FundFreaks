import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddIdeaComponent } from './add-idea/add-idea/add-idea.component';
import { DisplayEntrepreneurDetailsComponent } from './display-entrepreneur-details/display-entrepreneur-details.component';
import { DisplayInvestorDetailComponent } from './display-investor-detail/display-investor-detail.component';
import { EntrepreneurListComponent } from './entrepreneur-list/entrepreneur-list.component';
import { EntrepreneurNavbarComponent } from './entrepreneur-navbar/entrepreneur-navbar.component';
import { EntrepreneurProfileComponent } from './entrepreneur-profile/entrepreneur-profile/entrepreneur-profile.component';
import { EntrepreneurProjectsComponent } from './entrepreneur-projects/entrepreneur-projects.component';
import { AuthenticationGuard } from './guards/authentication.guard';
import { HappyCustomerComponent } from './happy-customer/happy-customer.component';
import { HomepageComponent } from './homepage/homepage.component';
import { InvestorListComponent } from './investor-list/investor-list.component';
import { InvestorNavbarComponent } from './investor-navbar/investor-navbar.component';
import { LoginComponent } from './login/login.component';
import { ProductListComponent } from './product-list/product-list/product-list.component';
import { ProductViewComponent } from './product-view/product-view/product-view.component';
import { RegisterComponent } from './register/register.component';
import { StartupRecommendationComponent } from './startup-recommendation/startup-recommendation.component';
import { UpdateInvestorProfileComponent } from './update-investor-profile/update-investor-profile.component';
import { YourProjectsComponent } from './your-projects/your-projects.component';



const routes:Routes=[
  {path: '',
    redirectTo: '/Homepage',
    pathMatch: 'full'},
    {path:'Homepage',component:HomepageComponent},

  {path:'Register',component:RegisterComponent},
  {path:'Login',component:LoginComponent},
  {path: 'viewDetails/:productId',component:ProductViewComponent},
  {path: 'viewDetail/:id',component:DisplayInvestorDetailComponent},
     {path:'view/:id',component:DisplayEntrepreneurDetailsComponent},
     {path:'YourProjects',component:YourProjectsComponent},
     {path:'YourProjects/:email',component:EntrepreneurProjectsComponent},
  {path:'viewMyProduct/:id',component:EntrepreneurNavbarComponent},
  {
    path:"InvestorNavbar",component:InvestorNavbarComponent,
    children:[

      {path:'ProductList',component:ProductListComponent,canActivate : [AuthenticationGuard]},
      {path:'UpdateProfileInvestor',component:UpdateInvestorProfileComponent,canActivate : [AuthenticationGuard]},
      {path:'Recommendations',component:StartupRecommendationComponent,canActivate : [AuthenticationGuard]},
      {path:'EnterpreneurList',component:EntrepreneurListComponent,canActivate : [AuthenticationGuard]},
      {path:'InvestorList',component:InvestorListComponent,canActivate : [AuthenticationGuard]},
      
    ]
  },

  {
    path:"EntrepreneurNavbar",component:EntrepreneurNavbarComponent,
    children:[
      {path:'HappyCustomers',component:HappyCustomerComponent,canActivate : [AuthenticationGuard]},
      {path:'AddIdea',component:AddIdeaComponent,canActivate : [AuthenticationGuard]},
      {path:'InvestorList',component:InvestorListComponent,canActivate : [AuthenticationGuard]},
      {path:'ProductList',component:ProductListComponent,canActivate : [AuthenticationGuard]},
      {path:'UpdateProfileEntrepreneur',component:EntrepreneurProfileComponent,canActivate : [AuthenticationGuard]},
      {path:'EnterpreneurList',component:EntrepreneurListComponent,canActivate : [AuthenticationGuard]},
      {path:'YourProjects',component:YourProjectsComponent,canActivate : [AuthenticationGuard]}

    
      //{path:'InvestorList',component:} 
      //{path:'EntrepreneurList',component:
    ]
  }

]

     
      //{path:'InvestorList',component:} 
      //{path:'EntrepreneurList',component:
    

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


