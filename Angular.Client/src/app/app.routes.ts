import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { LoginComponent } from './pages/common/login/login.component';
import { SigninComponent } from './pages/common/signin/signin.component';
import { DashboardLayoutComponent } from './layout/dashboard-layout/dashboard-layout.component';
import { DashboardComponent } from './pages/main/dashboard/dashboard.component';
import { AuthGuard } from './guards/auth.guard';
export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'signin', component: SigninComponent },
    ],
  },
  {
    path: '',
    component: DashboardLayoutComponent,
    canActivate: [AuthGuard],
    children: [{ path: 'dashboard', component: DashboardComponent }],
  },
  { path: '**', redirectTo: 'login' },
];
