export interface IDataColumn {
  name: string;
  title: string;
}

export interface IDataTableEvent {
  name: string;
  label: string;
  cssClass: string;
}

export interface IDataTableConfig {
  columns: IDataColumn[];
  events?: IDataTableEvent[];
}

export interface DataTableActionEvent {
  event: string;
  row: any;
}
