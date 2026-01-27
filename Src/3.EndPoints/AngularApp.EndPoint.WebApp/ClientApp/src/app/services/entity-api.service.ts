import { Observable } from 'rxjs';
import { BaseApiService } from './base-api.service';

export abstract class EntityApiService<TEntity, TKey = string>
  extends BaseApiService {

  getAll(): Observable<TEntity[]> {
    return this.get<TEntity[]>();
  }

  getById(id: TKey): Observable<TEntity> {
    return this.get<TEntity>(`${id}`);
  }

  create(model: TEntity): Observable<TEntity> {
    return this.post<TEntity, TEntity>(undefined, model);
  }

  update(id: TKey, model: TEntity): Observable<TEntity> {
    return this.put<TEntity, TEntity>(`${id}`, model);
  }

  deleteById(id: TKey): Observable<void> {
    return this.delete<void>(`${id}`);
  }
}
