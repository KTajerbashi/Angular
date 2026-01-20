//  Step 4 After Create Reducer and Register it in provideStore({})

import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { loadProducts, loadProductsFail, loadProductsSuccess } from './product.action.store';
import { catchError, exhaustMap, map, of } from 'rxjs';
import { ProductService } from '../../services/product.service';
import IProduct from '../../models/IProduct.dto';

@Injectable()
export class ProductEffect {
  actions$ = inject(Actions);
  service = inject(ProductService);
  // constructor(private action$: Actions, private service: ProductService) {}

  _loadProduct$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadProducts),
      exhaustMap((action) => {
        return this.service.getAll().pipe(
          map((data) => loadProductsSuccess({ list: data as IProduct[] })),
          catchError((err) => of(loadProductsFail({ errors: err })))
        );
      })
    )
  );
}
