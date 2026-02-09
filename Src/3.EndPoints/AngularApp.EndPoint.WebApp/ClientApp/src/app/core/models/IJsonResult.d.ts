interface IJsonResult<TModel> {
  data: TModel;
  message: string;
  isSuccess: boolean;
}

