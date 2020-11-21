import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { ShopPanelRoutingModule } from './shop-panel-routing.module';
import { BasketComponent } from './components/basket/basket.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { BasketItemComponent } from './components/basket-item/basket-item.component';
import {MatSelectModule} from '@angular/material/select';
import { MainpageComponent } from './components/mainpage/mainpage.component'
import { MatCarouselModule } from '@ngmodule/material-carousel';
import { ShopBaseComponent } from './components/shop-base/shop-base.component';
import { NavbarComponent } from './components/navbar/navbar.component'
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { SharedModule } from '../shared/shared.module';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { LaptopsComputersComponent } from './components/laptops-computers/laptops-computers.component';
import { SmartfonSmartwatchComponent } from './components/smartfon-smartwatch/smartfon-smartwatch.component';
import { GamingStreamingComponent } from './components/gaming-streaming/gaming-streaming.component';
import { ComputerPartsComponent } from './components/computer-parts/computer-parts.component';
import { RtvAgdComponent } from './components/rtv-agd/rtv-agd.component';
import { TvAudioComponent } from './components/tv-audio/tv-audio.component';
import { SmarthomeLifestyleComponent } from './components/smarthome-lifestyle/smarthome-lifestyle.component';
import { AccesoriesComponent } from './components/accesories/accesories.component';

@NgModule({
  declarations: [
    BasketComponent,
     BasketItemComponent, 
     MainpageComponent, 
     ShopBaseComponent, 
     NavbarComponent, 
     RegisterFormComponent,
     LoginPageComponent,
     LaptopsComputersComponent,
     SmartfonSmartwatchComponent,
     GamingStreamingComponent,
     ComputerPartsComponent,
     RtvAgdComponent,
     TvAudioComponent,
     SmarthomeLifestyleComponent,
     AccesoriesComponent
    ],
  imports: [
    ShopPanelRoutingModule,
    SharedModule,
    
  ],
  exports:
  [
    MatFormFieldModule,
    MatToolbarModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatSelectModule,
    MatCarouselModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule
  ],
  entryComponents:[]
})
export class ShopPanelModule {}
