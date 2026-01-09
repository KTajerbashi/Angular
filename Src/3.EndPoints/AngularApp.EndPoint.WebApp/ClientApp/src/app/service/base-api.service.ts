import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IApiJson from '../models/IApiJson.dto';

@Injectable({
  providedIn: 'root',
})
export class BaseApiService {
  constructor(private httpClient: HttpClient) {}

  post<T>(url: string, model: T) {
    return this.httpClient.post(`api/${url}`, model);
  }
  get<T>(url: string) {
    return this.httpClient.get(`api/${url}`);
  }
  delete<T>(url: string) {
    return this.httpClient.delete(`api/${url}`);
  }
  put<T>(url: string, model: T) {
    return this.httpClient.put(`api/${url}`, model);
  }
}
