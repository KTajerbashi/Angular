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
/**
 * Token model interface for user authentication details.
 */
export interface ITokenModel {
  token: string;
  expireDate: Date;
  isLoggedIn: boolean;
}

/**
 * Token model interface for user authentication details.
 */
export interface ILoginModel {
  userName: string;
  password: string;
}

export interface ISignInModel {
  name: string;
  family: string;
  email: string;
  phoneNumber: string;
  userName: string;
  password: string;
  rePassword: string;
}
