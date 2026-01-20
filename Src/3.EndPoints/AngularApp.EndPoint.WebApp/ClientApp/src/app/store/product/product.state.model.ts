import IProduct from '../../models/IProduct.dto';

export interface IProductStateModel {
  list: IProduct[];
  errorMessage: string;
}
