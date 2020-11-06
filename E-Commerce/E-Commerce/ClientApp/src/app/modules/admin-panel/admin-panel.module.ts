import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminPanelRoutingModule } from "./admin-panel-routing.module";
import { AdminLoginFormComponent } from './components/admin-login-form/admin-login-form.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { AdminNavBarComponent } from './components/admin-nav-bar/admin-nav-bar.component';
import { AddAdvertFormComponent } from './components/add-advert-form/add-advert-form.component';
import { MatCardModule } from '@angular/material/card';
import {  MatFormFieldModule } from '@angular/material/form-field';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [AdminLoginFormComponent, AdminDashboardComponent, AdminNavBarComponent, AddAdvertFormComponent],
  imports: [
    MatCardModule,
    MatFormFieldModule,
    CommonModule,
    AdminPanelRoutingModule,
    SharedModule
  ]
})
export class AdminPanelModule { }
