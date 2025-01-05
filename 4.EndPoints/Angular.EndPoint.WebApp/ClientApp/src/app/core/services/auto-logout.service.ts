import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({ providedIn: 'root' })
export class AutoLogoutService {
  constructor(private authService: AuthService, private router: Router) {
    this.startAutoLogoutCheck();
  }

  startAutoLogoutCheck() {
    setInterval(() => {
      if (!this.authService.isLoggedIn()) {
        this.authService.logout();
        this.router.navigate(['/login']);
      }
    }, 1000 * 60); // Check every minute
  }
}
