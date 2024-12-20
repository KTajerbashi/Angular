import { createAction, props } from '@ngrx/store';
import { IProductModel } from '../interfaces/store/IProductStateModel';

export const LOAD_PRODUCTS = '[product] load products';
export const LOAD_PRODUCTS_SUCCESS = '[product] load products success';
export const LOAD_PRODUCTS_FAIL = '[product] load products faild';

export const loadProducts = createAction(LOAD_PRODUCTS);
export const loadProductsSuccess = createAction(
  LOAD_PRODUCTS_SUCCESS,
  props<{ list: IProductModel[] }>()
);
export const loadProductsFail = createAction(
  LOAD_PRODUCTS_FAIL,
  props<{ errorMessages: string }>()
);
