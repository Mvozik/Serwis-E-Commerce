import { UserInformationsModel } from '../../shop-panel/models/user-informations.model';
export interface OrderModel {
  id: number;
  userInformations: UserInformationsModel;
  shoppingCartId: number;
  shippingFormat: string;
  shippingPrice: number;
  totalPrice: number;
  company: boolean;
  isPayed: boolean;
  isShipped: boolean;
  isRealized: boolean;
}
