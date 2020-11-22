import { Component, OnInit } from '@angular/core';
import { ShoppingCartItemModel } from '../../models/Shopping-cart-item.model';
import { ShoppingCartModel } from '../../models/Shopping-cart.model';
import { ShoppingCartService } from '../../services/shopping-cart.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  constructor(private shoppingCartService:ShoppingCartService) { }

  ngOnInit(): void {
    this.shoppingCartService.activeShoppingCard().subscribe(response => {
      this.cart=response,
      this.cart.shoppingCartItems.forEach(element => {
      this.sum = element.quantity * element.product.price;
      element.product.productPhoto = "data:image/jpeg;base64,"+element.product.productPhoto;
    });
    
    
  });
  }

  sum:number= 0;
  cart : ShoppingCartModel;

  onClick()
  {
    console.log(this.cart);
  }
}
