import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject } from '@angular/core';
import { Observable } from 'rxjs';

export abstract class BaseApiService {
  protected readonly http = inject(HttpClient);

  /** Must be defined by child services */
  protected abstract endpoint: string;

  protected buildUrl(path?: string): string {
    return path ? `api/${this.endpoint}/${path}` : `api/${this.endpoint}`;
  }

  protected getWithParams<T>(params: Record<string, any>) {
    return this.http.get<T>(this.buildUrl(), { params });
  }

  protected getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Tajerbashi: 'kamrantajerbashi@gmail.com',
    });
  }

  protected get<T>(path?: string): Observable<T> {
    return this.http.get<T>(this.buildUrl(path), {
      headers: this.getHeaders(),
    });
  }

  protected post<TRequest, TResponse>(
    path: string | undefined,
    body: TRequest
  ): Observable<TResponse> {
    return this.http.post<TResponse>(this.buildUrl(path), body, {
      headers: this.getHeaders(),
    });
  }

  protected put<TRequest, TResponse>(
    path: string | undefined,
    body: TRequest
  ): Observable<TResponse> {
    return this.http.put<TResponse>(this.buildUrl(path), body, {
      headers: this.getHeaders(),
    });
  }

  protected delete<TResponse>(path: string): Observable<TResponse> {
    return this.http.delete<TResponse>(this.buildUrl(path), {
      headers: this.getHeaders(),
    });
  }
}
