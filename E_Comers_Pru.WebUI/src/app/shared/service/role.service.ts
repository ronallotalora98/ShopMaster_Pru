import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResponseVM } from '../Models/response.api';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/enviroment';
import { RoleDto } from 'src/app/mantainer/models/role.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private http: HttpClient) { }

  public getRoles(): Observable<IResponseVM<RoleDto[]>> {
    return this.http.get<IResponseVM<RoleDto[]>>(
      `${environment.apiUrl}/Role/getRoles`);
  }

  public createRole(category: RoleDto): Observable<RoleDto> {
    return this.http.post<RoleDto>(
      `${environment.apiUrl}/Role/create`, category);
  }
}
