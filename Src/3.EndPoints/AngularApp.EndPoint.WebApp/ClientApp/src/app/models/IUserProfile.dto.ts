import IBaseIdentityModel from './IBaseIdentity.dto';
import IGroupDTO from './IGroup.dto';
import IMenuDTO from './IMenu.dto';
import IPrivielgeDTO from './IPrivilege.dto';
import IRoleDTO from './IRole.dto';
import IUserDTO from './IUser.dto';
import IUserRoleDTO from './IUserRole.dto';

export default interface IProfileDTO extends IBaseIdentityModel {
  user: IUserDTO;
  role: IRoleDTO;
  roles: IRoleDTO[];
  userRoles: IUserRoleDTO[];
  groups: IGroupDTO[];
  menus: IMenuDTO[];
  privileges: IPrivielgeDTO[];
}
