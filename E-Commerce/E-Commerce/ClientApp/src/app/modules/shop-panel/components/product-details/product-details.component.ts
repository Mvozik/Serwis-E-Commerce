import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/app.state';
import { ProductModel } from 'src/app/modules/admin-panel/models/product.model';
import { AddProductToCartModel } from '../../models/add-product-to-cart.model';
import { ShoppingCartItemModel } from '../../models/Shopping-cart-item.model';
import { ProductService } from '../../services/product.service';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import * as ShoppingCartActions from '../../../../actions/shoppingcart.actions';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private store: Store<AppState>,
    private shoppingService: ShoppingCartService,
    private _snackBar: MatSnackBar
  ) {}

  product: ProductModel;
  quantity: number = 1;
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.productService
      .getProductById(+id)
      .subscribe((response) => (this.product = response));
  }
  changeQuantity(event: any) {
    this.quantity = event.value;
  }
  addToCart() {
    let model: AddProductToCartModel = {
      productId: this.product.id,
      quantity: this.quantity,
    };

    this.shoppingService
      .addProductToCart(model)
      .subscribe((response: ShoppingCartItemModel) => {
        if (response == null) {
          this._snackBar.open('Już dodałeś ten produkt do koszyka!', '', {
            duration: 600,
          });
        } else {
          this.store.dispatch(
            new ShoppingCartActions.AddShoppingCartItem(response)
          );
        }
      });
  }
}
