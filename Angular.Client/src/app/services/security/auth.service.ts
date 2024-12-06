import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'token';
  private isLoggedIn = false;

  constructor(private router: Router) {}

  /**
   * Logs the user in by saving the token and other details in localStorage.
   * @param username - The username or token for login.
   */
  login(username: string): void {
    if (username) {
      const user: ITokenModel = {
        token: username,
        expireDate: this.calculateExpireDate(1), // Default to 1 day expiration
        isLoggedIn: true,
      };

      this.isLoggedIn = true;
      localStorage.setItem(this.TOKEN_KEY, JSON.stringify(user));
    }
  }

  /**
   * Logs the user out by clearing the token from localStorage and navigating to the login page.
   */
  logout(): void {
    this.isLoggedIn = false;
    localStorage.removeItem(this.TOKEN_KEY);
    this.router.navigate(['/login']);
  }

  /**
   * Checks if the user is authenticated by verifying the token and expiration date.
   * @returns true if authenticated, false otherwise.
   */
  isAuthenticated(): boolean {
    const tokenData = this.getTokenData();
    console.log(tokenData);
    if (tokenData && tokenData.isLoggedIn) {
      const isTokenExpired = new Date(tokenData.expireDate) < new Date();
      if (!isTokenExpired) {
        return true;
      } else {
        this.logout(); // Logout if the token is expired
      }
    }
    return false;
  }

  /**
   * Retrieves token data from localStorage.
   * @returns Parsed ITokenModel or null if not found.
   */
  private getTokenData(): ITokenModel | null {
    const token = localStorage.getItem(this.TOKEN_KEY);
    return token ? (JSON.parse(token) as ITokenModel) : null;
  }

  /**
   * Calculates the token expiration date.
   * @param days - Number of days before the token expires.
   * @returns A `Date` object representing the expiration date.
   */
  private calculateExpireDate(days: number): Date {
    const date = new Date();
    date.setDate(date.getDate() + days);
    return date;
  }
}

/**
 * Token model interface for user authentication details.
 */
interface ITokenModel {
  token: string;
  expireDate: Date;
  isLoggedIn: boolean;
}
