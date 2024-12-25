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

export const CREAT_PRODUCTS = '[product] create products';
export const CREAT_PRODUCTS_SUCCESS = '[product] create products success';
export const CREAT_PRODUCTS_FAIL = '[product] create products faild';

export const createProducts = createAction(
  CREAT_PRODUCTS,
  props<{ model: IProductModel }>
);
export const createProductsSuccess = createAction(
  CREAT_PRODUCTS_SUCCESS,
  props<{ model: IProductModel }>()
);
export const createProductsFail = createAction(
  CREAT_PRODUCTS_FAIL,
  props<{ errorMessages: string }>()
);

export const UPDATE_PRODUCTS = '[product] update products';
export const UPDATE_PRODUCTS_SUCCESS = '[product] update products success';
export const UPDATE_PRODUCTS_FAIL = '[product] update products faild';
export const updateProducts = createAction(
  UPDATE_PRODUCTS,
  props<{ model: IProductModel }>
);
export const updateProductsSuccess = createAction(
  UPDATE_PRODUCTS_SUCCESS,
  props<{ model: IProductModel }>()
);
export const updateProductsFail = createAction(
  UPDATE_PRODUCTS_FAIL,
  props<{ errorMessages: string }>()
);

export const DELETE_PRODUCTS = '[product] delete products';
export const DELETE_PRODUCTS_SUCCESS = '[product] delete products success';
export const DELETE_PRODUCTS_FAIL = '[product] delete products faild';
