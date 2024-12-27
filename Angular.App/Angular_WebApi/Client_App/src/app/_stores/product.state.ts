import { IProductModel } from './product.model';

export interface IProductStateModel {
  list: IProductModel[];
  errorMessages: string;
  loading: boolean;
  selectedProduct?: IProductModel;
}

export const productState: IProductStateModel = {
  list: [],
  errorMessages: '',
  loading: false,
  selectedProduct: undefined,
};
