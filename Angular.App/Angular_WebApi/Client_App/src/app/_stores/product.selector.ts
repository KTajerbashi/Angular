import { createFeatureSelector, createSelector } from '@ngrx/store';
import { IProductStateModel } from './product.state';

const getProductState = createFeatureSelector<IProductStateModel>('product');

export const getProductList = createSelector(getProductState, (state) => {
  return state.list;
});
