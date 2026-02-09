interface IPagingModel<TModel> {
  data: TModel[];
  take: number;
  pageNumber: number;
  query: string;
  columnSort: string;
}

interface IPagingRequest {
  take: number;
  pageNumber: number;
  query: string;
  columnSort: string;
}
