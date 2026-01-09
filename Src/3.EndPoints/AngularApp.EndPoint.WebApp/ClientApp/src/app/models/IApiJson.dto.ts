export default interface IApiJson<T> {
  message: string;
  data: T;
  isSuccess: boolean;
}
