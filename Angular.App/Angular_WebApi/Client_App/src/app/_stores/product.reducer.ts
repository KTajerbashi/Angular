import { createReducer, on } from '@ngrx/store';
import { productState } from './product.state';
import { ProductActions } from './product.action';
import { model } from '@angular/core';

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
    const _maxid = Math.max(...state.list.map((o) => o.id));
    const _newdata = { ...action.products };
    _newdata.id = _maxid + 1;
    return {
      ...state,
      list: [...state.list, _newdata],
      errormessage: '',
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
    const _newdata = state.list.map((o) => {
      return o.id === action.model.id ? action.model : o;
    });
    return {
      ...state,
      list: _newdata,
      errormessage: '',
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
