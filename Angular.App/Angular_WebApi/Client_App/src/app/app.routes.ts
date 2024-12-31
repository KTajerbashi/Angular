import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { NotFoundComponent } from './features/error-pages/not-found/not-found.component';
import { ServerErrorComponent } from './features/error-pages/server-error/server-error.component';
import { UnauthorizedComponent } from './features/error-pages/unauthorized/unauthorized.component';
import { GeneralLayoutComponent } from './layouts/general-layout/general-layout.component';
import { AuthGuard } from './core/guards/auth.guard';
import { LoginComponent } from './features/auth/login/login.component';
import { SigninComponent } from './features/auth/signin/signin.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { ProfileComponent } from './features/dashboard/profile/profile.component';
export const routes: Routes = [
  {
    path: '',
    component: GeneralLayoutComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'signin', component: SigninComponent },
    ],
  },
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'dashboard',
        component: MainLayoutComponent,
      },
      {
        path: 'admin',
        component: DashboardComponent,
        children: [{ path: 'profile', component: ProfileComponent }],
      },
      { path: '404', component: NotFoundComponent },
      { path: '500', component: ServerErrorComponent },
      { path: '401', component: UnauthorizedComponent },
      { path: '**', redirectTo: '404' },
    ],
  },
  { path: '**', redirectTo: 'login' },
];
