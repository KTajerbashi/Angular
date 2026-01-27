import { Component } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {
  constructor(
    private _accountService: AccountService,
    private router: Router,
    private activeRouter: ActivatedRoute,
  ) {}

  logout() {
    this._accountService.singout();
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
