import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from '../../../../app.state';
import { ChagneQuantityModel } from '../../models/change-quantity.model';
import { ShoppingCartItemModel } from '../../models/Shopping-cart-item.model';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import * as ShoppingCartActions from './../../../../actions/shoppingcart.actions';

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
  constructor(private shoppingService:ShoppingCartService,private store:Store<AppState>) { }

  ngOnInit(): void {
    this.photo="data:image/jpeg;base64,"+this.photo;
    if(this.photo=="data:image/jpeg;base64,null")
    {
      this.photo="../../../../../assets/photos/default.svg";
    }
    this.quantityInString=this.quantity.toString();
  }

  changeQuantity(event:any)
  {
    this.quantity=event.value;
    let model : ChagneQuantityModel = {
    shoppingCartItemId:this.id,
    quantity:this.quantity
    }
    this.shoppingService.changeQuantity(model).subscribe(
      (response:ShoppingCartItemModel)=>this.store.dispatch(
        new ShoppingCartActions.ChangeQuantity(response)));
  }

  delete()
  {
    this.shoppingService.deleteCartItem(this.id).subscribe();
    this.store.dispatch(new ShoppingCartActions.RemoveShoppingCartItem(this.id));
  }
}
