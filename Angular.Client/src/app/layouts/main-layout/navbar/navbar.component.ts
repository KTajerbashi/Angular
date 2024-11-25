import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

interface menuLink {
  icon: string;
  title: string;
  url: string;
}

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'], // Ensure proper styling
})
export class NavbarComponent implements OnInit {
  menuLinks: menuLink[] = [];

  ngOnInit() {
    this.loadData();
  }

  loadData(): void {
    this.menuLinks = [
      { icon: 'home', title: 'Home', url: '/home' },
      { icon: 'features', title: 'Features', url: '/features' },
      { icon: 'pricing', title: 'Pricing', url: '/pricing' },
      { icon: 'about', title: 'About', url: '/about' },
      { icon: 'users', title: 'Users', url: '/users' },
    ];
  }
}
