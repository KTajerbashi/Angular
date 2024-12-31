import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private tokenKey = 'authToken'; // Key for storing the token in localStorage

  constructor() {}

  // Retrieve the token from localStorage
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  // Set the token in localStorage
  setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  // Remove the token from localStorage
  removeToken(): void {
    localStorage.removeItem(this.tokenKey);
  }

  // Check if the user is authenticated (token exists)
  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  // Check if the user is logged in by verifying if the token exists in localStorage
  isLoggedIn(): Observable<boolean> {
    return of(!!localStorage.getItem(this.tokenKey)); // Returns true if the token exists
  }
}
