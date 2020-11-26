import { Routes, RouterModule, Route } from '@angular/router';
import { NgModule } from '@angular/core';
import { MainpageComponent } from './components/mainpage/mainpage.component';
import { ShopBaseComponent } from './components/shop-base/shop-base.component';
import { BasketComponent } from './components/basket/basket.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { ProductsComponent } from './components/products/products.component';




const routes: Routes = [
   
    {
        path:"",
        component:ShopBaseComponent,
        children:
        [
            {
                path:"",
                component:MainpageComponent
            },
            {
                path:"koszyk",
                component:BasketComponent
            },
            {
                path:"rejestracja",
                component:RegisterFormComponent
            },
            {
                path:"logowanie",
                component:LoginPageComponent
            },
            {
                path:"produkty/:id",
                component:ProductsComponent
            },
        ]
    },
    
];



@NgModule({
    exports: [RouterModule],
    imports: [RouterModule.forChild(routes)]
})

export class ShopPanelRoutingModule { }
