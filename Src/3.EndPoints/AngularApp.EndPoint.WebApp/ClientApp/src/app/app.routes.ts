import { Routes } from '@angular/router';
import { Dashboard } from './page/dashboard/dashboard';
import { User } from './page/user/user';
import { Setting } from './page/setting/setting';
import { ComponentIntro } from './page/component-intro/component-intro';
import { ModuleIntro } from './page/module-intro/module-intro';
import { TemplateIntro } from './page/template-intro/template-intro';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'components', component: ComponentIntro },
  { path: 'modules', component: ModuleIntro },
  { path: 'templates', component: TemplateIntro },
  { path: 'users', component: User },
  { path: 'settings', component: Setting },
  { path: '**', redirectTo: 'not-found' },
];
