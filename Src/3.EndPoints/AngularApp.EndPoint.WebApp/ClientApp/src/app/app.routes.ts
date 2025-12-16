import { Routes } from '@angular/router';
import { Dashboard } from './pages/dashboard/dashboard';
import { Users } from './pages/users/users';
import { About } from './pages/about/about';
import { CodeSample } from './pages/code-sample/code-sample';
import { FormSample } from './pages/form-sample/form-sample';
import { NotFound } from './pages/common/not-found/not-found';
import { InternalServer } from './pages/common/internal-server/internal-server';
import { TemplateSyntax } from './pages/template-syntax/template-syntax';
import { TemplateRefUsers } from './pages/template-ref-users/template-ref-users';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'users', component: Users },
  { path: 'about', component: About },
  { path: 'code-sample', component: CodeSample },
  { path: 'form-sample', component: FormSample },
  { path: 'template-syntax', component: TemplateSyntax },
  { path: 'template-ref-users', component: TemplateRefUsers },
  { path: 'not-found', component: NotFound },
  { path: 'internal-server', component: InternalServer },
  { path: '**', redirectTo: 'not-found' },
];
