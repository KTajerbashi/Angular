import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/security/auth.service';
import {
  MatCard,
  MatCardContent,
  MatCardHeader,
  MatCardTitle,
} from '@angular/material/card';
import { NgIf } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { ISignInModel } from '../../../interfaces/models/IUser';

@Component({
  selector: 'app-signin',
  imports: [
    MatCardContent,
    ReactiveFormsModule,
    MatCard,
    MatFormFieldModule,
    NgIf,
    MatInput,
    MatButton,
  ],
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.css',
})
export class SigninComponent implements OnInit {
  signinForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.signinForm = this.fb.group({
      name: ['', Validators.required],
      family: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {}

  onSubmit(): void {
    if (this.signinForm.valid) {
      let parameter: ISignInModel = {
        name: this.signinForm.value.name as string,
        family: this.signinForm.value.family as string,
        email: this.signinForm.value.email as string,
        phoneNumber: this.signinForm.value.phoneNumber as string,
        userName: this.signinForm.value.username as string,
        password: this.signinForm.value.password as string,
        rePassword: this.signinForm.value.password as string,
      };
      this.authService.signin(parameter).subscribe({
        next: (res) => {
          console.log('Res On : ', res);
        },
        complete: () => {
          console.log('Complete On : ');
        },
        error: (err) => {
          console.log('Error On : ', err);
        },
      });
    }
  }
}
