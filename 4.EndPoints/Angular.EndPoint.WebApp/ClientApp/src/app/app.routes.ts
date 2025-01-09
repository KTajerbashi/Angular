import { Routes } from '@angular/router';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { ProfileComponent } from './features/profile/profile.component';
import { LoginComponent } from './features/auth/login/login.component';
import { SigninComponent } from './features/auth/signin/signin.component';
import { AuthGuard } from './core/guards/auth.guard';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { UserManagerComponent } from './layouts/admin-layout/user-manager/user-manager.component';
import { NotFoundPageComponent } from './features/pages/common/not-found-page/not-found-page.component';
import { InternalServerComponent } from './features/pages/common/internal-server/internal-server.component';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: DashboardComponent,
        // loadChildren: () =>import('../features/dashboard/dashboard.module').then((m) => m.DashboardModule),
      },
      {
        path: 'profile',
        component: ProfileComponent,
        // loadChildren: () => import('../features/profile/profile.module').then((m) => m.ProfileModule),
      },
      {
        path: 'admin',
        component: AdminLayoutComponent,
        children: [
          {
            path: 'user-management',
            component: UserManagerComponent,
          },
        ],
        // loadChildren: () => import('../features/profile/profile.module').then((m) => m.ProfileModule),
      },
    ],
  },
  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent,
        // loadChildren: () => import('../features/auth/login/login.module').then( (m) => m.LoginModule ),
      },
      {
        path: 'signin',
        component: SigninComponent,
        // loadChildren: () => import('../features/auth/signin/signin.module').then((m) => m.SigninModule),
      },
      {
        path: 'not-found',
        component: NotFoundPageComponent,
        // loadChildren: () => import('../features/profile/profile.module').then((m) => m.ProfileModule),
      },
      {
        path: 'internal-server',
        component: InternalServerComponent,
        // loadChildren: () => import('../features/profile/profile.module').then((m) => m.ProfileModule),
      },
      {
        path: '',
        component: NotFoundPageComponent,
        // loadChildren: () => import('../features/profile/profile.module').then((m) => m.ProfileModule),
      },
    ],
  },
  {
    path: '**',
    redirectTo: 'not-found',
  },
];
