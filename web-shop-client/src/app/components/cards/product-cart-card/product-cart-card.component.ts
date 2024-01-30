import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IProductModel } from 'src/app/models/product-model';
import { ProductsCartStorageService } from 'src/app/services/products-cart-storage.service';

@Component({
  selector: 'app-product-cart-card',
  templateUrl: './product-cart-card.component.html',
  styleUrls: ['./product-cart-card.component.css']
})
export class ProductCartCardComponent {

  constructor(
    private productsCartStorageService: ProductsCartStorageService
  ){}


  @Input() product: IProductModel;
  @Output() onDelete = new EventEmitter<IProductModel>();


  deleteFromCart(): void {
    this.onDelete.emit(this.product);
  }
  
}
