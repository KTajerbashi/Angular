import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private tokenKey = 'authToken';
  private tokenExpiryKey = 'authTokenExpiry';

  login(username: string, password: string): boolean {
    // Simulate successful login
    if (username === 'admin' && password === 'password') {
      const token = btoa(`${username}:${password}`); // Simulated token (use a better method in production)
      const expiryTime = Date.now() + 12 * 60 * 60 * 1000; // 12 hours from now

      localStorage.setItem(this.tokenKey, token);
      localStorage.setItem(this.tokenExpiryKey, expiryTime.toString());
      return true;
    }
    return false;
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  getTokenExpiry(): number | null {
    const expiry = localStorage.getItem(this.tokenExpiryKey);
    return expiry ? parseInt(expiry, 10) : null;
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    const expiry = this.getTokenExpiry();

    if (!token || !expiry) {
      return false;
    }

    return Date.now() < expiry;
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.tokenExpiryKey);
  }
}
