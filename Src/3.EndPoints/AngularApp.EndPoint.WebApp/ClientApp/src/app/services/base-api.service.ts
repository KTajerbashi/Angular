import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export abstract class BaseApiService {
  baseUrl: string = '';
  constructor(private httpClient: HttpClient) {}
  getUrl(url: string): string {
    if (url.length > 0) {
      return `api/${this.baseUrl}/${url}`;
    } else {
      return `api/${this.baseUrl}`;
    }
  }
  post<T>(url: string, model: T) {
    return this.httpClient.post(this.getUrl(url), model);
  }
  get<T>(url: string) {
    let _headers = new HttpHeaders().set('Tajerbashi', 'kamrantajerbashi@gmail.com');
    return this.httpClient.get(this.getUrl(url), {
      headers: _headers,
    });
  }
  delete<T>(url: string) {
    return this.httpClient.delete(this.getUrl(url));
  }
  put<T>(url: string, model: T) {
    return this.httpClient.put(this.getUrl(url), model);
  }
}
