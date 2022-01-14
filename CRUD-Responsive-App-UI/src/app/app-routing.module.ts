import { UnauthorizedAccessComponent } from './unauthorized-access/unauthorized-access.component';
import { HomeComponent } from './home/home.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserListingComponent } from './user-listing/user-listing.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthService } from './services/auth.service';
import { AuthGuardService } from './services/auth-guard.service';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'user-listing',
    component: UserListingComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'user-detail',
    component: UserDetailComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'user-detail/:action/:id',
    component: UserDetailComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'unauthorized',
    component: UnauthorizedAccessComponent,
  },
  {
    path: '*',
    component: LoginComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
