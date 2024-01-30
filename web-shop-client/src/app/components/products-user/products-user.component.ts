import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IProductModel } from 'src/app/models/product-model';
import { ProductsCartStorageService } from 'src/app/services/products-cart-storage.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products-user',
  templateUrl: './products-user.component.html',
  styleUrls: ['./products-user.component.css']
})
export class ProductsUserComponent implements OnInit {
  
  constructor(
    public productsService: ProductsService,
    private productsCartStorageService: ProductsCartStorageService) { 
  }

  @Input() term: string;
  @Input() products$: Observable<IProductModel[]>;
  productsCart: IProductModel[] = [];
  

  ngOnInit(): void {
    this.products$ = this.productsService.getAll();
    this.productsCart = this.productsCartStorageService.getProducts();
  }

  addToCard(product: IProductModel): void {
    this.productsCart.push(product);
    this.productsCartStorageService.saveProducts(this.productsCart);
  }
  
  deleteFromCart(product: IProductModel){
    this.productsCart = this.productsCart.filter(p => p.id != product.id);
  }

}
