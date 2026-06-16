import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RecomendationProduct } from '../models/recomendation-product';

@Injectable({
  providedIn: 'root'
})
export class StartupRecommendationService {
  
  constructor(private http:HttpClient) { }
  products():Observable<Array<RecomendationProduct>>{
    return this.http.get<Array<RecomendationProduct>>('https://localhost:7025/api/products');}
    
  categoryRecomendation(id:string):Observable<Array<RecomendationProduct>>{
    return this.http.get<Array<RecomendationProduct>>('https://localhost:7025/api/investorRecomendation/category/'+id);
  }
  locationRecomendation(id:string):Observable<Array<RecomendationProduct>>{
    return this.http.get<Array<RecomendationProduct>>('https://localhost:7025/api/investorRecomendation/location/'+id);
  }
  stageRecomendation(id:string):Observable<Array<RecomendationProduct>>{
    return this.http.get<Array<RecomendationProduct>>('https://localhost:7025/api/investorRecomendation/stage/'+id);
  }
  modelRecomendation(id:string):Observable<Array<RecomendationProduct>>{
    return this.http.get<Array<RecomendationProduct>>('https://localhost:7025/api/investorRecomendation/model/'+id);
  }
}
