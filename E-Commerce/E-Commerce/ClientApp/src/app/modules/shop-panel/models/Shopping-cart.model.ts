import {ShoppingCartItemModel} from './Shopping-cart-item.model'
export interface ShoppingCartModel
{
    userId:string;
    active:boolean;
    shoppingCartItems:ShoppingCartItemModel[] 
}