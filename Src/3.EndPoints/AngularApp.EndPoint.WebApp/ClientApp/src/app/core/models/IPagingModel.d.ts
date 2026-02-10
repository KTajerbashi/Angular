interface ITableData<TModel> {
  columns: IColumn[];
  rows: TModel[];
  count: number;
  pageIndex: number;
  pageSize: number;
  pageOrder: string;
  filters: string;
}

interface IDataGridQuery {
  take: number;
  pageNumber: number;
  query: string;
  columnSort: string;
}

interface IColumn {
  title: string;
  orderNumber: number;
  field: string;
  filter: string;
  columnType: columnType;
  enumTitleValueName: string;
  entityTypeGroup: number[];
  editable: boolean;
  calculateSum: boolean;
  leftAssign: boolean;
  calculateAggregateAverage: boolean;
  needSubstring: boolean;
  functionName: string;
}

interface IDataTableEvent {
  name: string;
  label: string;
  cssClass: string;
}

interface IDataTableConfig {
  columns?: IDataColumn[];
  events?: IDataTableEvent[] | undefined;
}

interface DataTableActionEvent {
  event: string;
  row: any;
}
