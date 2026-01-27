import IBaseIdentityModel from "./IBaseIdentity.dto";

export default interface IUserDTO extends IBaseIdentityModel {
  username: string;
  displayName: string;
  email: string;
}
