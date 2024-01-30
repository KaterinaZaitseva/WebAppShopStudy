import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { IProductModel } from 'src/app/models/product-model';
import { ModalEditProductComponent } from '../../modal/modal-edit-product/modal-edit-product.component';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ProductsService } from 'src/app/services/products.service';


@Component({
  selector: 'app-product-editable-card',
  templateUrl: './product-editable-card.component.html',
  styleUrls: ['./product-editable-card.component.css']
})
export class ProductEditableCardComponent {

  constructor(private nzMessageService: NzMessageService,
    private productsService: ProductsService) {}
  

  @Input() product: IProductModel;
  @Output() onChange : EventEmitter<any> = new EventEmitter();
  @Output() onEdit : EventEmitter<IProductModel> = new EventEmitter();
 

  updateProducts(): void {
    this.onChange?.emit();
  }

  editProduct(): void {
    this.onEdit?.emit(this.product);
  }

  cancelDelete(): void {
    this.nzMessageService.info('Cancellation of deletion');
  }

  confirmDelete(): void {
    this.nzMessageService.info('Successful deletion');
    this.productsService.delete(this.product.id!).subscribe(
      () => this.updateProducts()
    );
  }

}