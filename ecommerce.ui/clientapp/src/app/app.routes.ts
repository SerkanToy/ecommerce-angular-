import { Routes } from '@angular/router';
import { Home } from './home/home';
import { NotFound } from './not-found/not-found';

export const routes: Routes = [
    {path:"",component:Home},
    {path:"account",loadChildren: () => import("./account/routes").then(p => p.accountRoutes)},
    {path:"product",loadChildren: () => import("./product/routes").then(p => p.productRoutes)},
    {path:"not-found",component:NotFound},
    {path:"**",component:NotFound,pathMatch:'full'},
];
