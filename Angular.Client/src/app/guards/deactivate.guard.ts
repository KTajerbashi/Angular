import { CanDeactivateFn } from '@angular/router';
import { UserComponent } from '../components/pages/user/user.component';

export const deactivateGuard: CanDeactivateFn<UserComponent> = (
  component,
  currentRoute,
  currentState,
  nextState
) => {
  var result = confirm('Are You sure To Leave Page ?');
  return result;
};
