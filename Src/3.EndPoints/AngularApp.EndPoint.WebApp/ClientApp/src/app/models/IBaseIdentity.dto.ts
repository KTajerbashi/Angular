export default interface IBaseIdentityModel {
  id?: number;
  entityId?: string;
  message?: string;
  isSuccess?: boolean;
  errorMessages?: string[];
}
