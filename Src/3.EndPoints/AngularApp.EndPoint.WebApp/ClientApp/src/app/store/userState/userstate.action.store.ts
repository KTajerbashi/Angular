// Step 2

import { createAction, props } from '@ngrx/store';
import IProfileDTO from '../../models/IUserProfile.dto';

const LOADROFILE = '[Auth] Profile ℹ️';
const LOADROFILE_SUCCESS = '[Auth] Profile Success ✅';
const LOADROFILE_FAILD = '[Auth] Profile Faild ❌';

export const loadProfile = createAction(LOADROFILE, props<{ model: IProfileDTO }>());
export const loadProfileSuccess = createAction(LOADROFILE_SUCCESS, props<{ model: IProfileDTO }>());
export const loadProfileFaild = createAction(LOADROFILE_FAILD, props<{ error: string }>());


const LOGIN = '[Auth] Login ℹ️';
const LOGIN_SUCCESS = '[Auth] Login Success ✅';
const LOGIN_FAILD = '[Auth] Login Faild ❌';
const LOGOUT = '[Auth] Logout';


export const login = createAction(LOGIN, props<{ username: string; password: string }>());
export const loginSuccess = createAction(LOGIN_SUCCESS, props<{ model: IProfileDTO }>());
export const loginFaild = createAction(LOGIN_FAILD, props<{ error: string }>());
export const logout = createAction(LOGOUT);
