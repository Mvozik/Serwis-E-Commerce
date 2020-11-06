import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../../../environments/environment';
import { ShoppingCartModel } from '../models/Shopping-cart.model';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  constructor(private httpClient:HttpClient) { }
  private url = baseUrl+"ShoppingCarts";
  
  activeShoppingCard():Observable<ShoppingCartModel>
  {
      return this.httpClient.get<ShoppingCartModel>(this.url+"/active");
  }
}
