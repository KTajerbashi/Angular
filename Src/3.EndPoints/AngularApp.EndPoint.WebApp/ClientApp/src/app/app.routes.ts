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
import { RouterIntro } from './page/router-intro/router-intro';
import { UserDetails } from './page/router-intro/user-details/user-details';
import { RoleDetails } from './page/router-intro/role-details/role-details';
import { UserProfile } from './page/router-intro/user-profile/user-profile';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'components', component: ComponentIntro },
  { path: 'pipes', component: PipesIntro },
  { path: 'data-binding', component: DataBinding },
  { path: 'modules', component: ModuleIntro },
  {
    path: 'router/:id',
    component: RouterIntro,
    children: [
      { path: 'users', component: UserDetails },
      { path: 'roles', component: RoleDetails },
      { path: 'profile/:id', component: UserProfile },
    ],
  },
  { path: 'templates', component: TemplateIntro },
  { path: 'input-output', component: InputOutput },
  { path: 'users', component: User },
  { path: 'settings', component: Setting },
  { path: '**', redirectTo: 'not-found' },
];
