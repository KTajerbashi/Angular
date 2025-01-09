import { Component, OnInit } from '@angular/core';
import { TkCardComponent } from '../../../shared/components/tk-card/tk-card.component';
import { TkCardContentComponent } from '../../../shared/components/tk-card-content/tk-card-content.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Router } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatIcon } from '@angular/material/icon';
import { NgIf } from '@angular/common';
import { AuthService } from '../../../core/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Store } from '@ngrx/store';
import { checkAuth } from '../../../store/auth/auth.actions';
import { selectIsAuthenticated } from '../../../store/auth/auth.selectors';

@Component({
  selector: 'app-login',
  imports: [
    TkCardComponent,
    TkCardContentComponent,
    MatButton,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    ReactiveFormsModule,
    MatIcon,
    NgIf,
    MatCheckboxModule,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private toastr: ToastrService,
    private store: Store
  ) {
    this.loginForm = this.fb.group({
      username: ['tajerbashi', Validators.required],
      password: ['@Tajerbashi123', Validators.required],
      rememberMe: [true],
    });
  }
  ngOnInit(): void {
    this.store.dispatch(checkAuth());
    this.store.select(selectIsAuthenticated).subscribe((item) => {
      if (item) {
        this.router.navigate(['/']);
      }
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      console.log('Login successful!', this.loginForm.value);
      let username = this.loginForm.value['username'];
      let password = this.loginForm.value['password'];
      let rememberMe = this.loginForm.value['rememberMe'] as boolean;
      let params: ILoginCommand = {
        userName: username,
        password: password,
        returnUrl: '',
        isRemember: rememberMe as boolean,
      };
      // Add your login logic here
      this.authService.login(params).subscribe({
        next: (res) => {
          if (res.success) {
            this.router.navigate(['/']);
            this.toastr.success(res.message, 'Success');
          } else {
            this.toastr.success(
              'Login Faild Creaditional Not Correct !!!',
              'Error'
            );
          }
        },
        error: (err) => {
          console.error('Error:', err);
          this.toastr.error(
            'Login Faild Creaditional Not Correct !!!',
            'Error'
          );
        },
      });
    }
  }
}
