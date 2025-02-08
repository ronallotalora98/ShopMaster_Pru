import { inject, Injectable } from '@angular/core';
import {CanActivateFn, Router} from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from 'src/app/shared/service/login.service';

export const validatorAccessRouterGuard: CanActivateFn = (route) => {
  const router = inject(Router);
  const loginService = inject(LoginService);
  if (loginService.isAuthenticated()) {
    return true;
  }
  else {
    return router.parseUrl('');
  }
};

export const validatorAccessRouterGuardWithoutPermissions: CanActivateFn = (route) => {
  const router = inject(Router);
  const loginService = inject(LoginService);
  if (loginService.isAuthenticated())
    return true;
  else
    return router.parseUrl('');
};

// export class AuthGuard implements CanMatch {

//   constructor(private authService: LoginService, private router: Router) { }

//   canMatch(route: Route, segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
//     if (this.authService.isAuthenticated()) {
//       return true;
//     } else {
//       this.router.navigate(['']);
//       return false;
//     }
//   }
// }
