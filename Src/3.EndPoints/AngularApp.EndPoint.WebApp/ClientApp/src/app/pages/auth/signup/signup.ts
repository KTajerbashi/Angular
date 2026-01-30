import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import IProfileDTO from '../../../models/IUserProfile.dto';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-signup',
  imports: [CommonModule, FormsModule],
  templateUrl: './signup.html',
  styleUrl: './signup.scss',
})
export class Signup {
  /**
   *
   */
  constructor(private store: Store) {}
  handler(form: any) {
    console.log('Form :', form);
  }
  model = signal<IProfileDTO>(<IProfileDTO>{});

  selectProfile() {}
}
