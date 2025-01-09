// auth.effects.ts
import * as AuthActions from './auth.actions';
import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, switchMap } from 'rxjs';
import { AuthService } from '../../core/services/auth.service';

@Injectable()
export class AuthEffects {
  actions$ = inject(Actions);
  constructor(private authService: AuthService) {}

  checkAuth$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.checkAuth),
      switchMap(() =>
        this.authService.checkAuth().pipe(
          map((isAuthenticated) => {
            var res = isAuthenticated.data;
            return AuthActions.checkAuthSuccess({ isAuthenticated: res });
          }),
          catchError(() => of(AuthActions.checkAuthFailure()))
        )
      )
    )
  );
}
