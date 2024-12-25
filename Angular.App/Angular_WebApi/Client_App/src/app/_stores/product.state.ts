import { IProductModel } from './product.model';

export interface IProductStateModel {
  list: IProductModel[];
  errorMessages: string;
}

export const productState: IProductStateModel = {
  list: [],
  errorMessages: '',
};
