import { createFeatureSelector, createSelector } from '@ngrx/store';
import { IProductStateModel } from './product.state';

const loadProductsState = createFeatureSelector<IProductStateModel>('product');

export const loadProductsData = createSelector(loadProductsState, (state) => {
  return state.list;
});
export const getProduct = createSelector(loadProductsState, (state) => {
  return state.selectedProduct;
});
