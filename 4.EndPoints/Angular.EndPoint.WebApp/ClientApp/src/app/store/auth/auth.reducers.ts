// auth.reducer.ts
import { createReducer, on } from '@ngrx/store';
import * as AuthActions from './auth.actions';

export interface AuthState {
  isAuthenticated: boolean;
  token: string | null;
}

export const initialState: AuthState = {
  isAuthenticated: false,
  token: null,
};

export const authReducer = createReducer(
  initialState,
  on(AuthActions.login, (state, { token }) => ({
    ...state,
    isAuthenticated: true,
    token,
  })),
  on(AuthActions.logout, () => ({
    ...initialState,
  })),
  on(AuthActions.checkAuthSuccess, (state, { isAuthenticated }) => ({
    ...state,
    isAuthenticated,
  })),
  on(AuthActions.checkAuthFailure, () => ({
    ...initialState,
  }))
);
