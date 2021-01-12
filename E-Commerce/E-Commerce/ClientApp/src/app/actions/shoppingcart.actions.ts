import { Action } from '@ngrx/store';
import { ShoppingCartModel } from '../modules/shop-panel/models/Shopping-cart.model';
import { ShoppingCartItemModel } from '../modules/shop-panel/models/Shopping-cart-item.model';
import { ChagneQuantityModel } from '../modules/shop-panel/models/change-quantity.model';

export const SET_SHOPPING_CART = '[SHOPPINGCARTMODEL] Set';
export const REMOVE_SHOPPING_CART = '[SHOPPINGCARTMODEL] Remove';
export const REMOVE_SHOPPING_CART_ITEM = '[SHOPPINGCARTITEMMODEL] RemoveItem';
export const ADD_SHOPPING_CART_ITEM = '[SHOPPINGCARTITEMMODEL] AddItem';
export const CLEAR_SHOPPING_CART = '[] ClearShoppingCart';
export const CHANGE_QUANTITY = '[CHANGEQUANTITYMODEL] ChangeQuantity';

export class SetShoppingCart implements Action {
  readonly type = SET_SHOPPING_CART;
  constructor(public payload: ShoppingCartModel) {}
}

export class RemoveShoppingCart implements Action {
  readonly type = REMOVE_SHOPPING_CART;
  constructor() {}
}

export class RemoveShoppingCartItem implements Action {
  readonly type = REMOVE_SHOPPING_CART_ITEM;
  constructor(public payload: number) {}
}

export class AddShoppingCartItem implements Action {
  readonly type = ADD_SHOPPING_CART_ITEM;
  constructor(public payload: ShoppingCartItemModel) {}
}

export class ClearShoppingCart implements Action {
  readonly type = CLEAR_SHOPPING_CART;
  constructor() {}
}

export class ChangeQuantity implements Action {
  readonly type = CHANGE_QUANTITY;
  constructor(public payload: ShoppingCartItemModel) {}
}
export type Actions =
  | SetShoppingCart
  | RemoveShoppingCart
  | RemoveShoppingCartItem
  | AddShoppingCartItem
  | ClearShoppingCart
  | ChangeQuantity;
