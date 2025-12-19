import { Routes } from '@angular/router';
import { Dashboard } from './page/dashboard/dashboard';
import { User } from './page/user/user';
import { Setting } from './page/setting/setting';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'users', component: User },
  { path: 'settings', component: Setting },
  { path: '**', redirectTo: 'not-found' },
];
