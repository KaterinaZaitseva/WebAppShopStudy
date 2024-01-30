import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, tap } from "rxjs";
import { IProductModel } from "../models/product-model";

@Injectable({
    providedIn: 'root'
})
export class ProductsService{
    
    constructor(
        private httpClient: HttpClient,
    ) {}

    urlProduct: string = 'https://localhost:44351/api/Products';
    
    getAll(): Observable<IProductModel[]> {
        return this.httpClient.get<IProductModel[]>(this.urlProduct);
    }

    create(product: IProductModel): Observable<IProductModel> {
        return this.httpClient.post<IProductModel>(this.urlProduct, product)
    }

    update(product: IProductModel) {
        return this.httpClient.put<IProductModel>(this.urlProduct + '/' + product.id, product);
    }

    delete(id: number) {
        return this.httpClient.delete<IProductModel>(this.urlProduct + '/' + id);
    }
    
}