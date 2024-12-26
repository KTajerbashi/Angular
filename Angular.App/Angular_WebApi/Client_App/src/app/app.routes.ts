import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { LoginComponent } from './pages/common/login/login.component';
import { SigninComponent } from './pages/common/signin/signin.component';
import { DashboardLayoutComponent } from './layout/dashboard-layout/dashboard-layout.component';
import { DashboardComponent } from './pages/main/dashboard/dashboard.component';
import { AuthGuard } from './guards/auth.guard';
import { AboutComponent } from './pages/main/about/about.component';
import { NotFoundComponent } from './pages/common/not-found/not-found.component';
import { UserComponent } from './pages/user/user.component';
import { UserCreateComponent } from './pages/user/children/user-create/user-create.component';
import { UserUpdateComponent } from './pages/user/children/user-update/user-update.component';
import { UserReadComponent } from './pages/user/children/user-read/user-read.component';
import { UserDeleteComponent } from './pages/user/children/user-delete/user-delete.component';
import { PanelComponent } from './pages/admin/panel/panel.component';
import { ProfileComponent } from './pages/admin/profile/profile.component';
import { InternalServerComponent } from './pages/common/internal-server/internal-server.component';
import { UserProfileComponent } from './pages/user/children/user-profile/user-profile.component';
import { ServiceExampleParentComponent } from './pages/examples/service-example-parent/service-example-parent.component';
import { ChatRoomComponent } from './pages/examples/chat-room/chat-room.component';
import { ProductsComponent } from './pages/ngrx/products/products.component';
import { NgrxManagerComponent } from './pages/ngrx/ngrx-manager/ngrx-manager.component';
export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'signin', component: SigninComponent },
    ],
  },
  {
    path: '',
    component: DashboardLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
      },
      {
        path: 'admin',
        component: PanelComponent,
        children: [{ path: 'profile', component: ProfileComponent }],
      },
      { path: 'about', component: AboutComponent },
      { path: 'profile', component: UserProfileComponent },
      { path: 'example-service', component: ServiceExampleParentComponent },
      {
        path: 'users',
        component: UserComponent,
        children: [
          { path: 'create', component: UserCreateComponent },
          { path: 'update/:id', component: UserUpdateComponent },
          { path: 'read/:id', component: UserReadComponent },
          { path: 'delete/:id', component: UserDeleteComponent },
        ],
      },
      { path: 'ngrx', component: NgrxManagerComponent },
      { path: 'internalServer', component: InternalServerComponent },
      { path: 'chat-room', component: ChatRoomComponent },
      { path: '**', component: NotFoundComponent },
    ],
  },
  { path: '**', redirectTo: 'login' },
];
