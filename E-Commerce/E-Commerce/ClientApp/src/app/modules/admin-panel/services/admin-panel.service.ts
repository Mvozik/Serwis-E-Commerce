import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../../../environments/environment';
import { AddProductModel } from '../models/add-product.model'
import { ProductModel } from '../models/product.model';
@Injectable({
  providedIn: 'root'
})
export class AdminPanelService {

  constructor(private httpClient:HttpClient) { }

  private url = baseUrl+"Product";

  addProduct(product:any):Observable<any>
  {
    return this.httpClient.post(this.url,product);
  }

  getAllProducts(): Observable<any>
  {
    return this.httpClient.get(this.url+"/all");
  }

  getMainPageProducts(): Observable<any>
  {
    return this.httpClient.get(this.url+"/mainpage");
  }

  getProductById(id:number): Observable<any>
  {
    return this.httpClient.get(this.url+"?id="+id);
  }
  
  putProduct(product:any):Observable<any>
  {
    return this.httpClient.put(this.url,product);
  }
}
