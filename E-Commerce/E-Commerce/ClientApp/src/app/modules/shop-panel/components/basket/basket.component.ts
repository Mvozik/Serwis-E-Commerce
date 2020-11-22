import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from '../../../../app.state';
import { ShoppingCartItemModel } from '../../models/Shopping-cart-item.model';
import { ShoppingCartModel } from '../../models/Shopping-cart.model';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import * as ShoppingCartActions from '../../../../actions/shoppingcart.actions' 
@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  constructor(private store:Store<AppState>,private shoppingCartService:ShoppingCartService)
  { 

    this.shoppingCard = this.store.select("shoppingCart");
    this.shoppingCard.subscribe(response=>{
        this.cart=response;
        this.sum=0;
        this.cart.shoppingCartItems.forEach(x=>
        {
          this.sum += x.product.price * x.quantity;
        }
      )
    }
    );
  }

  ngOnInit(): void {
    
  }
  clearShoppingCart()
  {
    this.shoppingCartService.clearShoppingCart(this.cart.id).subscribe();
    this.store.dispatch(new ShoppingCartActions.ClearShoppingCart());
    
  }

  onClick()
  {
    
  }

  shoppingCard:Observable<ShoppingCartModel>;
  sum:number= 0;
  cart : ShoppingCartModel;
}
