import { Component, Input, OnInit } from '@angular/core';
import { ShoppingCartService } from '../../services/shopping-cart.service';

@Component({
  selector: 'app-basket-item',
  templateUrl: './basket-item.component.html',
  styleUrls: ['./basket-item.component.scss']
})
export class BasketItemComponent implements OnInit {
  @Input() photo:string;
  @Input() name:string;
  @Input() quantity:number;
  @Input() price:number
  @Input() id:number;
  quantityInString:string;
  constructor(private shoppingService:ShoppingCartService) { }

  ngOnInit(): void {
    this.quantityInString=this.quantity.toString();
  }

  delete()
  {
    this.shoppingService.deleteCartItem(this.id).subscribe(response=>console.log(response));
    
  }
}
