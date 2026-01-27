import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-auth-layout',
  imports: [RouterOutlet],
  templateUrl: './auth-layout.html',
  styleUrl: './auth-layout.scss',
})
export class AuthLayout {
  constructor(
    private _acountService: AccountService,
    private router: Router,
    private activeRouter: ActivatedRoute
  ) {}
  logout() {
    this._acountService.singout();
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
