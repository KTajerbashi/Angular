import IBaseIdentityModel from './IBaseIdentity.dto';

export default interface IPrivielgeDTO extends IBaseIdentityModel {
  parentId?: number;
  entityName: string;
  action: string;
  title: string;
  type: number;
  command: string;
  order: number;
  children: IPrivielgeDTO[];
}
