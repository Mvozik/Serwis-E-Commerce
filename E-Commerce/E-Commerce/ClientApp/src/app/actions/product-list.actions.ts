import { Action } from '@ngrx/store'
import { ProductModel } from '../modules/admin-panel/models/product.model'


export const SET_STATE = '[ProductModel[]] Set'
export const REMOVE_STATE = '[] Remove'


export class SetProductList implements Action
{
    readonly type = SET_STATE
    constructor(public payload:ProductModel[]){}
}

export class RemoveProductList implements Action
{
    readonly type = REMOVE_STATE
    constructor(){}
}

export type Actions = SetProductList | RemoveProductList