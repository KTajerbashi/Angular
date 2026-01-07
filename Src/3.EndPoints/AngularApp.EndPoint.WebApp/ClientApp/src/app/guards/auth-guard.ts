// Can Activate Guard
import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {

  return true;

  let router = inject(Router);




  let menu = route.url[0].path;
  console.log('Menu : ', menu);
  if (route.url.length > 0) {
    if (menu !== 'guards') {
      return true;
    }
    alert('Access to Guards page is restricted.');
    // router.navigate(['dashboard']);
    router.navigateByUrl('/dashboard');
    return false;
  }
  return true;
};
