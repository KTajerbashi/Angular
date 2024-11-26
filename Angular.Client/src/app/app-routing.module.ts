import { Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { AboutComponent } from './components/pages/about/about.component';
import { FeatureComponent } from './components/pages/feature/feature.component';
import { ParentChildComponent } from './components/pages/parent-child/parent-child.component';
import { PageNotFoundComponent } from './components/response/page-not-found/page-not-found.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: '*', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'features', component: FeatureComponent },
  { path: 'parent-child', component: ParentChildComponent },
  { path: '**', component: PageNotFoundComponent },
];
