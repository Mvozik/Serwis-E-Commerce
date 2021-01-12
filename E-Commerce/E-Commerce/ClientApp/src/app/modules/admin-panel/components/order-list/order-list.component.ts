import { Component, Input, OnInit } from '@angular/core';

import { OrderModel } from '../../models/order.model';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss'],
})
export class OrderListComponent implements OnInit {
  @Input() orders: OrderModel[];
  constructor() {}

  ngOnInit(): void {}
}
