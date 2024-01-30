import { Injectable } from '@angular/core';
import { IProductModel } from '../models/product-model';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

const KEY = 'Products'

@Injectable({
  providedIn: 'root'
})
export class ProductsCartStorageService {
 
  constructor(private cookieService: CookieService){}


  saveProducts(products: IProductModel[]){
    this.deleteProducts();
    this.cookieService.set(KEY, JSON.stringify(products));
  }

  deleteProducts(): void{
    this.cookieService.delete(KEY);
  }

  getProducts(): IProductModel[] {
    try {
      return JSON.parse(this.cookieService.get(KEY));
    } catch(Error){
      return [];
    }
  }
}
