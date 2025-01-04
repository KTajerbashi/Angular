import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-auth-layout',
  imports: [RouterOutlet],
  templateUrl: './auth-layout.component.html',
  styleUrl: './auth-layout.component.css'
})
export class AuthLayoutComponent {
  constructor(private router: Router) {}

  ngOnInit(): void {
    if (localStorage.getItem('authToken')) {
      this.router.navigate(['/dashboard']); // Adjust path as needed
    }
  }
}
