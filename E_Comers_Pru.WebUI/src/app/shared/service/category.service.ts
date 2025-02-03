import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/enviroment';
import { Observable } from 'rxjs';
import { IResponseVM } from '../Models/response.api';
import { CategoryDto } from 'src/app/mantainer/models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {


  constructor(private http: HttpClient) { }

  public getCategories(): Observable<IResponseVM<CategoryDto[]>> {
    return this.http.get<IResponseVM<CategoryDto[]>>(
      `${environment.apiUrl}/Category/getCategories`);
  }

  public createCategory(category: CategoryDto): Observable<CategoryDto> {
    return this.http.post<CategoryDto>(
      `${environment.apiUrl}/Category/getCategories`, category);
  }

}
