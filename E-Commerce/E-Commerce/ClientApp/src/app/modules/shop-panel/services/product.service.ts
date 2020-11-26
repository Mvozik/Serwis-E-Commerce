import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../../../environments/environment';
import { ProductModel } from '../../admin-panel/models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient:HttpClient) { }
  url = baseUrl + "Product/products-by-section";
  
  getProductsBySectionId(id:number):Observable<ProductModel[]>
  {
    return this.httpClient.get<ProductModel[]>(this.url+"?id="+id);
  }

}
