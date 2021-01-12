import { LoginStateModel } from './models/login-state.model';
import { ShoppingCartModel } from './modules/shop-panel/models/Shopping-cart.model';

export interface AppState {
  readonly loginState: LoginStateModel;
  readonly shoppingCart: ShoppingCartModel;
}
