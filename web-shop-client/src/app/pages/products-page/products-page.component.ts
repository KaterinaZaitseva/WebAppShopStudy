import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IProductModel } from 'src/app/models/product-model';
import { ProductsService } from 'src/app/services/products.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';

@Component({
  selector: 'app-products-page',
  templateUrl: './products-page.component.html',
  styleUrls: ['./products-page.component.css']
})
export class ProductsPageComponent implements OnInit {

  constructor(
    private tokenStorageService: TokenStorageService,
    private productsService: ProductsService
  ) { }

  products$: Observable<IProductModel[]>;
  adminCheck: boolean; 
  term: string = '';
  
  ngOnInit(): void {
    this.adminCheck = (this.tokenStorageService.getUserRole() == 'admin')? true: false;
    this.products$ = this.productsService.getAll();
  }

}
