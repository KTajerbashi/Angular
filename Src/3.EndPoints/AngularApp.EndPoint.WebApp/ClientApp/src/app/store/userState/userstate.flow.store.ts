import {
  createAction,
  createFeatureSelector,
  createReducer,
  createSelector,
  on,
  props,
} from '@ngrx/store';
import { IProfileStateModel } from './userstate.state.model';
import IProfileDTO from '../../models/IUserProfile.dto';
import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { AccountService } from '../../services/account.service';
import { catchError, exhaustMap, map, of } from 'rxjs';

//  1.Create State
export const ProfileState: IProfileStateModel = {
  data: undefined,
  errorMessage: '',
};
//  2.Create Action
export const LOAD_PROFILE = '[profile] Load Profile ℹ️';
export const LOAD_PROFILE_SUCCESS = '[profile] Load Profile Success ✔️';
export const LOAD_PROFILE_FAIL = '[profile] Load Profile Faild ❌';

export const loadProfile = createAction(LOAD_PROFILE);
export const loadProfileSuccess = createAction(
  LOAD_PROFILE_SUCCESS,
  props<{ data: IProfileDTO }>(),
);
export const loadProfileFail = createAction(LOAD_PROFILE_FAIL, props<{ errors: string }>());
//  3.Create Reducre
const _profileReducer = createReducer(
  ProfileState,
  on(loadProfileSuccess, (state, action) => {
    return {
      ...state,
      data: action.data,
      errorMessage: '',
    };
  }),
  on(loadProfileFail, (state, action) => {
    return {
      ...state,
      data: undefined,
      errorMessage: action.errors,
    };
  }),
);
export function PrfileReducer(state: any, action: any) {
  return _profileReducer(state, action);
}
//  4.Create Effect

@Injectable()
export class ProfileEffect {
  action$ = inject(Actions);
  service = inject(AccountService);

  _loadProfile$ = createEffect(() =>
    this.action$.pipe(
      ofType(loadProfile),
      exhaustMap((action) =>
        this.service.loadProfile().pipe(
          map((response) => loadProfileSuccess({ data: response as IProfileDTO })),
          catchError((err) => of(loadProfileFail({ errors: err }))),
        ),
      ),
    ),
  );
}
//  5.Create Selector
const loadProfileState = createFeatureSelector<IProfileStateModel>('profileStore');
export const loadProfileModel = createSelector(loadProfileState, (state) => {
  return state.data;
});
