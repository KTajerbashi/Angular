import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class EntityApiService extends BaseApiService {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }
}
