import IBaseIdentityModel from "./IBaseIdentity.dto";

export default interface IUserRoleDTO extends IBaseIdentityModel {
  userId: number;
  roleId: number;
}
