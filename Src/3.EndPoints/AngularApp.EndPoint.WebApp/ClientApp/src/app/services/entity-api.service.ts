import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export abstract class EntityApiService<TEntity> extends BaseApiService {
  controller: string = '';
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  onCreate<TEntity>(model: TEntity) {
    return this.post<TEntity>(this.controller, model);
  }
  onUpdate<TEntity>(model: TEntity) {
    return this.put<TEntity>(this.controller, model);
  }
  onDelete<TEntity>(id: number) {
    return this.delete<TEntity>(`${this.controller}/${id}`);
  }
  onGetAll<TEntity>() {
    return this.get<TEntity>(`${this.controller}`);
  }
  onGetById<TEntity>(id: number) {
    return this.get<TEntity>(`${this.controller}/${id}`);
  }
}
