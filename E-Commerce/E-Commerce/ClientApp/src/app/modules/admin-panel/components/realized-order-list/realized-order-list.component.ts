import { Component, OnInit } from '@angular/core';
import { OrderModel } from '../../models/order.model';
import { OrderService } from '../../services/order.service';
@Component({
  selector: 'app-realized-order-list',
  templateUrl: './realized-order-list.component.html',
  styleUrls: ['./realized-order-list.component.scss'],
})
export class RealizedOrderListComponent implements OnInit {
  constructor(private orderService: OrderService) {}

  realizedOrders: OrderModel[] = [];
  ngOnInit(): void {
    this.orderService
      .getRealizedOrders()
      .subscribe((response) => (this.realizedOrders = response));
  }
}
