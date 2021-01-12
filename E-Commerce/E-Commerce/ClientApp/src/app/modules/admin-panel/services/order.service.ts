import { Injectable } from '@angular/core';
import { baseUrl } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderModel } from '../models/order.model';
@Injectable({
  providedIn: 'root',
})
export class OrderService {
  constructor(private httpClient: HttpClient) {}

  private url = baseUrl + 'Order/';

  getActiveOrders(): Observable<OrderModel[]> {
    return this.httpClient.get<OrderModel[]>(this.url + 'active');
  }
  getRealizedOrders(): Observable<OrderModel[]> {
    return this.httpClient.get<OrderModel[]>(this.url + 'realized');
  }
  changePaymentStatus(id: number): Observable<boolean> {
    return this.httpClient.patch<boolean>(this.url + 'payment?id=' + id, {});
  }
  changeShippingStatus(id: number): Observable<boolean> {
    return this.httpClient.patch<boolean>(this.url + 'shipping?id=' + id, {});
  }
  changeRealizationStatus(id: number): Observable<boolean> {
    return this.httpClient.patch<boolean>(
      this.url + 'realization?id=' + id,
      {}
    );
  }
}
