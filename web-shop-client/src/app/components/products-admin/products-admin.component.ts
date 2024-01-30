import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { IProductModel } from 'src/app/models/product-model';
import { ProductsService } from 'src/app/services/products.service';
import { ModalEditProductComponent } from '../modal/modal-edit-product/modal-edit-product.component';

@Component({
  selector: 'app-products-admin',
  templateUrl: './products-admin.component.html',
  styleUrls: ['./products-admin.component.css']
})
export class ProductsAdminComponent implements OnInit{

  constructor(public productsService: ProductsService) { }
  

  @Input() term: string;
  @Input() products$: Observable<IProductModel[]>;
  @ViewChild(ModalEditProductComponent) editModal: ModalEditProductComponent | undefined

  
  
  ngOnInit(): void {
    this.updateProducts();
  }

  updateProducts(): void {
    this.products$ = this.productsService.getAll();
  }

  editProduct(product: IProductModel): void {
    this.editModal?.showModal(product);
  }
}
