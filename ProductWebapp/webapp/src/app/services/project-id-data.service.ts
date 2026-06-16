import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProjectIdDataService {
  productId:any;

  constructor() { }

  setproductId(data:any){
    this.productId = data;
  }
  getproductId(){
    return this.productId;
  }
}
