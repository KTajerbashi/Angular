import { Component, OnInit } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../services/security/auth.service';
import { CommonModule, NgIf } from '@angular/common';
import { MatToolbar } from '@angular/material/toolbar';
import { MatButton, MatIconButton } from '@angular/material/button';
import { INavModel } from '../../../interfaces/models/IModels';

@Component({
  selector: 'app-navbar',
  imports: [
    RouterLink,
    MatIcon,
    MatToolbar,
    NgIf,
    MatButton,
    MatIconButton,
    CommonModule,
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router) {}
  navList: INavModel[] = [
    { id: 1, title: 'Dashboard', link: '/dashboard', access: true, order: 1 },
    { id: 2, title: 'About', link: '/about', access: true, order: 2 },
    {
      id: 3,
      title: 'Examples',
      link: '/example-service',
      access: true,
      order: 3,
    },
    { id: 4, title: 'NGRX', link: '/ngrx', access: true, order: 4 },
    { id: 5, title: 'Users', link: '/users', access: true, order: 5 },
    { id: 6, title: 'Admin', link: '/admin', access: true, order: 6 },
  ];
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
