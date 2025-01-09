interface IJsonPromise<T> {
  data: T;
  error: string;
  message: string;
  success: string;
  token: string;
}
