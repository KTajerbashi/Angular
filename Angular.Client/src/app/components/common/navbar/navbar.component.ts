import { Component, OnInit } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../services/security/auth.service';
import { NgIf } from '@angular/common';
import { MatToolbar } from '@angular/material/toolbar';
import { MatButton, MatIconButton } from '@angular/material/button';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink, MatIcon, MatToolbar, NgIf, MatButton, MatIconButton],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router) {}
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
  displayName: string = '';
  ngOnInit(): void {
    let info = this.authService.currentUserInfo();
    this.displayName = `${info.name} ${info.family}`;
  }
}
