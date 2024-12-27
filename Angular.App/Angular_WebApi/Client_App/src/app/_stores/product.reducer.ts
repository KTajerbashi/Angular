import { createReducer, on } from '@ngrx/store';
import { productState } from './product.state';
import { ProductActions } from './product.action';

const _productReducer = createReducer(
  productState,
  on(ProductActions.loadProductSuccess, (state, action) => {
    return {
      ...state,
      list: action.products,
      errorMessages: '',
    };
  }),
  on(ProductActions.loadProductFail, (state, action) => {
    return {
      ...state,
      list: [],
      errorMessages: action.errorMessage,
    };
  }),
  on(ProductActions.createProductSuccess, (state, action) => {
    const _newData = { ...action.products };
    return {
      ...state,
      list: [...state.list, ..._newData],
    };
  }),
  on(ProductActions.createProductFail, (state, action) => {
    return {
      ...state,
      list: [],
      errorMessages: '',
    };
  }),
  on(ProductActions.updateProductSuccess, (state, action) => {
    const _newData = { ...action.products };
    return {
      ...state,
      list: [...state.list, ..._newData],
    };
  }),
  on(ProductActions.updateProductFail, (state, action) => {
    return {
      ...state,
      list: [],
      errorMessages: '',
    };
  }),
  on(ProductActions.deleteProductSuccess, (state, action) => {
    return {
      ...state,
      list: [...action.products],
    };
  }),
  on(ProductActions.deleteProductFail, (state, action) => {
    return {
      ...state,
      list: [],
      errorMessages: '',
    };
  }),
  on(ProductActions.getbyIdProductSuccess, (state, action) => {
    return {
      ...state,
      list: [...state.list],
    };
  }),
  on(ProductActions.getbyIdProductFail, (state, action) => {
    return {
      ...state,
      list: [],
      errorMessages: '',
    };
  })
);

export function ProductReducer(state: any, action: any) {
  return _productReducer(state, action);
}
