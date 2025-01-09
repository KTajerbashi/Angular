import { Injectable } from '@angular/core';
import { CanActivate, Router, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { map, switchMap, take, catchError } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { selectIsAuthenticated } from '../../store/auth/auth.selectors';
import { checkAuth } from '../../store/auth/auth.actions';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private store: Store,
    private authService: AuthService,
    private router: Router
  ) {}

  canActivate(): Observable<boolean | UrlTree> {
    return this.authService.isLoggedIn().pipe(
      switchMap((isLoggedIn) => {
        if (isLoggedIn) {
          // If the user is already logged in, check the store's state
          return this.store.select(selectIsAuthenticated).pipe(
            take(1),
            map((isAuthenticated) => {
              if (isAuthenticated) {
                return true; // Allow navigation
              } else {
                // If the store state is not authenticated, validate with the server
                this.store.dispatch(checkAuth());
                return false; // Temporary fallback until store updates
              }
            }),
            catchError(() => of(this.router.createUrlTree(['/login'])))
          );
        } else {
          // If not logged in, dispatch checkAuth to verify with the backend
          this.store.dispatch(checkAuth());
          return this.store.select(selectIsAuthenticated).pipe(
            take(1),
            map((isAuthenticated) => {
              if (isAuthenticated) {
                return true; // Allow navigation
              } else {
                return this.router.createUrlTree(['/login']); // Redirect to login
              }
            }),
            catchError(() => of(this.router.createUrlTree(['/login'])))
          );
        }
      }),
      catchError(() => of(this.router.createUrlTree(['/login'])))
    );
  }
}
