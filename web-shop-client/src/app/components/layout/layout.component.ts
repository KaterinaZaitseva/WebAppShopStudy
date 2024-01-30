import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { IUserAuthorizationModel } from 'src/app/models/user-authorization.model';
import { ProductCartPageComponent } from 'src/app/pages/product-cart-page/product-cart-page.component';
import { AuthorizationService } from 'src/app/services/authorization.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { ProductsUserComponent } from '../products-user/products-user.component';
import { ProductsCartStorageService } from 'src/app/services/products-cart-storage.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit{
  
  constructor(private tokenStorageService: TokenStorageService, 
    private authorizationService: AuthorizationService,
    private router: Router,
    public cartStorageService: ProductsCartStorageService,
  ){ }

  userName: string;
  role: string;
  adminCheck: boolean; 
  
  
  ngOnInit(): void {
    this.userName = this.tokenStorageService.getUserLogin();
    this.role = this.tokenStorageService.getUserRole();
    this.adminCheck = (this.role == 'admin')? true: false;
  }
  
  logOut(): void {
    this.authorizationService.logOut();
    this.router.navigate(['/authorize']);
  }
}
