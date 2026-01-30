import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { login } from '../../../store/userState/userstate.action.store';
import { SelectError, SelectLoading } from '../../../store/userState/userstate.selector.store';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.scss'],
})
export class Login {
  constructor(private store:Store){
    store.dispatch()
  }

  loading$: Observable<boolean> = this.store.select(SelectLoading);
  error$: Observable<string | null> = this.store.select(SelectError);

  onLogin(form: any) {
    if (!form.valid) return;

    const { username, password } = form.value;

    // Dispatch login action to NgRx
    this.store.dispatch(login({ username, password }));
  }

  onLoginSSO() {
    // TODO: SSO login flow
  }
  onLoginGoogle() {
    // TODO: Google login flow
  }
  onLoginGithub() {
    // TODO: Github login flow
  }
}
