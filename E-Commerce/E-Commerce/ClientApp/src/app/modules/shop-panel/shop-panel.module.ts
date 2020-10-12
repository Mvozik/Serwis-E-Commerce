import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [FooterComponent],
  imports: [CommonModule, FooterComponent, MatCardModule],
})
export class ShopPanelModule {}
