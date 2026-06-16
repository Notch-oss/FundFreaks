
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, observable } from 'rxjs';
import { Product } from 'src/app/models/product';
import { Inv } from '../models/updateinvestor.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
readonly httplink = 'https://localhost:7054/api/GetProductsById?id=';
  email: string | null;
  constructor(private httpClient: HttpClient) { }
  getAllProducts():Observable<Array<Product>>{
    return this.httpClient.get<Array<Product>>('https://localhost:7054/api/GetAllProducts')
  }
  getProduct(id:any):Observable<Product> {
    return this.httpClient.get<Product>('https://localhost:7054/api/GetProductsById?id='+id);
  }
  public downloadpdf(id:any){
    return this.httpClient.get("https://localhost:7054/api/Product/DownloadPdf?id="+id,
    {observe:'response',responseType:'arraybuffer'})
  }
  public yourProjects(): Observable<Array<Product>>{
    this.email=localStorage.getItem('email');
    return this.httpClient.get<Array<Product>>("https://localhost:7054/api/GetProductByEmail?email="+this.email);
  }
  public getInvestorByEmail():Observable<Inv>{
    this.email=localStorage.getItem('email');
    return this.httpClient.get<Inv>("https://localhost:7295/api/GetUserByEmail?email="+"amar@gmail.com")
  }
  public getProductsByEmail(userEmail:string):Observable<Array<Product>>{
    return this.httpClient.get<Array<Product>>("https://localhost:7054/api/GetProductByEmail?email="+userEmail);
  }
}



