import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/app.state';
import { ShoppingCartService } from 'src/app/modules/shop-panel/services/shopping-cart.service';
import { AuthService } from '../../services/auth.service';
import * as ShoppingCartActions from '../../actions/shoppingcart.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'E-Commerce';

  constructor(
    private basketService: ShoppingCartService,
    private store: Store<AppState>
  ) {}

  ngOnInit() {
    if (localStorage.getItem('JWT_TOKEN')) {
      this.basketService
        .activeShoppingCard()
        .subscribe((response) =>
          this.store.dispatch(new ShoppingCartActions.SetShoppingCart(response))
        );
    }
  }
}
