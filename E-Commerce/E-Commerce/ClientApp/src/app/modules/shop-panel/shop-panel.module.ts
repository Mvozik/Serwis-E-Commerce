import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { ShopPanelRoutingModule } from './shop-panel-routing.module';
import { BasketComponent } from './components/basket/basket.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { BasketItemComponent } from './components/basket-item/basket-item.component';
import { MatSelectModule } from '@angular/material/select';
import { MainpageComponent } from './components/mainpage/mainpage.component';
import { MatCarouselModule } from '@ngmodule/material-carousel';
import { ShopBaseComponent } from './components/shop-base/shop-base.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { SharedModule } from '../shared/shared.module';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { ProductsComponent } from './components/products/products.component';
import { OrderComponent } from './components/order/order.component';
import { MatStepperModule } from '@angular/material/stepper';
import { MatRadioModule } from '@angular/material/radio';
import { MatListModule } from '@angular/material/list';

@NgModule({
  declarations: [
    BasketComponent,
    BasketItemComponent,
    MainpageComponent,
    ShopBaseComponent,
    NavbarComponent,
    RegisterFormComponent,
    LoginPageComponent,
    ProductsComponent,
    OrderComponent,
  ],
  imports: [
    ShopPanelRoutingModule,
    SharedModule,
    MatStepperModule,
    MatRadioModule,
    MatListModule,
  ],
  exports: [
    MatFormFieldModule,
    MatToolbarModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatSelectModule,
    MatCarouselModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
  ],
  entryComponents: [],
})
export class ShopPanelModule {}
