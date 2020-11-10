import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminPanelRoutingModule } from "./admin-panel-routing.module";
import { AdminLoginFormComponent } from './components/admin-login-form/admin-login-form.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { AdminNavBarComponent } from './components/admin-nav-bar/admin-nav-bar.component';
import { AddAdvertFormComponent } from './components/add-advert-form/add-advert-form.component';
import { SharedModule } from '../shared/shared.module';
import { NgxMatFileInputModule } from '@angular-material-components/file-input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ProductPanelComponent } from './components/product-panel/product-panel.component';
import { OrdersPanelComponent } from './components/orders-panel/orders-panel.component';
import { UsersPanelComponent } from './components/users-panel/users-panel.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { AdvertCardComponent } from './components/advert-card/advert-card.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component'

@NgModule({
  declarations: [AdminLoginFormComponent, AdminDashboardComponent, AdminNavBarComponent, AddAdvertFormComponent, ProductPanelComponent, OrdersPanelComponent, UsersPanelComponent, ProductListComponent, AdvertCardComponent, ProductDetailsComponent],
  imports: [
    CommonModule,
    AdminPanelRoutingModule,
    SharedModule,
    NgxMatFileInputModule,
    MatSidenavModule
  ]
})
export class AdminPanelModule { }
