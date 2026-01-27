import IBaseIdentityModel from "./IBaseIdentity.dto";

export default interface IRoleDTO extends IBaseIdentityModel{
  name: string;
  key: string;
}
