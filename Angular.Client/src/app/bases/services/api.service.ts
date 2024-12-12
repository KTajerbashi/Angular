import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, concatMap, map, retry, tap } from 'rxjs/operators';
import { IApiResponse } from '../models/IApiResponse';

@Injectable({
  providedIn: 'root', // Provides the service at the root level
})
export class ApiService {
  private readonly baseUrl: string = 'http://localhost:8000'; // Base URL for API calls

  constructor(private http: HttpClient) {}

  /**
   * Generic GET method
   * @param endpoint - API endpoint
   * @returns Observable of type IApiResponse<T>
   */
  get<T>(endpoint: string): Observable<IApiResponse<T>> {
    let result = this.http.get<T>(this.getFullUrl(endpoint)).pipe(
      map((item) => {
        return {
          data: item,
          success: true,
          message: 'Success',
          error: null,
          token: 'Tajerbashi',
        };
      }),
      catchError(this.handleError)
    );
    return result;
  }

  /**
   * Generic POST method
   * @param endpoint - API endpoint
   * @param data - Data to be sent in the request body
   * @returns Observable of type IApiResponse<T>
   */
  post<T>(endpoint: string, data: any): Observable<IApiResponse<T>> {
    return this.http
      .post<IApiResponse<T>>(this.getFullUrl(endpoint), data)
      .pipe(retry(1), catchError(this.handleError));
  }

  /**
   * Generic DELETE method
   * @param endpoint - API endpoint
   * @param id - ID of the resource to delete
   * @returns Observable of type IApiResponse<T>
   */
  delete<T>(endpoint: string, id: number): Observable<IApiResponse<T>> {
    return this.http
      .delete<IApiResponse<T>>(this.getFullUrl(`${endpoint}/${id}`))
      .pipe(retry(1), catchError(this.handleError));
  }

  /**
   * Generic PUT method
   * @param endpoint - API endpoint
   * @param data - Data to be updated
   * @returns Observable of type IApiResponse<T>
   */
  put<T>(endpoint: string, data: any): Observable<IApiResponse<T>> {
    return this.http
      .put<IApiResponse<T>>(this.getFullUrl(`${endpoint}/${data.id}`), data)
      .pipe(retry(1), catchError(this.handleError));
  }

  /**
   * Constructs the full API URL
   * @param endpoint - API endpoint
   * @returns Full API URL
   */
  private getFullUrl(endpoint: string): string {
    return `${this.baseUrl}/${endpoint}`;
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
    } else {
      // Server-side error
      errorMessage = this.getErrorMessage(error);
    }
    return throwError(errorMessage);
  }

  /**
   * Generates user-friendly error messages
   * @param error - HttpErrorResponse
   * @returns Error message string
   */
  private getErrorMessage(error: HttpErrorResponse): string {
    switch (error.status) {
      case 400:
        return 'Bad Request';
      case 401:
        return 'Unauthorized: Please log in again.';
      case 403:
        return 'Forbidden: You don’t have permission to access this resource.';
      case 404:
        return 'Not Found: The requested resource could not be found.';
      case 500:
        return 'Internal Server Error';
      default:
        return `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
  }
}
