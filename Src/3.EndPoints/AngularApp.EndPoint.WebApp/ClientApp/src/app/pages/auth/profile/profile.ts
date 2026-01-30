import { Component, signal } from '@angular/core';
import { Store } from '@ngrx/store';
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

  dispatchProfile() {}
  selectProfile() {}
}
