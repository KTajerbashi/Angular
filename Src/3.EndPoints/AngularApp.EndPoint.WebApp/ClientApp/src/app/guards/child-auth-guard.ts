import { inject } from '@angular/core';
import { CanActivateChildFn, Router } from '@angular/router';

export const childAuthGuard: CanActivateChildFn = (route, state) => {
  console.log("Child Auth Guard Invoked",route,state);
  return true;
};
