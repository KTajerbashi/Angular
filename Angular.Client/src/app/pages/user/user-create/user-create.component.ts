import { Component } from '@angular/core';
import {
  MatCard,
  MatCardActions,
  MatCardContent,
} from '@angular/material/card';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { IUser } from '../../../interfaces/models/IUser';
import { FormsModule } from '@angular/forms';
import { convertCompilerOptionsFromJson } from 'typescript';
import { RouterLink } from '@angular/router';
import { NgIf } from '@angular/common';
@Component({
  selector: 'app-user-create',
  imports: [
    MatCard,
    MatCardContent,
    MatCardActions,
    MatFormField,
    MatLabel,
    MatInput,
    MatButtonModule,
    FormsModule,
    RouterLink,
    NgIf,
  ],
  templateUrl: './user-create.component.html',
  styleUrl: './user-create.component.css',
})
export class UserCreateComponent {
  _formModel: IUser = {
    id: 0,
    name: '',
    family: '',
    email: '',
    phone: '',
    password: '',
    isActive: false,
  };
  onSubmit = (form: any) => {
    if (form.valid) {
      console.log('Submit', this._formModel);
    } else {
      console.log('Model is Not Valid ...');
    }
  };
}
