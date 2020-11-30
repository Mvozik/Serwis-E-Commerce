import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { baseUrl } from '../../../../../environments/environment';
import { AppState } from '../../../../app.state';
import { UserInformationsModel } from '../../../../models/user-informations.model';
import { AuthService } from '../../../../services/auth.service';
import { PostOrderModel } from '../../models/post-order.model';
import { ShippingCompanyModel } from '../../models/shipping-company.model';
import { ShoppingCartModel } from '../../models/Shopping-cart.model';
import * as ShoppingCartActions from '../../../../actions/shoppingcart.actions' 

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  constructor(private authService:AuthService,private formBuilder: FormBuilder,private http:HttpClient,private store:Store<AppState>)
  { 
    this.userInfoForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      surName: ['', Validators.required],
      city: ['', Validators.required],
      street: ['', Validators.required],
      buildingNumber: ['', Validators.required],
      flatNumber: [''],
      postCode: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      nip: ['']
    });

    this.authService.getUserInformations().subscribe(response=>
      {
        this.userInfoForm.patchValue({
        "id":response.id,
        "name":response.name,
        "surName":response.surName,
        "city":response.city,
        "street":response.street,
        "buildingNumber":response.buildingNumber,
        "postCode":response.postCode,
        "phoneNumber":response.phoneNumber,
        "nip":response.nip,
        "flatNumber":response.flatNumber
      });
    
      });


      this.http.get<ShippingCompanyModel[]>(this.url+"ShippingCompany").subscribe(response=>this.shippingList=response);

      this.shoppingCard = this.store.select("shoppingCart");
      this.shoppingCard.subscribe(response=>{
        this.cart=response;
        this.sum=0;
        this.cart.shoppingCartItems.forEach(x=>
        {
          this.sum += x.product.price * x.quantity;
        }
      )
    }
    );
  }
  shoppingCard:Observable<ShoppingCartModel>;
  sum:number= 0;
  finalSum:number;
  cart : ShoppingCartModel;
  isShipping=false;
  url = baseUrl;
  userInfoForm:FormGroup;
  shippingList:ShippingCompanyModel[];

  shipping:ShippingCompanyModel;

  ngOnInit(): void {
    
  }

  submit()
  {
    let model : PostOrderModel={
      shippingCompany:this.shipping.companyName,
      shippingPrice:this.shipping.price,
    }
    this.http.post(this.url+"Order",model).subscribe(response=>this.store.dispatch(new ShoppingCartActions.ClearShoppingCart()));
  }

  calculateSum()
  {
    this.finalSum = this.sum+this.shipping.price;
  }

  changeShipping(event:ShippingCompanyModel)
  {
    this.shipping=event;
    this.isShipping=true;
  }

  putUserInfoForm()
  {
    if(this.userInfoForm.touched)
    {

    
    let model : UserInformationsModel = {
      id: this.userInfoForm.value.id,
      name: this.userInfoForm.value.name,
      surName: this.userInfoForm.value.surName,
      city: this.userInfoForm.value.city,
      street: this.userInfoForm.value.street,
      buildingNumber: this.userInfoForm.value.buildingNumber,
      flatNumber: this.userInfoForm.value.flatNumber,
      postCode: this.userInfoForm.value.postCode,
      phoneNumber: this.userInfoForm.value.phoneNumber,
      nip: this.userInfoForm.value.nip
    }
    this.authService.putUserInformations(model).subscribe(response=>console.log(response));
    }
  }
}
