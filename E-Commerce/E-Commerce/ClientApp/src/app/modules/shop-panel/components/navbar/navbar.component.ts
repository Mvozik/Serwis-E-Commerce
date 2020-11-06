import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from '../../../../app.state';
import * as LoginStateActions from '../../../../login.actions'
import { LoginStateModel } from '../../../../models/login-state.model';
import { AuthService } from '../../../../services/auth.service';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private authService:AuthService, private store:Store<AppState>)
  { 
    this.loginStatus = this.store.select("loginState");
    this.loginStatus.subscribe(response => {
      
      if(response.loginState=="1"){
      this.state = true;
      this.name = response.name;
      }
      if(response.loginState=="0"){
      
      this.state = false;
      this.name = response.name;
      }
      console.log(this.loginStatus);
  });

  }

  ngOnInit(): void {
  }

  loginStatus:Observable<LoginStateModel>;

  state:boolean;
  name:string;


  logout()
  {
    this.store.dispatch(new LoginStateActions.RemoveState());
    this.authService.logout();
  }

}
