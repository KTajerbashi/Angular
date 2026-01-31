import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  let access = localStorage.getItem('access');
  console.log('authGuard : ', access == 'true');

  // const authService = inject(AuthService);
  const router = inject(Router);

  // if (authService.isLoggedIn()) {
  //   return true;
  // }
  if (access == 'true') {
    return true;
  }
  router.navigate(['/auth/login']);
  return false;
};
