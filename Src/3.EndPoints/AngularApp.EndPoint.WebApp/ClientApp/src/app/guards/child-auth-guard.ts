import { CanActivateChildFn } from '@angular/router';

export const childAuthGuard: CanActivateChildFn = (route, state) => {
  console.log("Child Auth Guard Invoked",route,state);
  return true;
};
