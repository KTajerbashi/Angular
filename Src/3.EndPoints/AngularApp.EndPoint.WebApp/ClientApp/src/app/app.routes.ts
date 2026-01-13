import { Routes } from '@angular/router';
import { Dashboard } from './pages/dashboard/dashboard';
import { ComponentIntro } from './pages/component-intro/component-intro';
import { PipesIntro } from './pages/pipes-intro/pipes-intro';
import { DataBinding } from './pages/data-binding/data-binding';
import { ModuleIntro } from './pages/module-intro/module-intro';
import { RouterIntro } from './pages/router-intro/router-intro';
import { UserDetails } from './pages/router-intro/user-details/user-details';
import { UserInfo } from './pages/router-intro/user-details/user-info/user-info';
import { RoleDetails } from './pages/router-intro/role-details/role-details';
import { UserProfile } from './pages/router-intro/user-profile/user-profile';
import { GuardsIntro } from './pages/guards-intro/guards-intro';
import { authGuard } from './guards/auth-guard';
import { childAuthGuard } from './guards/child-auth-guard';
import { canDeactivateGuard } from './guards/can-deactivate-guard';
import { GuardDetails } from './pages/guards-intro/guard-details/guard-details';
import { GuardAdd } from './pages/guards-intro/guard-add/guard-add';
import { GuardEdit } from './pages/guards-intro/guard-edit/guard-edit';
import { GuardCartable } from './pages/guards-intro/guard-cartable/guard-cartable';
import { DirectiveIntro } from './pages/directive-intro/directive-intro';
import { FormsIntro } from './pages/forms-intro/forms-intro';
import { ServiceIntro } from './pages/service-intro/service-intro';
import { HooksIntro } from './pages/hooks-intro/hooks-intro';
import { InputOutput } from './pages/input-output/input-output';
import { User } from './pages/user/user';
import { Setting } from './pages/setting/setting';
import { NotFoundPage } from './pages/common/not-found-page/not-found-page';
import { ProductDashboard } from './pages/product-dashboard/product-dashboard';
import { SignalIntro } from './pages/signal-intro/signal-intro';
import { TemplateIntro } from './pages/template-intro/template-intro';
import { RxjsIntro } from './pages/rxjs-intro/rxjs-intro';
import { HttpIntro } from './pages/http-intro/http-intro';

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
      {
        path: 'users',
        component: UserDetails,
        children: [{ path: 'user/:key', component: UserInfo }],
      },
      { path: 'roles/:submenu/:id', component: RoleDetails },
      { path: 'profile/:id', component: UserProfile },
    ],
  },
  {
    path: 'guards',
    component: GuardsIntro,
    canActivate: [authGuard],
    canActivateChild: [childAuthGuard],
    canDeactivate: [canDeactivateGuard],
    children: [
      { path: 'details', component: GuardDetails },
      { path: 'add', component: GuardAdd },
      { path: 'edit/:id', component: GuardEdit },
      { path: 'cartable/:submenu/:key', component: GuardCartable },
    ],
  },
  {
    path: 'templates',
    loadComponent() {
      return import('./pages/template-intro/template-intro').then((x) => x.TemplateIntro);
    },
  },
  { path: 'directives', component: DirectiveIntro },
  { path: 'forms', component: FormsIntro },
  { path: 'service', component: ServiceIntro },
  { path: 'hooks', component: HooksIntro },
  { path: 'signal', component: SignalIntro },
  { path: 'templates', component: TemplateIntro },
  { path: 'rxjs', component: RxjsIntro },
  { path: 'http-client', component: HttpIntro },

  { path: 'products', component: ProductDashboard },
  { path: 'input-output', component: InputOutput },
  { path: 'users', component: User },
  { path: 'settings', component: Setting },
  { path: 'not-found', component: NotFoundPage },
  { path: '**', redirectTo: 'not-found' },
];
