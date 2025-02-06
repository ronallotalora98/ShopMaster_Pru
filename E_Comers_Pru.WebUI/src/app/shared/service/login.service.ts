import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { LoginRequestVM, LoginResponseVM } from '../Models/autg.model';
import { IResponseVM } from '../Models/response.api';
import { environment } from 'src/environments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private token: string | null = null;
  private authStatusListener = new BehaviorSubject<boolean>(this.isAuthenticated())

  constructor(private http: HttpClient) { }


  login(loginRequest: LoginRequestVM): Observable<void> {
    return this.http.post<IResponseVM<LoginResponseVM>>(`${environment.apiUrl}/Login/auth-login`, loginRequest)
      .pipe(
        map(response => {
          this.token = response.element.token;
          localStorage.setItem('token', response.element.token);
          localStorage.setItem('user', JSON.stringify(response.element.user));
          this.authStatusListener.next(true);
        })
      );
  }

  logout() {
    this.token = null;
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authStatusListener.next(false);
  }

  getToken(): string | null {
    return this.token;
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }

  getAuthStatusListener(): Observable<boolean> {
    return this.authStatusListener.asObservable();
  }
}
