import { Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { AboutComponent } from './components/pages/about/about.component';
import { PageNotFoundComponent } from './components/response/page-not-found/page-not-found.component';
import { UsersComponent } from './components/pages/users/users.component';
import { DirectivesComponent } from './components/pages/directives/directives.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: '*', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'users', component: UsersComponent },
  { path: 'directives', component: DirectivesComponent },
  { path: '**', component: PageNotFoundComponent },
];
