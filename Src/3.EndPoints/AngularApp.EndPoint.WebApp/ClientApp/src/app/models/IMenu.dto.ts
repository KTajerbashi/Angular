import IBaseIdentityModel from "./IBaseIdentity.dto";

export default interface IMenuDTO extends IBaseIdentityModel{
  title: string;
  schema: string;
  children: IMenuDTO[];
}
