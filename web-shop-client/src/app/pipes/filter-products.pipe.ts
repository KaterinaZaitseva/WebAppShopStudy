import { Pipe, PipeTransform } from '@angular/core';
import { IProductModel } from '../models/product-model';

@Pipe({
  name: 'filterProducts'
})
export class FilterProductsPipe implements PipeTransform {

  transform(products: IProductModel[], search: string): IProductModel[] {
    if(search.length === 0) return products
    return products.filter(p => p.name.toLowerCase().includes(search.toLowerCase()));
  }

}
