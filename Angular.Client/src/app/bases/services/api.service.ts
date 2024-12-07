import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { IApiResponse } from '../models/IApiResponse';

@Injectable({
  providedIn: 'root', // No need for AppModule with standalone services
})
export class ApiService {
  private baseUrl: string = 'https://localhost:7100/api'; // API base URL

  constructor(private http: HttpClient) {}

  get<T>(endpoint: string): Observable<IApiResponse<T>> {
    return this.http
      .get<IApiResponse<T>>(`${this.baseUrl}/${endpoint}`)
      .pipe(catchError(this.handleError));
  }

  post<T>(endpoint: string, data: any): Observable<IApiResponse<T>> {
    return this.http
      .post<IApiResponse<T>>(`${this.baseUrl}/${endpoint}`, data)
      .pipe(retry(1), catchError(this.handleError));
  }

  delete<T>(endpoint: string, id: number): Observable<IApiResponse<T>> {
    return this.http
      .delete<IApiResponse<T>>(`${this.baseUrl}/${endpoint}/${id}`)
      .pipe(retry(1), catchError(this.handleError));
  }

  put<T>(endpoint: string, data: any): Observable<IApiResponse<T>> {
    return this.http
      .put<IApiResponse<T>>(`${this.baseUrl}/${endpoint}/${data.id}`, data)
      .pipe(retry(1), catchError(this.handleError));
  }

  // Add more methods like PUT and DELETE as needed

  // Enhanced error handling method
  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';

    if (error.status === 0) {
      // A client-side or network error occurred.
      errorMessage = `Network error occurred. Please check your internet connection or try again later.`;
    } else {
      // Backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      switch (error.status) {
        case 400:
          errorMessage = 'Bad Request';
          break;
        case 401:
          errorMessage = 'Unauthorized: Please log in again.';
          break;
        case 403:
          errorMessage =
            'Forbidden: You don’t have permission to access this resource.';
          break;
        case 404:
          errorMessage = `Not Found: The requested resource could not be found.`;
          break;
        case 500:
          errorMessage = 'Internal Server Error';
          break;
        default:
          errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
          break;
      }
    }

    return throwError(errorMessage); // Throw an observable with a user-facing error message
  }
}
