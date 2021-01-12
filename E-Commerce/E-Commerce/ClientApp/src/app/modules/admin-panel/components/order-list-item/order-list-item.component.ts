import { Component, Input, OnInit } from '@angular/core';
import { OrderModel } from '../../models/order.model';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order-list-item',
  templateUrl: './order-list-item.component.html',
  styleUrls: ['./order-list-item.component.scss'],
})
export class OrderListItemComponent implements OnInit {
  @Input() order: OrderModel;
  constructor(private orderService: OrderService) {}

  ngOnInit(): void {}

  changePaymentStatus() {
    this.orderService
      .changePaymentStatus(this.order.id)
      .subscribe((response) => (this.order.isPayed = response));
  }
  changeShippingStatus() {
    this.orderService
      .changeShippingStatus(this.order.id)
      .subscribe((response) => (this.order.isShipped = response));
  }
  changeRealizationStatus() {
    this.orderService
      .changeRealizationStatus(this.order.id)
      .subscribe((response) => (this.order.isRealized = response));
  }
}
