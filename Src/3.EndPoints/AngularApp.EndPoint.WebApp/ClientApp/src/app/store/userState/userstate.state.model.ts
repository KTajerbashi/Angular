import IProfileDTO from '../../models/IUserProfile.dto';

export interface IProfileStateModel {
  model: IProfileDTO;
  isAuthenticated: boolean;
  loading: boolean;
  error: string | null;
}
