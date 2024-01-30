import { Component, Input, ViewChild } from '@angular/core';
import { ProductsService } from 'src/app/services/products.service';
import { ProductFormComponent } from '../../forms/product-form/product-form.component';
import { IProductModel } from 'src/app/models/product-model';

@Component({
  selector: 'app-modal-edit-product',
  templateUrl: './modal-edit-product.component.html'
})
export class ModalEditProductComponent {
  
  constructor(
    private productsService: ProductsService,
  ) {}


  isVisible = false;

  product: IProductModel
  @ViewChild(ProductFormComponent) productForm: ProductFormComponent | undefined


  showModal(product: IProductModel): void {
    this.isVisible = true;
    this.product = product;
  }

  handleOk(): void {
    if(!this.productForm?.submitForm())
      return;
      
    this.productsService.update(this.product).subscribe();
    this.isVisible = false;
  }

  handleCancel(): void {
    this.isVisible = false;
  }

}
