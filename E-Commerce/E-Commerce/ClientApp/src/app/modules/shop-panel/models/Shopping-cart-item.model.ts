import { AdvertModel } from "./Advert.model";

export interface ShoppingCartItemModel
{
    shoppingCartId:number;
    userId:string;
    quantity:number;
    advert:AdvertModel;
}