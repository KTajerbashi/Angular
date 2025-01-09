import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BaseApiService {
  public baseUrl: string;

  constructor(protected http: HttpClient, controller: String) {
    // Set the baseUrl when the controller is provided
    this.baseUrl = `api/${controller}`;
  }
  get = <T>(url: string, options?: object): Observable<IJsonPromise<T>> =>
    this.http.get<IJsonPromise<T>>(`${this.baseUrl}${url}`, options);

  post = <T>(url: string, options?: object): Observable<IJsonPromise<T>> =>
    this.http.post<IJsonPromise<T>>(`${this.baseUrl}${url}`, options);

  put = <T>(url: string, options?: any): Observable<IJsonPromise<T>> =>
    this.http.put<IJsonPromise<T>>(`${this.baseUrl}${url}`, options);

  delete = <T>(url: string, options?: object): Observable<IJsonPromise<T>> =>
    this.http.delete<IJsonPromise<T>>(`${this.baseUrl}${url}`, options);
}
