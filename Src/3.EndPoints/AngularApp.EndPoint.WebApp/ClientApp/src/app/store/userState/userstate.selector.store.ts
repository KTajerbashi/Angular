// Step 5

import { createFeatureSelector, createSelector } from '@ngrx/store';
import { IProfileStateModel } from './userstate.state.model';

export const SelectUserState = createFeatureSelector<IProfileStateModel>('UserState');

export const SelectUser = createSelector(SelectUserState, (state) => state.model.user);
export const SelectRole = createSelector(SelectUserState, (state) => state.model.role);
export const SelectUserRoles = createSelector(
  SelectUserState,
  (state) => state.model.userRoles,
);
export const SelectMenu = createSelector(SelectUserState, (state) => state.model.menus);
export const SelectRoles = createSelector(SelectUserState, (state) => state.model.roles);
export const SelectLoading = createSelector(SelectUserState, (state) => state.loading);
export const SelectError = createSelector(SelectUserState, (state) => state.error);
