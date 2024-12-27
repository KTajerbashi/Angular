import { Injectable, inject } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { catchError, exhaustMap, map, of, switchMap } from 'rxjs';
import { ApiService } from '../bases/services/api.service';
import { ProductActions } from './product.action';
import { IProductModel } from './product.model';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ProductEffects {
  actions$ = inject(Actions);
  constructor(private apiService: ApiService, private toaster: ToastrService) {}

  loadProduct$ = createEffect(() =>
    this.actions$.pipe(
      // Specify the action to listen for, for example 'loadProduct'
      ofType(ProductActions.loadProduct),
      exhaustMap((action) => {
        return this.apiService.get<IProductModel[]>('Product').pipe(
          map((response) => {
            return ProductActions.loadProductSuccess({
              products: response.data,
            });
          }),
          catchError((err) => of(this.showAlert(err.meesage, 'fail')))
        );
      })
    )
  );

  createProduct$ = createEffect(() =>
    this.actions$.pipe(
      // Specify the action to listen for, for example 'loadProduct'
      ofType(ProductActions.createProduct),
      switchMap((action) => {
        console.log('Create Action Effect: ', action.model);
        return this.apiService
          .post<IProductModel[]>('Product', action.model)
          .pipe(
            switchMap((response) => {
              console.log('Create Res : ', response);
              if (response.success) {
                this.apiService.get<IProductModel[]>('Product').subscribe({
                  next: (res) => {
                    return of(
                      ProductActions.createProductSuccess({
                        products: res.data,
                      }),
                      this.showAlert('Created Successfully', 'pass')
                    );
                  },
                });
              }
              return of(
                ProductActions.createProductSuccess({
                  products: [],
                }),
                this.showAlert('Created Successfully', 'pass')
              );
            }),
            catchError((err) => of(this.showAlert(err.meesage, 'fail')))
          );
      })
    )
  );

  updateProduct$ = createEffect(() =>
    this.actions$.pipe(
      // Specify the action to listen for, for example 'loadProduct'
      ofType(ProductActions.updateProduct),
      exhaustMap((action) => {
        console.log('Update Action Effect: ', action.model);
        return this.apiService
          .put<IProductModel[]>('Product', action.model)
          .pipe(
            map((response) => {
              console.log('Update Res : ', response);
              return ProductActions.updateProductSuccess({
                products: response.data,
              });
            }),
            catchError((err) => of(this.showAlert(err.meesage, 'fail')))
          );
      })
    )
  );

  deleteProduct$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProductActions.deleteProduct),
      exhaustMap((action) =>
        this.apiService.delete<IProductModel[]>('Product', action.id).pipe(
          switchMap((deleteResponse) => {
            if (deleteResponse.success) {
              return this.apiService.get<IProductModel[]>('Product').pipe(
                map((fetchResponse) =>
                  ProductActions.deleteProductSuccess({
                    products: fetchResponse.data,
                  })
                ),
                catchError((err) =>
                  of(
                    this.showAlert(
                      'Failed to fetch products after delete',
                      'fail'
                    )
                  )
                )
              );
            }
            return of(this.showAlert('Delete failed', 'fail'));
          }),
          catchError((err) =>
            of(this.showAlert(err.message || 'Delete operation failed', 'fail'))
          )
        )
      )
    )
  );

  getByIdProduct$ = createEffect(() =>
    this.actions$.pipe(
      // Specify the action to listen for, for example 'loadProduct'
      ofType(ProductActions.getbyIdProduct),
      switchMap((action) => {
        console.log('Get By Id Action Effect: ', action.id);
        return this.apiService.get<IProductModel>('Product/' + action.id).pipe(
          map((response) => {
            console.log('Get ById Res : ', response);
            return ProductActions.getbyIdProductSuccess({
              model: response.data,
            });
          }),
          catchError((err) => of(this.showAlert(err.meesage, 'fail')))
        );
      })
    )
  );

  showAlert = (message: string, response: string) => {
    if (response === 'pass') {
      this.toaster.success(message);
    } else {
      this.toaster.error(message);
    }
    return ProductActions.emptyAction();
  };
}
