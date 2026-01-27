import { Component, signal } from '@angular/core';
import { Store } from '@ngrx/store';
import { loadProfile, loadProfileModel } from '../../../store/userState/userstate.flow.store';
import IProfileDTO from '../../../models/IUserProfile.dto';

@Component({
  selector: 'app-profile',
  imports: [],
  templateUrl: './profile.html',
  styleUrl: './profile.scss',
})
export class Profile {
  constructor(private store: Store) {}
  model = signal<IProfileDTO>(<IProfileDTO>{});

  dispatchProfile() {
    this.store.dispatch(loadProfile());
  }
  selectProfile() {
    this.store.select(loadProfileModel).subscribe((item) => {
      this.model.update((x) => item as IProfileDTO);
    });
    console.log(this.model())
  }
}
