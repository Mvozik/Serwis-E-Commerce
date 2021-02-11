import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/app.state';
import { ShoppingCartModel } from '../../models/Shopping-cart.model';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import * as ShoppingCartActions from '../../../../actions/shoppingcart.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-baskets',
  templateUrl: './user-baskets.component.html',
  styleUrls: ['./user-baskets.component.scss'],
})
export class UserBasketsComponent implements OnInit {
  constructor(
    private ShoppingCartService: ShoppingCartService,
    private store: Store<AppState>,
    private router: Router
  ) {}
  id: number;
  shoppingCarts: ShoppingCartModel[] = [];
  displayedColumns: string[] = ['userId', 'shoppingCartItems', 'opcje'];
  dataSource = new MatTableDataSource<ShoppingCartModel>();
  ngOnInit(): void {
    this.ShoppingCartService.getAllShoppingCarts().subscribe((response) => {
      this.shoppingCarts = response;
      this.dataSource.data = response;
    });
  }

  deleteShoppingCart() {
    this.ShoppingCartService.deleteShoppingCart(this.id).subscribe(
      (response) => {
        let newData = this.dataSource.data.filter((x) => x.id !== response);
        this.dataSource.data = newData;
      }
    );
  }
  setShoppingCartToActive() {
    this.ShoppingCartService.changeActiveShoppingCart(this.id).subscribe(
      (response) => {
        this.store.dispatch(new ShoppingCartActions.SetShoppingCart(response));
        this.router.navigate(['koszyk']);
      }
    );
  }
  setId(id: number) {
    this.id = id;
    console.log(this.id);
  }
}
