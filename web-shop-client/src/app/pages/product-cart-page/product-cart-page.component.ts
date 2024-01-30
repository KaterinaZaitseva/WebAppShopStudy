import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ProductsUserComponent } from 'src/app/components/products-user/products-user.component';
import { IProductModel } from 'src/app/models/product-model';
import { ProductsCartStorageService } from 'src/app/services/products-cart-storage.service';

@Component({
  selector: 'app-product-cart',
  templateUrl: './product-cart-page.component.html',
  styleUrls: ['./product-cart-page.component.css']
})
export class ProductCartPageComponent implements OnInit{
  
  constructor(private productsCartStorageService: ProductsCartStorageService) {}

  
  productsCart: IProductModel[];

  @ViewChild(ProductsUserComponent) productUserPage: ProductsUserComponent | undefined;

  ngOnInit(): void {
    this.productsCart = this.productsCartStorageService.getProducts();
  }

  deleteFromCart(product: IProductModel){
    this.productsCart = this.productsCart.filter(p => p.id != product.id);
    this.productsCartStorageService.saveProducts(this.productsCart);
    this.productUserPage?.deleteFromCart;
  }

}
