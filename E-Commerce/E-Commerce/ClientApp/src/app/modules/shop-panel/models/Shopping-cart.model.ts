import { ShoppingCartItemModel } from './Shopping-cart-item.model';
export interface ShoppingCartModel {
  id: number;
  userId: string;
  active: boolean;
  shoppingCartItems: ShoppingCartItemModel[];
}
