import { Routes } from '@angular/router';
import { HomeComponent } from './components/pages/main/home/home.component';
import { AboutComponent } from './components/pages/main/about/about.component';
import { PageNotFoundComponent } from './components/pages/response/page-not-found/page-not-found.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: '*', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: '**', component: PageNotFoundComponent },
];
