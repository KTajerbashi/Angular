import { Component, effect, OnInit, signal } from '@angular/core';
import { IUser } from '../../../../interfaces/models/IModels';
import { MatButton } from '@angular/material/button';
import { interval, Subscription } from 'rxjs';
import { ApiService } from '../../../../bases/services/api.service';
@Component({
  selector: 'app-signal',
  imports: [MatButton],
  templateUrl: './signal.component.html',
  styleUrl: './signal.component.css',
})
export class SignalComponent implements OnInit {
  _interval!: Subscription;
  constructor(private apiService: ApiService) {
    effect(() => {
      this.requestCount = this.apiService.getRequestCount();
    });
  }
  ngOnInit(): void {
    this.startInterval();
  }
  _counter = signal<number>(10);
  _curentDate = signal<Date>(new Date());
  _name = signal<string>('Tajerbashi');
  getInfo = (): IUser => {
    let token = localStorage.getItem('token') ?? '';
    let obj = JSON.parse(token).token;
    console.log(obj);
    let user: IUser = {
      id: obj.id,
      name: obj.name,
      family: obj.family,
      email: obj.email,
      phoneNumber: obj.phoneNumber,
      username: obj.userName,
      password: obj.passwordHash,
      roleId: 0,
      isActive: true,
    };
    return user;
  };
  _currentInfo = signal<IUser>(this.getInfo());

  removeCounter() {
    this._counter.set(this._counter() - 1);
  }
  addCounter() {
    this._counter.set(this._counter() + 1);
  }

  updateDate = () => {
    this._curentDate.set(new Date());
  };
  clearInterval = () => {
    this._interval.unsubscribe();
  };
  startInterval = () => {
    this._interval = interval(1000).subscribe(() => {
      this.updateDate();
    });
  };

  requestCount: number = 0;
  getRequestCount = () => {
    this.requestCount = this.apiService.getRequestCount();
  };
  addRequestCount = () => {
    this.apiService.addRequestCount();
  };
  removeRequestCount = () => {
    this.apiService.removeRequestCount();
  };
}
