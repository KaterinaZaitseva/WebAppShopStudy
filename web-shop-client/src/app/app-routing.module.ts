import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationPageComponent } from './pages/authorization-page/authorization-page.component';
import { ProductsPageComponent } from './pages/products-page/products-page.component';
import { RegistrationPageComponent } from './pages/registration-page/registration-page.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ProductCartPageComponent } from './pages/product-cart-page/product-cart-page.component';
import { UserProfilePageComponent } from './pages/user-profile-page/user-profile-page.component';
import { UsersPageComponent } from './pages/users-page/users-page.component';

const itemRoutes: Routes = [
  { path: 'users', component: UsersPageComponent},
  { path: 'products', component: ProductsPageComponent},
  { path: 'cart', component: ProductCartPageComponent},
  { path: 'profile', component: UserProfilePageComponent},
]

const appRoutes: Routes = [    
  { path: 'authorize', component: AuthorizationPageComponent},
  { path: 'register', component: RegistrationPageComponent},
  { path: 'home', component: LayoutComponent, children: itemRoutes},
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { } 