import { ProductModel } from './product.model';

export interface MainPageItem {
  id: number;
  product: ProductModel;
  order: number;
}
