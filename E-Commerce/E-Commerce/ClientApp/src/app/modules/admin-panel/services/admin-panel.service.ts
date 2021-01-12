import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../../../environments/environment';
import { AddMainPageItemModel } from '../models/add-mainpage-item.model';
import { AddProductModel } from '../models/add-product.model';
import { MainPageItem } from '../models/mainpage-item.model';
import { ProductModel } from '../models/product.model';
@Injectable({
  providedIn: 'root',
})
export class AdminPanelService {
  constructor(private httpClient: HttpClient) {}

  private url = baseUrl + 'Product';

  addProduct(product: any): Observable<any> {
    return this.httpClient.post(this.url, product);
  }

  getAllProducts(): Observable<any> {
    return this.httpClient.get(this.url + '/all');
  }

  getMainPageProducts(): Observable<MainPageItem[]> {
    return this.httpClient.get<MainPageItem[]>(this.url + '/mainpage');
  }

  postMainPageItem(model: AddMainPageItemModel): Observable<MainPageItem[]> {
    return this.httpClient.post<MainPageItem[]>(
      this.url + '/add-to-mainpage',
      model
    );
  }

  getProductById(id: number): Observable<any> {
    return this.httpClient.get(this.url + '?id=' + id);
  }

  putProduct(product: any): Observable<any> {
    return this.httpClient.put(this.url, product);
  }

  deleteProduct(id: number): Observable<any> {
    return this.httpClient.delete(this.url + '?id=' + id);
  }
}
