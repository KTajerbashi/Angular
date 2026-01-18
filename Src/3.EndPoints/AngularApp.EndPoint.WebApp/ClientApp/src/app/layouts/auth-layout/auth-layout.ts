import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-auth-layout',
  imports: [RouterOutlet],
  templateUrl: './auth-layout.html',
  styleUrl: './auth-layout.scss',
})
export class AuthLayout {
  constructor(
    private _loginService: LoginService,
    private router: Router,
    private activeRouter: ActivatedRoute
  ) {}
  logout() {
    this._loginService.Singout();
  }
  profile() {
    this.router.navigateByUrl('auth/profile');
  }
  login() {
    this.router.navigateByUrl('auth/login');
  }
  signup() {
    this.router.navigateByUrl('auth/sign-up');
  }
}
