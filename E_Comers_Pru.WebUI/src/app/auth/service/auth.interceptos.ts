import { inject, Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpInterceptorFn, HttpHandlerFn } from '@angular/common/http';

import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { LoginService } from 'src/app/shared/service/login.service';

export const authInterceptorInterceptor: HttpInterceptorFn = (request: HttpRequest<any>, next: HttpHandlerFn): Observable<HttpEvent<any>> => {
  const loginService = inject(LoginService);
  const accessToken = localStorage.getItem('accessToken');
  if (accessToken) {
    request = addToken(request, accessToken);
  }
  return next(request).pipe(
    catchError((error) => {
      if (error.status === 401 && accessToken) {
        return handleTokenExpired(request, next, loginService);
      }
      return throwError(error);
    })
  );
};
export function addToken(request: HttpRequest<any>, token: string): HttpRequest<any> {
  console.log(token)
  return request.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`,
    },
  });
}

export function handleTokenExpired(request: HttpRequest<any>, next: HttpHandlerFn, loginService: LoginService): Observable<HttpEvent<any>> {
  return loginService.refreshAccessToken().pipe(
    switchMap(() => {
      const newAccessToken = localStorage.getItem('accessToken') as string;
      return next(addToken(request, newAccessToken));
    }),
    catchError((error) => {
      console.error('Error handling expired access token:', error);
      return throwError(error);
    })
  );
}

// @Injectable()
// export class AuthInterceptor implements HttpInterceptor {

//   constructor(private authService: LoginService) { }

//   intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//     const token = this.authService.getToken();
//     if (token) {
//       const cloned = req.clone({
//         headers: req.headers.set('Authorization', `Bearer ${token}`)
//       });
//       return next.handle(cloned);
//     } else {
//       return next.handle(req);
//     }
//   }
// }
