import { Routes, RouterModule, Route } from '@angular/router';
import { NgModule } from '@angular/core';
import { MainpageComponent } from './components/mainpage/mainpage.component';
import { ShopBaseComponent } from './components/shop-base/shop-base.component';
import { BasketComponent } from './components/basket/basket.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { LaptopsComputersComponent } from './components/laptops-computers/laptops-computers.component';
import { GamingStreamingComponent } from './components/gaming-streaming/gaming-streaming.component';
import { SmartfonSmartwatchComponent } from './components/smartfon-smartwatch/smartfon-smartwatch.component';
import { ComputerPartsComponent } from './components/computer-parts/computer-parts.component';
import { RtvAgdComponent } from './components/rtv-agd/rtv-agd.component';
import { SmarthomeLifestyleComponent } from './components/smarthome-lifestyle/smarthome-lifestyle.component';
import { AccesoriesComponent } from './components/accesories/accesories.component';



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
                path:"laptopy-komputery",
                component:LaptopsComputersComponent
            },
            {
                path:"smartfony-smartwatche",
                component:SmartfonSmartwatchComponent
            },
            {
                path:"gaming-streaming",
                component:GamingStreamingComponent
            },
            {
                path:"podzespoly-komputerowe",
                component:ComputerPartsComponent
            },
            {
                path:"urzadzenia-peryferyjne",
                component:RtvAgdComponent
            },
            {
                path:"tv-audio",
                component:RtvAgdComponent
            },
            {
                path:"smarthome-lifestyle",
                component:SmarthomeLifestyleComponent
            },
            {
                path:"akcesoria",
                component:AccesoriesComponent
            },
           
        ]
    },
    
];



@NgModule({
    exports: [RouterModule],
    imports: [RouterModule.forChild(routes)]
})

export class ShopPanelRoutingModule { }
