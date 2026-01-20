//  Step 5 Add Selector After Effects

import { createFeatureSelector, createSelector } from '@ngrx/store';
import { IProductStateModel } from './product.state.model';

const getProductState = createFeatureSelector<IProductStateModel>('productStore');
export const getProductList = createSelector(getProductState, (state) => {
  return state.list;
});
