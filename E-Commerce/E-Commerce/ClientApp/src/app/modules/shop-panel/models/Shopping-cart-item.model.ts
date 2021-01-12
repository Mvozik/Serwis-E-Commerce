import { ProductModel } from '../../admin-panel/models/product.model';

export interface ShoppingCartItemModel {
  id: number;
  shoppingCartId: number;
  userId: string;
  quantity: number;
  product: ProductModel;
}
