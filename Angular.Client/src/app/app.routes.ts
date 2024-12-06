import { Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { AboutComponent } from './components/pages/about/about.component';
import { NotFoundComponent } from './components/common/not-found/not-found.component';
import { ExampleTestComponent } from './components/pages/example-test/example-test.component';
import { ParameterControllerComponent } from './components/pages/parameter-controller/parameter-controller.component';
import { UserComponent } from './components/pages/user/user.component';
import { Component } from '@angular/core';
import { UserCreateComponent } from './components/pages/user/usercomponents/user-create/user-create.component';
import { UserUpdateComponent } from './components/pages/user/usercomponents/user-update/user-update.component';
import { UserDeleteComponent } from './components/pages/user/usercomponents/user-delete/user-delete.component';
import { UserReadComponent } from './components/pages/user/usercomponents/user-read/user-read.component';
import { authGuard } from './guards/auth.guard';
import { childAuthGuard } from './guards/child-auth.guard';
import { deactivateGuard } from './guards/deactivate.guard';

export const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [authGuard] },
  { path: 'about', component: AboutComponent, canActivate: [authGuard] },
  {
    path: 'example-test',
    component: ExampleTestComponent,
    canActivate: [authGuard],
  },
  {
    path: 'parameter-controller',
    component: ParameterControllerComponent,
    canActivate: [authGuard],
  },
  {
    path: 'parameter-controller/:id',
    component: ParameterControllerComponent,
    canActivate: [authGuard],
  },
  {
    path: 'users',
    component: UserComponent,
    canActivate: [authGuard],
    canActivateChild: [childAuthGuard],
    canDeactivate: [deactivateGuard],
    loadComponent: () =>
      import('./components/pages/user/user.component').then(
        (item) => item.UserComponent
      ),
    children: [
      {
        path: 'create',
        component: UserCreateComponent,
      },
      {
        path: 'update/:id',
        component: UserUpdateComponent,
      },
      {
        path: 'delete/:id',
        component: UserDeleteComponent,
      },
      {
        path: 'read/:id',
        component: UserReadComponent,
      },
    ],
  },
  { path: '**', component: NotFoundComponent },
];
