export interface IProductStateModel {
    list: IProductModel[];
    errorMessages: string;
  }
  
  export interface IProductModel {
    id: number;
    title: string;
    link: string;
    access: boolean;
    order: number;
  }
  