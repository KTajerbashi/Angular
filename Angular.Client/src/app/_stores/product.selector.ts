import { createFeatureSelector, createSelector } from '@ngrx/store';
import {
  IProductStateModel,
} from '../interfaces/store/IProductStateModel';

const getProductState = createFeatureSelector<IProductStateModel>('product');

export const getProductList = createSelector(getProductState, (state) => {
  return state.list;
});