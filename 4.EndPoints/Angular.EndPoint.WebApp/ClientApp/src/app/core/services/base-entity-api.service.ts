import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class BaseEntityApiService<
  TCreate,
  TUpdate,
  TDelete,
  TDTO,
  TView
> extends BaseApiService {
  constructor(http: HttpClient, controller: String) {
    super(http, controller); // Pass controller to BaseService constructor
  }
  onCreate = (parameter: TCreate) =>
    this.post<TCreate>('', parameter as object);
  onUpdate = (parameter: TUpdate) => this.put<TCreate>('', parameter as object);
  onRemove = (parameter: string) => this.delete<TDelete>('/' + parameter, {});
  onGetById = (id: string) => this.get<TDTO | TView>(`/${id}`);
  onGetAll = () => this.get<TDTO[] | TView[]>('');
}
