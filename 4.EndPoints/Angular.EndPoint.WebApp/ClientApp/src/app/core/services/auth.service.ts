import { Injectable } from '@angular/core';
import { BaseEntityApiService } from './base-entity-api.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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
