import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app-component/app.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { AdminPanelModule } from './modules/admin-panel/admin-panel.module';
import { ShopPanelModule } from './modules/shop-panel/shop-panel.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from './services/auth.service';
import { TokenInterceptor } from './auth/token.interceptor';
import { MatCarouselModule } from '@ngmodule/material-carousel';
import { StoreModule } from '@ngrx/store';
import { loginReducer } from './reducers/login-state.reducer';
import { shoppingCartReducer } from './reducers/shopping-cart.reducer';
import { SharedModule } from './modules/shared/shared.module';
import { JwtModule } from '@auth0/angular-jwt';
import { RefreshTokenService } from './auth/refreshtoken.service';
@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    MatIconModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatCardModule,
    AdminPanelModule,
    ShopPanelModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatInputModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    MatButtonModule,
    MatCarouselModule.forRoot(),
    StoreModule.forRoot({
      loginState: loginReducer,
      shoppingCart: shoppingCartReducer,
    }),
    SharedModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('JWT_TOKEN');
        },
      },
    }),
  ],
  providers: [
    AuthService,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    RefreshTokenService,
  ],
  bootstrap: [AppComponent],
  exports: [],
})
export class AppModule {}
