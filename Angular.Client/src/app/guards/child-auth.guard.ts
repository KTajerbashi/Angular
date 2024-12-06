import { CanActivateChildFn } from '@angular/router';

export const childAuthGuard: CanActivateChildFn = (childRoute, state) => {
  let isAccess = localStorage.getItem('access');
  if (isAccess === 'true') {
    return true;
  } else {
    alert('You Are Not Admin');
    return false;
  }
  return false;
};
