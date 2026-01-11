import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export abstract class EntityApiService<TEntity> extends BaseApiService {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  add<TEntity>(model: TEntity) {
    return this.post<TEntity>('', model);
  }
  update<TEntity>(model: TEntity) {
    return this.put<TEntity>('', model);
  }
  remove<TEntity>(id: string) {
    return this.delete<TEntity>(`${id}`);
  }
  getAll<TEntity>() {
    return this.get<TEntity>(``);
  }
  getById<TEntity>(id: string) {
    return this.get<TEntity>(`${id}`);
  }
}
