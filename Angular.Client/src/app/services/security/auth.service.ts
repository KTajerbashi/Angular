import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUser = new BehaviorSubject<string | null>(null);

  isAuthenticated() {
    return this.currentUser.value !== null;
  }

  login(username: string) {
    this.currentUser.next(username); // Simulate a login
  }

  logout() {
    this.currentUser.next(null);
  }

  getCurrentUser() {
    return this.currentUser.asObservable();
  }
}
