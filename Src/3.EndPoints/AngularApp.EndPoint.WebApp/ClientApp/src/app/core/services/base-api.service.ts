import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import BaseService from './base.service';

@Injectable({
  providedIn: 'root',
})
export default class BaseApiService extends BaseService {
  baseUri: string = '';
  constructor(
    private http: HttpClient,
    entityName: String,
  ) {
    super();
    this.baseUri = `api/${entityName}`;
  }
  readController() {
    return this.baseUri;
  }
  // ---------- GET ----------
  onGet<TResponse>(
    action: string = '',
    params?: Record<string, any>,
  ): Observable<IJsonResult<TResponse>> {
    let httpParams = new HttpParams();

    if (params) {
      Object.keys(params).forEach((key) => {
        if (params[key] !== null && params[key] !== undefined) {
          httpParams = httpParams.append(key, params[key]);
        }
      });
    }

    return this.http.get<IJsonResult<TResponse>>(`${this.baseUri}/${action}`, {
      params: httpParams,
    });
  }

  // ---------- POST ----------
  onPost<TRequest, TResponse>(action: string, body: TRequest): Observable<IJsonResult<TResponse>> {
    return this.http.post<IJsonResult<TResponse>>(`${this.baseUri}/${action}`, body);
  }

  // ---------- PUT ----------
  onPut<TRequest, TResponse>(action: string, body: TRequest): Observable<IJsonResult<TResponse>> {
    return this.http.put<IJsonResult<TResponse>>(`${this.baseUri}/${action}`, body);
  }

  // ---------- DELETE ----------
  onRemove<TResponse>(
    action: string,
    params?: Record<string, any>,
  ): Observable<IJsonResult<TResponse>> {
    let httpParams = new HttpParams();

    if (params) {
      Object.keys(params).forEach((key) => {
        httpParams = httpParams.append(key, params[key]);
      });
    }

    return this.http.delete<IJsonResult<TResponse>>(`${this.baseUri}/${action}`, {
      params: httpParams,
    });
  }
}
