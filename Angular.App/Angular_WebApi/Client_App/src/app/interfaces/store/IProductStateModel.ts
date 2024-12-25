export interface IProductStateModel {
  list: IProductModel[];
  errorMessages: string;
}

export interface IProductModel {
  id: number;
  name: string;
  description: string;
  price: number;
  status: boolean;
}
