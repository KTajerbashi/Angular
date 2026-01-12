import { CommonModule } from '@angular/common';
import { Component, computed, effect, signal } from '@angular/core';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-signal-intro',
  imports: [CommonModule],
  templateUrl: './signal-intro.html',
  styleUrl: './signal-intro.scss',
})
export class SignalIntro {
  counter = signal<number>(0);
  players = signal<string[]>(['Ali','Karim']);
  actions : number = 0;
  totalActions = computed(() => this.players().length)
  _totalPlayer$ = toObservable(this.totalActions)
  _signalCount = toSignal(this._totalPlayer$)
  /**
   *
   */
  constructor() {
    effect(() => {
      this.actions = this.players().length;
      this.actions = this.counter();
      console.log("Effect");
    })
  }
  increase() {
    this.counter.update((x) => x + 1);
    console.log('Increase', this.counter());

  }
  reset() {
    this.counter.set(0);
    console.log('Reseted');
  }
  decrease() {
    this.counter.update((x) => x - 1);
    console.log('Decrease', this.counter());
  }

  addUser(){
    this.players.update(x => [...x,`User ${Math.round(Math.random() * 100)}`])
  }
}
