import { Routes } from '@angular/router';
import { Dashboard } from './pages/dashboard/dashboard';
import { Users } from './pages/users/users';
import { About } from './pages/about/about';
import { CodeSample } from './pages/code-sample/code-sample';
import { FormSample } from './pages/form-sample/form-sample';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'users', component: Users },
  { path: 'about', component: About },
  { path: 'code-sample', component: CodeSample },
  { path: 'form-sample', component: FormSample },
  { path: '**', redirectTo: 'dashboard' },
];
