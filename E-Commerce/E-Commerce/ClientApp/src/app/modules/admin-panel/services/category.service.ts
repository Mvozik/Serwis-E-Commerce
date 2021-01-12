import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../../../environments/environment';
import { AddCategoryModel } from '../models/add-category.model';
import { AddSubCategoryModel } from '../models/add-subcategory.model';
import { CategoryModel } from '../models/category.model';
import { SectionModel } from '../models/section.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private httpClient: HttpClient) {}

  private url = baseUrl + 'Category/';

  getCategories(): Observable<CategoryModel[]> {
    return this.httpClient.get<CategoryModel[]>(this.url + 'Category');
  }
  postCategory(model: AddCategoryModel): Observable<any> {
    return this.httpClient.post(this.url + 'Category', model);
  }
  postSubCategory(model: AddSubCategoryModel): Observable<any> {
    return this.httpClient.post(this.url + 'SubCategory', model);
  }
  getSections(): Observable<SectionModel[]> {
    return this.httpClient.get<SectionModel[]>(this.url + 'Sections');
  }
  getCategoriesBySectionId(id: number): Observable<CategoryModel[]> {
    return this.httpClient.get<CategoryModel[]>(
      this.url + 'CategoryBySectionId?id=' + id
    );
  }
}
