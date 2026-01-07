import { CanDeactivateFn } from '@angular/router';
import { GuardsIntro } from '../page/guards-intro/guards-intro';

export const canDeactivateGuard: CanDeactivateFn<GuardsIntro> = (component, currentRoute, currentState, nextState) => {
  return component.canNavigate();
};
