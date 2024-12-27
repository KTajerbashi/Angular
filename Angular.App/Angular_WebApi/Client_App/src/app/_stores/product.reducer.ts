import { createReducer, on } from '@ngrx/store';
import { productState } from './product.state';
import { ProductActions } from './product.action';

const _productReducer = createReducer(
  productState,
  on(ProductActions.loadProductSuccess, (state, action) => {
    console.log('Reducer Success State: ', state);
    console.log('Reducer Success Action: ', action);
    return {
      ...state,
      list: action.products,
      errorMessages: '',
    };
  }),
  on(ProductActions.loadProductFail, (state, action) => {
    console.log('Reducer Fail State: ', state);
    console.log('Reducer Fail Action: ', action);
    return {
      ...state,
      list: [],
      errorMessages: action.errorMessage,
    };
  })
);

export function ProductReducer(state: any, action: any) {
  return _productReducer(state, action);
}
