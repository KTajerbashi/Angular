import IBaseIdentityModel from "./IBaseIdentity.dto";

export default interface IGroupDTO extends IBaseIdentityModel{
  title: string;
  key: string;
}
