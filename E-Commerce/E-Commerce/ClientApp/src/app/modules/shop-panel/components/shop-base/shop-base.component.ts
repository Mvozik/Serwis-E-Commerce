import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from '../../../../app.state';
import { ShoppingCartModel } from '../../models/Shopping-cart.model';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import * as ShoppingCartActions from './../../../../actions/shoppingcart.actions'
@Component({
  selector: 'app-shop-base',
  templateUrl: './shop-base.component.html',
  styleUrls: ['./shop-base.component.scss']
})
export class ShopBaseComponent implements OnInit {

  constructor(private store:Store<AppState>,private shoppingCartService : ShoppingCartService)
  { 
    
    this.shoppingCartService.activeShoppingCard().subscribe(response=> {
      if(response)
      {
        
        this.model=response;
        this.store.dispatch(new ShoppingCartActions.SetShoppingCart(this.model));
      }
    });
    
    
  }
  model : ShoppingCartModel
  ngOnInit(): void {
  }

}
