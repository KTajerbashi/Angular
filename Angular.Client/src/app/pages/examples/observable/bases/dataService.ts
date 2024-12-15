import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseObservable } from './base-observable.component';

@Injectable({
  providedIn: 'root',
})
export class DataService extends BaseObservable {
  private apiUrl = 'https://jsonplaceholder.typicode.com/posts';

  constructor(private http: HttpClient) {
    super(); // Call the parent constructor
  }

  getPosts(): Observable<any> {
    const httpRequest = this.http.get(this.apiUrl);
    return this.handleObservable(httpRequest, []); // Add error handling
  }
}
