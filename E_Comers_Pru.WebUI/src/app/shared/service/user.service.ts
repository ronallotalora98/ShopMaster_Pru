import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto } from 'src/app/mantainer/models/user.model';
import { IResponseVM } from '../Models/response.api';
import { environment } from 'src/environments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor(private http: HttpClient) { }

public getUser(): Observable<IResponseVM<UserDto[]>> {
  return this.http.get<IResponseVM<UserDto[]>>(
    `${environment.apiUrl}/User/getUsers`);
}

public createUser(category: UserDto): Observable<UserDto> {
  return this.http.post<UserDto>(
    `${environment.apiUrl}/User/create`, category);
}
}
