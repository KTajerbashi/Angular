import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { IUser } from '../../interfaces/models/IUser';
import { ToastrService } from 'ngx-toastr';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'token';
  // private readonly apiUrl = 'http://localhost:8000/users';
  private readonly apiUrl = 'https://localhost:7100/api/'; // Base URL for API calls
  private readonly defaultExpireDays = 1; // Default token expiration in days

  constructor(
    private http: HttpClient,
    private router: Router,
    private toastr: ToastrService,
    private snackBar: MatSnackBar
  ) {}

  /**
   * Logs the user in by validating the credentials and saving a token in localStorage.
   * @param username - The username (or email) of the user.
   * @param password - The password of the user.
   * @returns Observable<boolean> - Emits true if login is successful, false otherwise.
   */
  login(username: string, password: string): Observable<boolean> {
    if (!username || !password) {
      return new Observable((observer) => observer.next(false));
    }

    return this.http
      .get<IUser[]>(this.getUrl('Account','Login'))
      .pipe(catchError(this.handleError))
      .pipe(
        map((users) => {
          const user = users.find(
            (u) => u.username === username && u.password === password
          );

          if (user) {
            const token: ITokenModel = {
              token: JSON.stringify(user),
              expireDate: this.calculateExpireDate(this.defaultExpireDays),
              isLoggedIn: true,
            };

            // Save user info in localStorage for session persistence
            localStorage.setItem(this.TOKEN_KEY, JSON.stringify(token));
            return true;
          }

          return false;
        })
      );
  }

  /**
   * Logs the user out by clearing the token from localStorage and navigating to the login page.
   */
  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    this.router.navigate(['/login']);
  }
  currentUserInfo = (): IUser => {
    let infoLocal = localStorage.getItem(this.TOKEN_KEY) ?? '';
    let infoModel = JSON.parse(infoLocal);
    let tokenModel = JSON.parse(infoModel.token);
    let info: IUser = {
      id: tokenModel.id,
      name: tokenModel.name,
      family: tokenModel.family,
      email: tokenModel.email,
      username: tokenModel.username,
      password: tokenModel.password,
      isActive: true,
      phoneNumber: tokenModel.phone,
      roleId: 1,
    };
    return info;
  };
  /**
   * Checks if the user is authenticated by verifying the token and its expiration date.
   * @returns boolean - True if authenticated, false otherwise.
   */
  isAuthenticated(): boolean {
    const tokenData = this.getTokenData();
    if (tokenData && tokenData.isLoggedIn) {
      const isTokenExpired = new Date(tokenData.expireDate) < new Date();
      if (!isTokenExpired) {
        return true;
      } else {
        this.logout(); // Auto-logout if the token is expired
      }
    }
    return false;
  }

  getUrl = (controller: string, method: string): string => {
    if(method === null){
      return `${this.apiUrl}${controller}`;
    }else{}
    return `${this.apiUrl}${controller}/${method}`;
  };

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

  /**
   * Handles HTTP errors
   * @param error - HttpErrorResponse
   * @returns Observable that throws a user-friendly error message
   */
  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = 'An unknown error occurred!';
    if (error.status === 0) {
      // Client-side or network error
      errorMessage = 'Network error occurred. Please check your connection.';
    } else if (!error.error.success) {
      // Server-side error
      alert(error.error.message);
    }
    return throwError(errorMessage);
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
