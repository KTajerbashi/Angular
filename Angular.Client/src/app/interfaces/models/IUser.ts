export interface IUser {
  id: number;
  roleId?: number;
  name: string;
  family: string;
  email: string;
  phoneNumber: string;
  username?: string;
  password?: string;
  isActive: boolean;
}

export interface IRole {
  id: number;
  name: string;
  title: string;
}
