interface IJsonResult<TModel> {
  data: TModel;
  message: string;
  error: string;
  token: string;
  isSuccess: boolean;
}
