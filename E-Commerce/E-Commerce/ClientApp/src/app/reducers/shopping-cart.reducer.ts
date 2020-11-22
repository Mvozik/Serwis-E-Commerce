import * as ShoppingStateActions from '../actions/shoppingcart.actions';
import { ShoppingCartModel } from '../modules/shop-panel/models/Shopping-cart.model';

const initial : ShoppingCartModel={
    id:0,
    userId:"",
    shoppingCartItems:[],
    active:false
}

export function shoppingCartReducer(state:ShoppingCartModel = initial , action : ShoppingStateActions.Actions)
{
    switch(action.type){
        case ShoppingStateActions.SET_SHOPPING_CART:
            return action.payload;
        case ShoppingStateActions.REMOVE_SHOPPING_CART:
            return null;
        case ShoppingStateActions.REMOVE_SHOPPING_CART_ITEM:
            let newShoppingCartItems = state.shoppingCartItems.filter(obj => obj.id !== action.payload);
            let deletedItem : ShoppingCartModel = { 
                id:state.id,
                userId:state.userId,
                shoppingCartItems:newShoppingCartItems,
                active:state.active
             }
            return deletedItem;
        case ShoppingStateActions.ADD_SHOPPING_CART_ITEM:
            if(state.shoppingCartItems.length>0)
            {
                let existing = state.shoppingCartItems.filter(obj => obj.product.id === action.payload.product.id);
                if(existing.length>0)
                {
                let newState : ShoppingCartModel = { 
                    id:state.id,
                    userId:state.userId,
                    shoppingCartItems:[...state.shoppingCartItems],
                    active:state.active
                 }
                 return newState;
                }
                }
            let newState : ShoppingCartModel = { 
                id:state.id,
                userId:state.userId,
                shoppingCartItems:[...state.shoppingCartItems,action.payload],
                active:state.active
             }
            return newState;

        case ShoppingStateActions.CLEAR_SHOPPING_CART:
            let clearState : ShoppingCartModel = { 
                id:state.id,
                userId:state.userId,
                shoppingCartItems:[],
                active:state.active
             } 
            return clearState;
        case ShoppingStateActions.CHANGE_QUANTITY:
            let changedQuantity : ShoppingCartModel = { 
                id:state.id,
                userId:state.userId,
                shoppingCartItems:[...state.shoppingCartItems],
                active:state.active
            }
            return changedQuantity;   
        default:
            return state;
    }
}