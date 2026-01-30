// Step 4

import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import {
  loadProfile,
  loadProfileFaild,
  loadProfileSuccess,
  login,
  loginFaild,
  loginSuccess,
} from './userstate.action.store';
import { AuthenticationService } from '../../services/authentication.service';
import { catchError, exhaustMap, map, of } from 'rxjs';

@Injectable()
export class UserStateEffect {
  actions$ = inject(Actions);
  authService = inject(AuthenticationService);

  // login$ = createEffect(() =>
  //   this.actions$.pipe(
  //     ofType(login),
  //     exhaustMap(({ username, password }) =>
  //       this.authService.login({ Username: username, Password: password, RememberMe: true }).pipe(
  //         map((param) => loginSuccess({ model: param })),
  //         catchError((err) => of(loginFaild({ error: err }))),
  //       ),
  //     ),
  //   ),
  // );

  login$ = createEffect(() =>
    this.actions$.pipe(
      ofType(login),
      exhaustMap(({ username, password }) =>
        this.authService.login({ Username: username, Password: password, RememberMe: true }).pipe(
          map((param) => loginSuccess({ model: param })),
          catchError((err) => of(loginFaild({ error: err.message || err }))),
        ),
      ),
    ),
  );
  loadProfile$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadProfile),
      exhaustMap(() =>
        this.authService.loadProfile().pipe(
          map((param) => loadProfileSuccess({ model: param })),
          catchError((err) => of(loadProfileFaild({ error: err.message || err }))),
        ),
      ),
    ),
  );
}
