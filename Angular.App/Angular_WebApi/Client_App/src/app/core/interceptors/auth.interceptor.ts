import { inject } from '@angular/core';
import {
  HttpRequest,
  HttpEvent,
  HttpInterceptorFn,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

export const authInterceptor: HttpInterceptorFn = (
  req: HttpRequest<any>,
  next: any
): Observable<HttpEvent<any>> => {
  const authService = inject(AuthService); // Using inject() for services
  const router = inject(Router); // Inject Router

  // Get the authentication token from localStorage or another source
  const authToken = authService.getToken();

  // Clone the request and set the Authorization header if the token is available
  if (authToken) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authToken}`,
      },
    });
  }

  // Handle the HTTP request and any errors
  return next.handle(req).pipe(
    catchError((error) => {
      if (error.status === 401 || error.status === 403) {
        // If the user is not authorized, redirect to login page
        router.navigate(['/auth/login']);
      }
      throw error;
    })
  );
};
