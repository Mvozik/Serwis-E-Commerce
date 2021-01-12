import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../../../environments/environment';
import { ProductModel } from '../../admin-panel/models/product.model';
import { SectionModel } from '../../admin-panel/models/section.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private httpClient: HttpClient) {}
  url = baseUrl + 'Product';

  getProductsBySectionId(id: number): Observable<ProductModel[]> {
    return this.httpClient.get<ProductModel[]>(
      this.url + '/products-by-section?id=' + id
    );
  }

  getProductsByCategoryId(id: number): Observable<ProductModel[]> {
    return this.httpClient.get<ProductModel[]>(
      this.url + '/products-by-category?id=' + id
    );
  }

  getProductsBySubCategoryId(id: number): Observable<ProductModel[]> {
    return this.httpClient.get<ProductModel[]>(
      this.url + '/products-by-subcategory?id=' + id
    );
  }

  


}
