import { Routes, RouterModule, Route } from '@angular/router';
import { NgModule } from '@angular/core';
import { AdminLoginFormComponent } from './components/admin-login-form/admin-login-form.component';



const routes: Routes = [
   {
       path:"",
       component:AdminLoginFormComponent
   },
   
];



@NgModule({
    exports: [RouterModule],
    imports: [RouterModule.forChild(routes)]
})

export class AdminPanelRoutingModule { }
