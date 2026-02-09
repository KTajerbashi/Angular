import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import BaseApiService from './base-api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export default class BaseEntityService<TDto, TView> extends BaseApiService {
  constructor(http: HttpClient, entityName: String) {
    super(http, entityName);
  }
  // ---------- GET ALL ----------
  getAll(): Observable<IJsonResult<TDto[]>> {
    return this.onGet<TDto[]>('');
  }

  // ---------- GET Paging ----------
  onPagingData(parameter: IPagingRequest): Observable<IJsonResult<IPagingModel<TView>>> {
    return this.onPost<IPagingRequest, IPagingModel<TView>>('ReadPaging', parameter);
  }

  // ---------- GET BY ID ----------
  getById(id: string | number): Observable<IJsonResult<TDto>> {
    return this.onGet<TDto>(`${id}`);
  }

  // ---------- CREATE ----------
  create(model: TDto): Observable<IJsonResult<string>> {
    return this.onPost<TDto, string>('', model);
  }

  // ---------- UPDATE ----------
  update(model: TDto): Observable<IJsonResult<boolean>> {
    return this.onPut<TDto, boolean>('', model);
  }

  // ---------- DELETE ----------
  delete(id: string | number): Observable<IJsonResult<boolean>> {
    return this.onRemove<boolean>('', { id });
  }

  // ---------- SEARCH WITH PARAMS ----------
  search(params: Record<string, any>): Observable<IJsonResult<TDto[]>> {
    return this.onGet<TDto[]>('Search', params);
  }
}
