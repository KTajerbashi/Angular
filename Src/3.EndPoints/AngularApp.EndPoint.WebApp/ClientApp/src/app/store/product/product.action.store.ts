//  Step 2 Add Action
import { createAction, props } from '@ngrx/store';
import IProduct from '../../models/IProduct.dto';

export const LOAD_PRODUCTS = '[product] Load Products ℹ️';
export const LOAD_PRODUCTS_SUCCESS = '[product] Load Products ✔️';
export const LOAD_PRODUCTS_FAIL = '[product] Load Products ❌';

export const loadProducts = createAction(LOAD_PRODUCTS);
export const loadProductsSuccess = createAction(
  LOAD_PRODUCTS_SUCCESS,
  props<{ list: IProduct[] }>()
);
export const loadProductsFail = createAction(LOAD_PRODUCTS_FAIL, props<{ errors: string }>());
