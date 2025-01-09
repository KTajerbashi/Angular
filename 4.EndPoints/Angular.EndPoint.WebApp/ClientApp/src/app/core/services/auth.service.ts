import { Injectable } from '@angular/core';
import { BaseEntityApiService } from './base-entity-api.service';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService extends BaseEntityApiService<any, any, any, any, any> {
  private tokenKey = 'authToken';
  private tokenExpiryKey = 'authTokenExpiry';

  constructor(http: HttpClient) {
    super(http, 'Authenticate');
  }

  login(parameter: ILoginCommand): Observable<IJsonPromise<string>> {
    return this.post<string>('/login', parameter);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  getTokenExpiry(): number | null {
    const expiry = localStorage.getItem(this.tokenExpiryKey);
    return expiry ? parseInt(expiry, 10) : null;
  }

  isLoggedIn(): Observable<boolean> {
    return this.checkAuth().pipe(
      map((response) => {
        if (response.success) {
          const token = this.getToken();
          const expiry = this.getTokenExpiry();

          if (!token || !expiry) {
            return false;
          }

          return Date.now() < expiry;
        } else {
          return false;
        }
      }),
      catchError(() => of(false)) // Handle errors gracefully
    );
  }

  signout(): Observable<IJsonPromise<boolean>> {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.tokenExpiryKey);
    return this.get<boolean>('/signout');
  }

  checkAuth(): Observable<IJsonPromise<boolean>> {
    return this.get<boolean>('/isAuthenticated');
  }

  readCurrentUserInfo(): Observable<boolean> {
    return this.http.get<boolean>('/CurrentUserInfo');
  }
}
