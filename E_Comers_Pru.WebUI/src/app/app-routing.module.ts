import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutPageComponent } from './layout/pages/layout-page/layout-page.component';
import { HomePagesComponent } from './home/pages/home-pages/home-pages.component';
import { UserPageComponent } from './mantainer/pages/user-page/user-page.component';
import { RolePageComponent } from './mantainer/pages/Role-page/Role-page.component';
import { OfferPageComponent } from './mantainer/pages/offer-page/offer-page.component';
import { CategoryPageComponent } from './mantainer/pages/category-page/category-page.component';
import { ProductPageComponent } from './mantainer/pages/product-page/product-page.component';
import { LoginComponent } from './auth/login/login.component';
import { validatorAccessRouterGuard } from './auth/service/aut.guard';

export const routes: Routes = [
  {path:'home', component:LayoutPageComponent,
    canMatch:[validatorAccessRouterGuard],
    children:[
      {path:'', component: HomePagesComponent}
    ]
  },
  {path:'mantenedores', component:LayoutPageComponent,
     canMatch:[validatorAccessRouterGuard],
    children:[
      {path:'usuario', component:UserPageComponent},
      {path:'rol', component:RolePageComponent},
      {path:'promocion', component:OfferPageComponent},
      {path:'categoria', component:CategoryPageComponent},
      {path:'producto', component:ProductPageComponent},
    ]
  },
  {
    path:'', component:LoginComponent
  }
];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
