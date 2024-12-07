export interface IUser {
  id: number;
  name: string;
  family: string;
  email: string;
  phone: string;
  password?: string;
  isActive: boolean;
}