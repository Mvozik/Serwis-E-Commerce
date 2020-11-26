import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from '../../../../app.state';
import { ProductModel } from '../../../admin-panel/models/product.model';
import { AddProductToCartModel } from '../../../shop-panel/models/add-product-to-cart.model';
import { ShoppingCartModel } from '../../../shop-panel/models/Shopping-cart.model';
import { ShoppingCartService } from '../../../shop-panel/services/shopping-cart.service';
import * as ShoppingCartActions from '../../../../actions/shoppingcart.actions';
import { ShoppingCartItemModel } from '../../../shop-panel/models/Shopping-cart-item.model';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input() product:ProductModel;
  shoppingCart:Observable<ShoppingCartModel>;
  shoppingCartId:any;
  constructor(private shoppingService:ShoppingCartService,private store:Store<AppState>,private _snackBar: MatSnackBar ) { }

  
  ngOnInit(): void {
    this.product.productPhoto="data:image/jpeg;base64,"+this.product.productPhoto;
    if(this.product.productPhoto=="data:image/jpeg;base64,null")
    {
      this.product.productPhoto = "../../../../../assets/photos/default.svg";
    }
    this.shoppingCart = this.store.select("shoppingCart");
    this.shoppingCart.subscribe(resp=>this.shoppingCartId=resp.id);
  }

  addProduct()
  {
      let model : AddProductToCartModel = {
        productId : this.product.id,
        shoppingCartId:this.shoppingCartId
      }
      
      this.shoppingService.addProductToCart(model).subscribe(
      (response:ShoppingCartItemModel)=>{
        if(response==null)
        {
          this._snackBar.open("Już dodałeś ten produkt do koszyka!","", {
            duration: 200,
          });
        }
        else
        {
          this.store.dispatch(new ShoppingCartActions.AddShoppingCartItem(response));
        }
        
      });
      

  }
}
