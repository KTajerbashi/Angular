import { createFeatureSelector, createSelector } from '@ngrx/store';
import { IProductStateModel } from './product.state';

const loadProductsState = createFeatureSelector<IProductStateModel>('product');
export const loadProductsData = createSelector(loadProductsState, (state) => {
  console.log('Selector', state);
  return state.list;
});
