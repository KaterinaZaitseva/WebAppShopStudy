import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IProductModel } from 'src/app/models/product-model';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent {
  @Input() product: IProductModel;
  @Output() onAdded: EventEmitter<IProductModel> =  new EventEmitter();

  addToCart(): void{
    this.onAdded?.emit(this.product);
  }
}
