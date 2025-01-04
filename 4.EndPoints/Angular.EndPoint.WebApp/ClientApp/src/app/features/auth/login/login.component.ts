import { Component } from '@angular/core';
import { TkCardComponent } from '../../../shared/components/tk-card/tk-card.component';
import { TkCardContentComponent } from '../../../shared/components/tk-card-content/tk-card-content.component';
import { MatButton } from '@angular/material/button';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [TkCardComponent, TkCardContentComponent, MatButton],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
/**
 *
 */
constructor(private router:Router) {
}

  login = () => {
    localStorage.setItem('authToken', 'your-token');
    this.router.navigate(['/']);
  }
}
