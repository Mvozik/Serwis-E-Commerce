import { Component, OnInit } from '@angular/core';
import { OrderModel } from '../../models/order.model';
import { OrderService } from '../../services/order.service';
@Component({
  selector: 'app-active-order-list',
  templateUrl: './active-order-list.component.html',
  styleUrls: ['./active-order-list.component.scss'],
})
export class ActiveOrderListComponent implements OnInit {
  constructor(private orderService: OrderService) {}

  activeOrders: OrderModel[] = [];
  ngOnInit(): void {
    this.orderService
      .getActiveOrders()
      .subscribe((response) => (this.activeOrders = response));
  }
}
