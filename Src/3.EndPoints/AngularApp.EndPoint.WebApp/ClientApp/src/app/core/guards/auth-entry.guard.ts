import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authEntryGuard: CanActivateFn = (route, state) => {
  let access = localStorage.getItem('access');
  console.log('authEntryGuard : ', access == 'true');

  // const authService = inject(AuthService);
  const router = inject(Router);

  // if (authService.isLoggedIn()) {
  if (access == 'true') {
    router.navigate(['/auth/profile']);
  } else {
    router.navigate(['/auth/login']);
  }

  return false; // block /auth itself
};
