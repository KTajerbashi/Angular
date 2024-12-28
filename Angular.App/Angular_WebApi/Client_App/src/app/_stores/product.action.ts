import { createAction, props } from '@ngrx/store';
import { IProductModel } from './product.model';

export enum ProductAction {
  LOAD_PRODUCTS = '[product] load products',
  LOAD_PRODUCTS_SUCCESS = '[product] load products success',
  LOAD_PRODUCTS_FAIL = '[product] load products fail',

  CREATE_PRODUCT = '[product] create product',
  CREATE_PRODUCT_SUCCESS = '[product] create product success',
  CREATE_PRODUCT_FAIL = '[product] create product fail',

  UPDATE_PRODUCT = '[product] update product',
  UPDATE_PRODUCT_SUCCESS = '[product] update product success',
  UPDATE_PRODUCT_FAIL = '[product] update product fail',

  DELETE_PRODUCT = '[product] delete product',
  DELETE_PRODUCT_SUCCESS = '[product] delete product success',
  DELETE_PRODUCT_FAIL = '[product] delete product fail',

  GETBYID_PRODUCT = '[product] get product',
  GETBYID_PRODUCT_SUCCESS = '[product] get product success',
  GETBYID_PRODUCT_FAIL = '[product] get product fail',
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

  createProduct: createAction(
    ProductAction.CREATE_PRODUCT,
    props<{ model: IProductModel }>()
  ),
  createProductSuccess: createAction(
    ProductAction.CREATE_PRODUCT_SUCCESS,
    props<{ products: IProductModel }>()
  ),
  createProductFail: createAction(
    ProductAction.CREATE_PRODUCT_FAIL,
    props<{ errorMessage: string }>()
  ),

  updateProduct: createAction(
    ProductAction.UPDATE_PRODUCT,
    props<{ model: IProductModel }>()
  ),
  updateProductSuccess: createAction(
    ProductAction.UPDATE_PRODUCT_SUCCESS,
    props<{ model: IProductModel }>()
  ),
  updateProductFail: createAction(
    ProductAction.UPDATE_PRODUCT_FAIL,
    props<{ errorMessage: string }>()
  ),

  deleteProduct: createAction(
    ProductAction.DELETE_PRODUCT,
    props<{ id: number }>()
  ),
  deleteProductSuccess: createAction(
    ProductAction.DELETE_PRODUCT_SUCCESS,
    props<{ products: IProductModel[] }>()
  ),
  deleteProductFail: createAction(
    ProductAction.DELETE_PRODUCT_FAIL,
    props<{ errorMessage: string }>()
  ),

  getbyIdProduct: createAction(
    ProductAction.GETBYID_PRODUCT,
    props<{ id: number }>()
  ),
  getbyIdProductSuccess: createAction(
    ProductAction.GETBYID_PRODUCT_SUCCESS,
    props<{ model: IProductModel }>()
  ),
  getbyIdProductFail: createAction(
    ProductAction.GETBYID_PRODUCT_FAIL,
    props<{ errorMessage: string }>()
  ),
  emptyAction: createAction('empty'),
};
