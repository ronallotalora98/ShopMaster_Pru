import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResponseVM } from '../Models/response.api';
import { Observable } from 'rxjs';
import { ProductDto } from 'src/app/mantainer/models/product.model';
import { environment } from 'src/environments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  public getProducts(): Observable<IResponseVM<ProductDto[]>> {
    return this.http.get<IResponseVM<ProductDto[]>>(
      `${environment.apiUrl}/Product/getProducts`);
  }

  public createProduct(category: ProductDto): Observable<ProductDto> {
    return this.http.post<ProductDto>(
      `${environment.apiUrl}/Product/create`, category);
  }
}
