import { Routes } from '@angular/router';
import { AuthLayout } from './layouts/auth-layout/auth-layout';
import { MainLayout } from './layouts/main-layout/main-layout';
import { LoginComponent } from './features/auth/pages/login/login.component';
import { SignUpComponent } from './features/auth/pages/sign-up/sign-up.component';
import { ProfileComponent } from './features/auth/pages/profile/profile.component';
import { DashboardComponent } from './features/dashboard/dashboard/dashboard.component';
import { CartableComponent } from './features/dashboard/cartable/cartable.component';
import { AboutComponent } from './features/dashboard/about/about.component';
import { HistoryComponent } from './features/dashboard/history/history.component';
import { UserComponent } from './features/security/user/user.component';
import { RoleComponent } from './features/security/role/role.component';
import { PrivilegeComponent } from './features/security/privilege/privilege.component';
import { GroupComponent } from './features/security/group/group.component';
import { MenuComponent } from './features/setting/menu/menu.component';
export const routes: Routes = [
  {
    path: 'auth',
    component: AuthLayout,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'sign-up', component: SignUpComponent },
      {
        path: 'profile',
        component: ProfileComponent,
      },
    ],
  },
  {
    path: '',
    component: MainLayout,
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'cartable', component: CartableComponent },
      { path: 'about', component: AboutComponent },
      { path: 'history', component: HistoryComponent },
      { path: 'user', component: UserComponent },
      { path: 'role', component: RoleComponent },
      { path: 'group', component: GroupComponent },
      { path: 'privilege', component: PrivilegeComponent },
      { path: 'menu', component: MenuComponent },
    ],
  },
  { path: '**', redirectTo: 'auth/login' },
];
