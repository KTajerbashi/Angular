import { createAction, props } from '@ngrx/store';
import { IProductModel } from './product.model';

export enum ProductAction {
  LOAD_PRODUCTS = '[product] load products',
  LOAD_PRODUCTS_SUCCESS = '[product] load products success',
  LOAD_PRODUCTS_FAIL = '[product] load products fail',
}

export const ProductActions = {
  loadProduct: createAction(ProductAction.LOAD_PRODUCTS),
  loadProductSuccess: createAction(
    ProductAction.LOAD_PRODUCTS_SUCCESS,
    props<{ products: IProductModel[] }>()
  ),
  loadProductFail: createAction(
    ProductAction.LOAD_PRODUCTS_FAIL,
    props<{ errorMessage: string }>()
  ),
};
