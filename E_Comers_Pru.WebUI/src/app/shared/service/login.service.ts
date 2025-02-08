import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable, tap, throwError } from 'rxjs';
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



  // login(loginRequest: LoginRequestVM): Observable<IResponseVM<LoginResponseVM>> {
  //   return this.http.post<IResponseVM<LoginResponseVM>>(`${environment.apiUrl}/Login/auth-login`, loginRequest);
  // }

  login(loginRequest: LoginRequestVM): Observable<void> {
    return this.http.post<IResponseVM<LoginResponseVM>>(`${environment.apiUrl}/Login/auth-login`, loginRequest)
      .pipe(
        map(response => {
          this.token = response.element.token;
          localStorage.setItem('accessToken', response.element.token ?? "");
          localStorage.setItem('user', JSON.stringify(response.element.user));
          this.authStatusListener.next(true);
        })
      );
  }

  public refreshAccessToken(): Observable<IResponseVM<string>> {
    const accessToken = localStorage.getItem('accessToken') as string;
    return this.http.post<IResponseVM<string>>(`${environment.apiUrl}/Login/refresh-token`, { token : accessToken }).pipe(
        tap((response) => {
            localStorage.setItem('accessToken', response.element);
        }),
        catchError((error) => {
            console.error('Error refreshing access token:', error);
            return throwError(error);
        })
    );
}


  logout() {
    this.token = null;
    localStorage.removeItem('accessToken');
    localStorage.removeItem('user');
    localStorage.removeItem('userLogin');
    this.authStatusListener.next(false);
  }

  getToken(): string | null {
    return this.token;
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('accessToken');
  }

  getAuthStatusListener(): Observable<boolean> {
    return this.authStatusListener.asObservable();
  }
}
