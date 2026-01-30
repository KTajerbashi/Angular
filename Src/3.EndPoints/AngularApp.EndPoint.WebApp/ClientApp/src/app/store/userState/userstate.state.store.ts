import IProfileDTO from '../../models/IUserProfile.dto';
import { IProfileStateModel } from './userstate.state.model';

// Step 1
export const ProfileState: IProfileStateModel = {
  model: <IProfileDTO>{},
  isAuthenticated: false,
  loading: false,
  error: null,
};
