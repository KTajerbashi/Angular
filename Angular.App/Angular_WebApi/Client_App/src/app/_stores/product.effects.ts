import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import {
  loadProducts,
  loadProductsFail,
  loadProductsSuccess,
} from './product.action';
import { catchError, exhaustMap, map, of } from 'rxjs';
import { ApiService } from '../bases/services/api.service';
import { IProductModel } from '../interfaces/store/IProductStateModel';

@Injectable()
export class ProductEffct {
  action$ = inject(Actions);
  apiService = inject(ApiService);

  // constructor(private action$: Actions, private apiService: ApiService) {}
  _loadproduct = createEffect(() =>
    this.action$.pipe(
      ofType(loadProducts),
      exhaustMap((action) => {
        return this.apiService.get<IProductModel[]>('Product').pipe(
          map((response) => {
            const { data } = response;
            return loadProductsSuccess({ list: data });
          }),
          catchError((err) =>
            of(loadProductsFail({ errorMessages: err.message }))
          )
        );
      })
    )
  );
}
