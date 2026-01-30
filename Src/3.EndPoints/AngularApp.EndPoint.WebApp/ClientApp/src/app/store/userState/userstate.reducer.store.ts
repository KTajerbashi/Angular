import { createReducer, on } from '@ngrx/store';
import { ProfileState } from './userstate.state.store';
import {
  loadProfile,
  loadProfileFaild,
  loadProfileSuccess,
  login,
  loginFaild,
  loginSuccess,
  logout,
} from './userstate.action.store';
import IProfileDTO from '../../models/IUserProfile.dto';

// Step 3
export const UserStateReducer = createReducer(
  ProfileState,
  on(loadProfile, (state) => ({ ...state })),
  on(loadProfileSuccess, (state, action) => ({ ...state, ...action })),
  on(loadProfileFaild, (state, action) => ({
    ...state,
    loading: false,
    error: action.error,
    isAuthenticated: false,
  })),
  on(login, (state) => ({
    ...state,
    model: <IProfileDTO>{},
    isAuthenticated: true,
    loading: true,
    error: null,
  })),
  on(loginSuccess, (state, action) => ({
    ...state,
    model: action.model,
    isAuthenticated: true,
    loading: false,
  })),
  on(loginFaild, (state, action) => ({
    ...state,
    loading: false,
    error: action.error,
  })),
  on(logout, () => ProfileState),
);
