import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from '../../../../app.state';
import { ShoppingCartItemModel } from '../../models/Shopping-cart-item.model';
import { ShoppingCartModel } from '../../models/Shopping-cart.model';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import * as ShoppingCartActions from '../../../../actions/shoppingcart.actions';
import { LoginStateModel } from 'src/app/models/login-state.model';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss'],
})
export class BasketComponent implements OnInit {
  shoppingCard: Observable<ShoppingCartModel>;
  sum: number = 0;
  cart: ShoppingCartModel;
  loginStatus: Observable<LoginStateModel>;
  isLogged: boolean;
  constructor(
    private store: Store<AppState>,
    private shoppingCartService: ShoppingCartService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.shoppingCard = this.store.select('shoppingCart');
    this.shoppingCard.subscribe((response) => {
      this.cart = response;
      this.sum = 0;
      this.cart.shoppingCartItems.forEach((x) => {
        this.sum += x.product.price * x.quantity;
      });
    });

    this.loginStatus = this.store.select('loginState');
    this.loginStatus.subscribe((response) => {
      if (response.loginState == '1') {
        this.isLogged = true;
      }
      if (response.loginState == '0') {
        this.isLogged = false;
      }
    });
  }
  clearShoppingCart() {
    this.shoppingCartService.clearShoppingCart(this.cart.id).subscribe();
    this.store.dispatch(new ShoppingCartActions.ClearShoppingCart());
  }

  onClick() {}

  updateQuantity(event: ShoppingCartItemModel) {
    this.store.dispatch(new ShoppingCartActions.ChangeQuantity(event));
  }

  saveShoppingCart() {
    if (this.cart.shoppingCartItems.length > 0) {
      console.log('XD');
      this.shoppingCartService.addNewShoppingCart().subscribe((response) => {
        this.store.dispatch(new ShoppingCartActions.SetShoppingCart(response));
      });
    } else {
      this._snackBar.open('Nie możesz zapisać pustego koszyka!', '', {
        duration: 2000,
      });
    }
  }
}
