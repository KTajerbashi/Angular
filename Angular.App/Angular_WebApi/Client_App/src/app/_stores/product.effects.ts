import { Injectable, inject } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { catchError, exhaustMap, map, of } from 'rxjs';
import { ApiService } from '../bases/services/api.service';
import { ProductActions } from './product.action';
import { IProductModel } from './product.model';

@Injectable()
export class ProductEffects {
  actions$ = inject(Actions);
  constructor(private apiService: ApiService) {}

  loadProduct$ = createEffect(() =>
    this.actions$.pipe(
      // Specify the action to listen for, for example 'loadProduct'
      ofType(ProductActions.loadProduct),
      exhaustMap((action) => {
        console.log('Effect : ', action);
        return this.apiService.get<IProductModel[]>('Product').pipe(
          map((response) => {
            console.log('Effect Response : ', response);
            return ProductActions.loadProductSuccess({
              products: response.data,
            });
          }),
          catchError((err) =>
            of(
              ProductActions.loadProductFail({
                errorMessage: JSON.stringify(err),
              })
            )
          )
        );
      })
    )
  );
}
