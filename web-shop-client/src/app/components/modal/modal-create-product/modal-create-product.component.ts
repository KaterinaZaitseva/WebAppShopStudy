import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { IProductModel } from 'src/app/models/product-model';
import { ProductsService } from 'src/app/services/products.service';
import { ProductFormComponent } from '../../forms/product-form/product-form.component';

@Component({
  selector: 'app-modal-create-product',
  templateUrl: './modal-create-product.component.html',
  styleUrls: ['./modal-create-product.component.css']
})
export class ModalCreateProductComponent {
  
  constructor(
    private productsService: ProductsService,
  ) {
  }

  isVisible = false;

  product: IProductModel = {
    name: '', 
    description: '', 
    price: 0, 
    pictureUrl: 'https://img.freepik.com/free-vector/page-found-concept-illustration_114360-1869.jpg'
  };
  @ViewChild(ProductFormComponent) productForm: ProductFormComponent | undefined
  @Output() onChange : EventEmitter<any> = new EventEmitter();

  showModal(): void {
    this.isVisible = true;
  }

  handleOk(): void {
    if(!this.productForm?.submitForm())
      return;
      
    console.log(this.product);

    this.productsService.create(this.product).subscribe(
     () => {
        this.productsService.getAll()
        this.onChange?.emit()
        console.log('emitted');
      }
    );
    this.isVisible = false;
  }

  handleCancel(): void {
    this.isVisible = false;
  }

}
