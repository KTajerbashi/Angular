import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(): boolean | UrlTree {
    const isLoggedIn = this.isUserLoggedIn();
    if (isLoggedIn) {
      return true;
    } else {
      return this.router.createUrlTree(['/login']);
    }
  }

  private isUserLoggedIn(): boolean {
    // Replace with your actual authentication logic
    return !!localStorage.getItem('authToken');
  }
}