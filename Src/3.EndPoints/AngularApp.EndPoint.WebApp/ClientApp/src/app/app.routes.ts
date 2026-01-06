import { Routes } from '@angular/router';
import { Dashboard } from './page/dashboard/dashboard';
import { User } from './page/user/user';
import { Setting } from './page/setting/setting';
import { ComponentIntro } from './page/component-intro/component-intro';
import { ModuleIntro } from './page/module-intro/module-intro';
import { TemplateIntro } from './page/template-intro/template-intro';
import { InputOutput } from './page/input-output/input-output';
import { PipesIntro } from './page/pipes-intro/pipes-intro';
import { DataBinding } from './page/data-binding/data-binding';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'components', component: ComponentIntro },
  { path: 'pipes', component: PipesIntro },
  { path: 'data-binding', component: DataBinding },
  { path: 'modules', component: ModuleIntro },
  { path: 'templates', component: TemplateIntro },
  { path: 'input-output', component: InputOutput },
  { path: 'users', component: User },
  { path: 'settings', component: Setting },
  { path: '**', redirectTo: 'not-found' },
];
