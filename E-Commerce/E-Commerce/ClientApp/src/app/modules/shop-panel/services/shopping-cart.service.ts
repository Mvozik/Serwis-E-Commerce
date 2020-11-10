import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../../../environments/environment';
import { AddProductToCartModel } from '../models/add-product-to-cart.model';
import { ShoppingCartModel } from '../models/Shopping-cart.model';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  constructor(private httpClient:HttpClient) { }
  private url = baseUrl+"ShoppingCart";
  
  activeShoppingCard():Observable<ShoppingCartModel>
  {
      return this.httpClient.get<ShoppingCartModel>(this.url+"/active");
  }

  deleteCartItem(id:number):Observable<any>
  {
      return this.httpClient.delete(this.url+"/shoppingcartitem?id="+id);
  }

  addProductToCart(model:AddProductToCartModel):Observable<any>
  {
      return this.httpClient.post(this.url+"/add-to-shopping-card",model);
  }

}
