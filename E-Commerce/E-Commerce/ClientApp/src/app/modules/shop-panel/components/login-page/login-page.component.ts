import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from '../../../../app.state';
import { LoginStateModel } from '../../../../models/login-state.model';
import { LoginModel } from '../../../../models/login.model';
import { AuthService } from '../../../../services/auth.service';
import * as LoginStateActions from '../../../../login.actions';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

 
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;

  constructor(
      private formBuilder: FormBuilder,
      private router: Router,
      private authenticationService: AuthService,
      private store:Store<AppState>,
      private _snackBar:MatSnackBar
  ) {}

  ngOnInit() {
      this.loginForm = this.formBuilder.group({
          email: ['', Validators.required],
          password: ['', Validators.required]
      });

  }


  onSubmit() {
      
      let model : LoginModel={
        email:this.loginForm.value.email,
        password:this.loginForm.value.password 
      }
     
      this.authenticationService.login(model).subscribe(response=>
      { 
        if(response.token)
        {
          
          this.router.navigateByUrl("");
        }
       
        
      });
          
  }

}
