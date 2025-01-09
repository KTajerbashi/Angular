// auth.actions.ts
import { createAction, props } from '@ngrx/store';

export const login = createAction('[Auth] Login', props<{ token: string }>());
export const logout = createAction('[Auth] Logout');
export const checkAuth = createAction('[Auth] Check Auth');
export const checkAuthSuccess = createAction(
  '[Auth] Check Auth Success',
  props<{ isAuthenticated: boolean }>()
);
export const checkAuthFailure = createAction('[Auth] Check Auth Failure');
