import en from '@angular/common/locales/en';
import { en_US } from 'ng-zorro-antd/i18n';

import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, registerLocaleData } from '@angular/common';

import { CookieService } from 'ngx-cookie-service';
import { AuthorizationService } from './services/authorization.service';
import { UsersService } from './services/users.service';
import { ProductsService } from './services/products.service';
import { TokenStorageService } from './services/token-storage.service';
import { AuthorizarionInterceptor } from './interceptors/authorization-interceptor';

import { AppComponent } from './app.component';
import { ProductCardComponent } from './components/cards/product-card/product-card.component';
import { ProductEditableCardComponent } from './components/cards/product-editable-card/product-editable-card.component';
import { ProductFormComponent } from './components/forms/product-form/product-form.component';
import { LayoutComponent } from './components/layout/layout.component';
import { UserFormComponent } from './components/forms/user-form/user-form.component';
import { ProductCartCardComponent } from './components/cards/product-cart-card/product-cart-card.component';
import { ProductsAdminComponent } from './components/products-admin/products-admin.component';
import { ProductsUserComponent } from './components/products-user/products-user.component';

import { ModalEditProductComponent } from './components/modal/modal-edit-product/modal-edit-product.component';
import { ModalCreateProductComponent } from './components/modal/modal-create-product/modal-create-product.component';

import { ProductsPageComponent } from './pages/products-page/products-page.component';
import { AuthorizationPageComponent } from './pages/authorization-page/authorization-page.component';
import { ProductCartPageComponent } from './pages/product-cart-page/product-cart-page.component';
import { RegistrationPageComponent } from './pages/registration-page/registration-page.component';

import { FilterProductsPipe } from './pipes/filter-products.pipe';

import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NgModule } from '@angular/core';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzDrawerModule } from 'ng-zorro-antd/drawer';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzPopconfirmModule } from 'ng-zorro-antd/popconfirm';
import { NzNotificationModule } from 'ng-zorro-antd/notification';

import { NzMessageService } from 'ng-zorro-antd/message';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { UserProfilePageComponent } from './pages/user-profile-page/user-profile-page.component';
import { UsersPageComponent } from './pages/users-page/users-page.component';
import { FilterUsersPipe } from './pipes/filter-users.pipe';
import { UserCardComponent } from './components/cards/user-card/user-card.component';
import { ErrorHandlerInterceptor } from './interceptors/error-handler-interceptor';

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    AuthorizationPageComponent,
    ProductsPageComponent,
    ProductCardComponent,
    ProductEditableCardComponent,
    ProductFormComponent,
    ModalEditProductComponent,
    ModalCreateProductComponent,
    FilterProductsPipe,
    RegistrationPageComponent,
    UserFormComponent,
    LayoutComponent,
    ProductCartCardComponent,
    ProductCartPageComponent,
    ProductsAdminComponent,
    ProductsUserComponent,
    UserProfilePageComponent,
    UsersPageComponent,
    FilterUsersPipe,
    UserCardComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NzLayoutModule,
    NzMenuModule,
    NzBreadCrumbModule,
    NzCardModule,
    NzIconModule,
    NzFormModule,
    NzInputModule,
    ReactiveFormsModule,
    NzButtonModule,
    NzCheckboxModule,
    NzDrawerModule,
    NzModalModule,
    NzInputNumberModule,
    NzAvatarModule,
    NzPopconfirmModule,
    NzBadgeModule,
    NzNotificationModule,
  ],
  providers: [
    { 
      provide: NZ_I18N, useValue: en_US 
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizarionInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerInterceptor,
      multi: true
    },
    UsersService,
    ProductsService,
    AuthorizationService,
    CookieService,
    TokenStorageService,
    NzMessageService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
