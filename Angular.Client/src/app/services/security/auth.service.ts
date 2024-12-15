import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import {
  ITokenModel,
  IUser,
  ISignInModel,
} from '../../interfaces/models/IModels';
import { ToastrService } from 'ngx-toastr';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from '../../bases/services/api.service';
import { IApiResponse } from '../../bases/models/IApiResponse';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'token';
  // private readonly apiUrl = 'http://localhost:8000/users';
  private readonly apiUrl = 'https://localhost:7100/api/'; // Base URL for API calls
  private readonly defaultExpireDays = 1; // Default token expiration in days

  constructor(
    private apiService: ApiService,
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
  login(username: string, password: string): Observable<IApiResponse<boolean>> {
    const model = { username, password };

    return this.apiService.post<boolean>('Account/login', model).pipe(
      tap({
        next: (res) => {
          console.log('Response:', res);
          this.toastr.success('Successful', 'Login');
        },
        error: (err) => {
          console.log('Error:', err);
          this.toastr.error('Login Failed', 'Login');
        },
        complete: () => {
          console.log('Login Complete');
        },
      })
    );
  }

  signin(model: ISignInModel): Observable<IApiResponse<boolean>> {
    return this.apiService.post<boolean>('Account/signin', model).pipe(
      tap({
        next: (res) => {
          console.log('Response:', res);
          this.toastr.success('Successful', 'Sign In');
        },
        error: (err) => {
          console.log('Error:', err);
          this.toastr.error('Sign In failed', 'Sign In');
        },
        complete: () => {
          console.log('Sign In Complete');
        },
      })
    );
  }

  /**
   * Logs the user out by clearing the token from localStorage and navigating to the login page.
   */
  logout(): void {
    // localStorage.removeItem(this.TOKEN_KEY);
    this.router.navigate(['/login']);
  }
  currentUserInfo = (): IUser => {
    let infoLocal = localStorage.getItem(this.TOKEN_KEY) ?? '';
    let infoModel = JSON.parse(infoLocal);
    let tokenModel = infoModel.token;
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
    if (method === null) {
      return `${this.apiUrl}${controller}`;
    } else {
    }
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
}
