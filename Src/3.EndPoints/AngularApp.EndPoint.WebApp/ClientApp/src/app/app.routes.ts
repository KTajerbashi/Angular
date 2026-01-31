import { Routes } from '@angular/router';
import { AuthLayout } from './layouts/auth-layout/auth-layout';
import { MainLayout } from './layouts/main-layout/main-layout';
import { LoginComponent } from './features/auth/pages/login/login.component';
import { SignUpComponent } from './features/auth/pages/sign-up/sign-up.component';
import { ProfileComponent } from './features/auth/pages/profile/profile.component';
import { authGuard } from './core/guards/auth.guard';
import { authEntryGuard } from './core/guards/auth-entry.guard';

export const routes: Routes = [
  {
    path: 'auth',
    component: AuthLayout,
    canActivate: [authEntryGuard],
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'sign-up', component: SignUpComponent },
      {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [authGuard],
      },
    ],
  },
  {
    path: '',
    component: MainLayout,
    canActivate: [authEntryGuard],
    children: [],
  },
  { path: '**', redirectTo: 'auth/login' },
];
