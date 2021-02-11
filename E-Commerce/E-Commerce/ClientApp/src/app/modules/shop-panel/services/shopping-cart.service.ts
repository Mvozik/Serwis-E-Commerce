import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../../../environments/environment';
import { AddProductToCartModel } from '../models/add-product-to-cart.model';
import { ChagneQuantityModel } from '../models/change-quantity.model';
import { ShoppingCartModel } from '../models/Shopping-cart.model';

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartService {
  constructor(private httpClient: HttpClient) {}
  private url = baseUrl + 'ShoppingCart';

  activeShoppingCard(): Observable<ShoppingCartModel> {
    return this.httpClient.get<ShoppingCartModel>(this.url + '/active');
  }

  deleteCartItem(id: number): Observable<any> {
    return this.httpClient.delete(this.url + '/shoppingcartitem?id=' + id);
  }

  addProductToCart(model: AddProductToCartModel): Observable<any> {
    return this.httpClient.post(this.url + '/add-to-shopping-card', model);
  }

  changeQuantity(model: ChagneQuantityModel) {
    return this.httpClient.post(this.url + '/change-quantity', model);
  }

  clearShoppingCart(id: number) {
    return this.httpClient.delete(
      this.url + '/clear-shopping-cart?shoppingCartId=' + id
    );
  }

  getAllShoppingCarts(): Observable<ShoppingCartModel[]> {
    return this.httpClient.get<ShoppingCartModel[]>(this.url + '/all');
  }

  addNewShoppingCart(): Observable<ShoppingCartModel> {
    return this.httpClient.post<ShoppingCartModel>(
      this.url + '/ShoppingCart',
      {}
    );
  }

  deleteShoppingCart(id: number): Observable<number> {
    return this.httpClient.delete<number>(this.url + '/ShoppingCart?id=' + id);
  }
  changeActiveShoppingCart(id: number): Observable<ShoppingCartModel> {
    return this.httpClient.patch<ShoppingCartModel>(
      this.url + '/ShoppingCart?id=' + id,
      {}
    );
  }
}
