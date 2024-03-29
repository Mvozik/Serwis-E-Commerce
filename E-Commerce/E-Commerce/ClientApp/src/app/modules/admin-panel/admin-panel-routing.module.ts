import { Routes, RouterModule, Route } from '@angular/router';
import { NgModule } from '@angular/core';
import { AdminLoginFormComponent } from './components/admin-login-form/admin-login-form.component';
import { AddAdvertFormComponent } from './components/add-advert-form/add-advert-form.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { ProductPanelComponent } from './components/product-panel/product-panel.component';
import { OrdersPanelComponent } from './components/orders-panel/orders-panel.component';
import { UsersPanelComponent } from './components/users-panel/users-panel.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { MainPageOptionsComponent } from './components/main-page-options/main-page-options.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { ActiveOrderListComponent } from './components/active-order-list/active-order-list.component';
import { RealizedOrderListComponent } from './components/realized-order-list/realized-order-list.component';

const routes: Routes = [
  {
    path: '',
    component: AdminDashboardComponent,
    children: [
      {
        path: 'produkty',
        component: ProductPanelComponent,
        children: [
          {
            path: '',
            component: ProductListComponent,
          },
          {
            path: 'dodaj',
            component: AddAdvertFormComponent,
          },
          {
            path: 'edytujprodukt/:id',
            component: ProductDetailsComponent,
          },
        ],
      },
      {
        path: 'zamówienia',
        component: OrdersPanelComponent,
        children: [
          {
            path: 'aktywne',
            component: ActiveOrderListComponent,
          },
          {
            path: 'zrealizowane',
            component: RealizedOrderListComponent,
          },
        ],
      },
      {
        path: 'użytkownicy',
        component: UsersPanelComponent,
      },
      {
        path: 'kategorie',
        component: CategoriesComponent,
      },
      {
        path: 'strona-glowna',
        component: MainPageOptionsComponent,
      },
    ],
  },
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forChild(routes)],
})
export class AdminPanelRoutingModule {}
