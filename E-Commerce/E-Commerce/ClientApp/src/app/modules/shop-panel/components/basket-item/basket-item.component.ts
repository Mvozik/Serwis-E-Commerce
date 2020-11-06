import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-basket-item',
  templateUrl: './basket-item.component.html',
  styleUrls: ['./basket-item.component.scss']
})
export class BasketItemComponent implements OnInit {
  @Input() photo:string;
  @Input() description:string;
  @Input() quantity:number;
  @Input() price:number

  quantityInString:string;
  constructor() { }

  ngOnInit(): void {
    this.quantityInString=this.quantity.toString();
  }


}
