import IProfileDTO from '../../models/IUserProfile.dto';

export interface IProfileStateModel {
  data?: IProfileDTO;
  errorMessage: string;
}
