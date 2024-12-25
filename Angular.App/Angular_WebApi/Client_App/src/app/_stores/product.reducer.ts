import { createReducer, on } from '@ngrx/store';
import { loadProductsFail, loadProductsSuccess } from './product.action';
import { state } from '@angular/animations';
import { productState } from './product.state';

const _proudctReducer = createReducer(
  productState,
  on(loadProductsSuccess, (state, action) => {
    return {
      ...state,
      list: action.list,
      errorMessages: '',
    };
  }),
  on(loadProductsFail, (state, action) => {
    return {
      ...state,
      list: [],
      errorMessages: action.errorMessages,
    };
  })
);
export function ProductReducer(state: any, action: any) {
  return _proudctReducer(state, action);
}
