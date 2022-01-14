import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuardService {
  constructor(public authService: AuthService, public router: Router) {}

  async canActivate(): Promise<boolean> {
    let isAuthenticated: boolean = localStorage.getItem('auth-token')
      ? true
      : false;
    if (!isAuthenticated) {
      this.router.navigate(['login']);
    }
    //  var isAuthenticated = this.authService.getAuthStatus();
    return isAuthenticated;
  }
}
