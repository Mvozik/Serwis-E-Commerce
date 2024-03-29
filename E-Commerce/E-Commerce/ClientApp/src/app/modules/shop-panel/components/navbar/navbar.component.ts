import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from '../../../../app.state';
import * as LoginStateActions from '../../../../actions/login.actions';
import { LoginStateModel } from '../../../../models/login-state.model';
import { AuthService } from '../../../../services/auth.service';
import { ShoppingCartModel } from '../../models/Shopping-cart.model';
import { consts } from '../../../.././CONST';
import { CategoryService } from 'src/app/modules/admin-panel/services/category.service';
import { SectionModel } from 'src/app/modules/admin-panel/models/section.model';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private store: Store<AppState>,
    private route: Router,
    private categoryService:CategoryService,
  ) {}

  ngOnInit(): void {
    this.loginStatus = this.store.select('loginState');
    this.loginStatus.subscribe((response) => {
      if (response.loginState == '1') {
        this.state = true;
        this.name = response.name;
        this.maticon = 'exit_to_app_outline';
        this.text = 'Wyloguj';
      }
      if (response.loginState == '0') {
        this.text = 'Moje konto';
        this.state = false;
        this.name = response.name;
        this.maticon = 'account_box_outline';
      }
    });
    
    this.categoryService.getSections().subscribe(response=>this.sections=response);
  }

  loginStatus: Observable<LoginStateModel>;
  text: string;
  state: boolean;
  name: string;
  maticon: string;
  sections:SectionModel[];
  click() {
    if (this.state) {
      this.store.dispatch(new LoginStateActions.RemoveState());
      this.authService.logout().subscribe();
    } else {
      this.route.navigateByUrl('logowanie');
    }
  }
}
