import { Routes, RouterModule, Route } from '@angular/router';
import { NgModule } from '@angular/core';
import { MainpageComponent } from './components/mainpage/mainpage.component';
import { ShopBaseComponent } from './components/shop-base/shop-base.component';
import { BasketComponent } from './components/basket/basket.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { ProductsComponent } from './components/products/products.component';
import { OrderComponent } from './components/order/order.component';
import { UserAccountComponent } from './components/user-account/user-account.component';
import { UserOrdersComponent } from './components/user-orders/user-orders.component';
import { UserBasketsComponent } from './components/user-baskets/user-baskets.component';
import { UserOptionsComponent } from './components/user-options/user-options.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';

const routes: Routes = [
  {
    path: '',
    component: ShopBaseComponent,
    children: [
      {
        path: '',
        component: MainpageComponent,
      },
      {
        path: 'koszyk',
        component: BasketComponent,
      },
      {
        path: 'rejestracja',
        component: RegisterFormComponent,
      },
      {
        path: 'logowanie',
        component: LoginPageComponent,
      },
      {
        path: 'produkty/:id',
        component: ProductsComponent,
      },
      {
        path: 'zamówienie',
        component: OrderComponent,
      },
      {
        path: 'konto',
        component: UserAccountComponent,
        children: [
          {
            path: 'zamówienia',
            component: UserOrdersComponent,
          },
          {
            path: 'koszyki',
            component: UserBasketsComponent,
          },
          {
            path: 'ustawienia',
            component: UserOptionsComponent,
          },
        ],
      },
      {
        path: 'produkt/:id',
        component: ProductDetailsComponent,
      },
    ],
  },
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forChild(routes)],
})
export class ShopPanelRoutingModule {}
