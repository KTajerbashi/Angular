//  Step 3 Add Reducer

import { createReducer, on } from '@ngrx/store';
// import { state } from '@angular/animations';
import { ProductState } from './product.state.store';
import { loadProductsFail, loadProductsSuccess } from './product.action.store';

const _productReducer = createReducer(
  ProductState,
  on(loadProductsSuccess, (state, action) => {
    return {
      ...state,
      list: action.list,
      errorMessage: '',
    };
  }),
  on(loadProductsFail, (state, action) => {
    return {
      ...state,
      list: [],
      errorMessage: action.errors,
    };
  })
);

//  Register Reducer To Store
export function ProductReducer(state: any, action: any) {
  return _productReducer(state, action);
}
