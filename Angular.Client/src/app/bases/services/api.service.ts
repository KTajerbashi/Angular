import { MatSnackBar } from '@angular/material/snack-bar';
import { Injectable, signal } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, Observable, of, retry, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { IApiResponse } from '../models/IApiResponse';

@Injectable({
  providedIn: 'root', // Provides the service at the root level
})
export class ApiService {
  // private readonly baseUrl: string = 'http://localhost:8000'; // Base URL for API calls
  private readonly baseUrl: string = 'https://localhost:7202/api/'; // Base URL for API calls

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private snackBar: MatSnackBar
  ) {}

  /**
   * Generic GET method
   * @param endpoint - API endpoint
   * @returns Observable of type IApiResponse<T>
   */
  get<T>(endpoint: string): Observable<IApiResponse<T>> {
    return this.http
      .get<IApiResponse<T>>(this.getFullUrl(endpoint))
      .pipe(catchError(this.handleError));
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
    return `${this.baseUrl}${endpoint}`;
  }

  /**
   * Handles HTTP errors
   * @param error - HttpErrorResponse
   * @returns Observable that throws a user-friendly error message
   */
  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = 'An unknown error occurred!';
    console.log('handleError : ', errorMessage);
    if (error.status === 0) {
      // Client-side or network error
      errorMessage = 'Network error occurred. Please check your connection.';
    } else if (!error.error.success) {
      // Server-side error
      console.log('Server-side error', error.error);
      errorMessage = error.error.message;
    }
    return throwError(() => new Error(errorMessage));
  }

  requestCount = signal(0);
  getRequestCount = (): number => this.requestCount();
  addRequestCount = () => this.requestCount.set(this.requestCount() + 1);
  removeRequestCount = () => this.requestCount.set(this.requestCount() - 1);
}
