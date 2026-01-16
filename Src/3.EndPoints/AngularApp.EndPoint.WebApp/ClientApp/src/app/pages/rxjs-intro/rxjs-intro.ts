import { Component, OnInit, signal } from '@angular/core';
import { IZoneModel } from '../../models/ICommon.dto';
import { CommonModule } from '@angular/common';
import {
  AsyncSubject,
  BehaviorSubject,
  concat,
  delay,
  filter,
  map,
  merge,
  Observable,
  of,
  ReplaySubject,
  Subject,
  tap,
} from 'rxjs';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-rxjs-intro',
  imports: [CommonModule],
  templateUrl: './rxjs-intro.html',
  styleUrl: './rxjs-intro.scss',
})
export class RxjsIntro implements OnInit {
  observable$ = new Observable();
  ofData$ = of(10, 12, 14, 15, 16, 17, 20, 21, 25);
  ofData = toSignal(this.ofData$);
  _ofData$ = toObservable(this.ofData);

  subject$ = new Subject();
  behaviorSubject$ = new BehaviorSubject(1);
  replaySubject$ = new ReplaySubject();
  asyncSubject$ = new AsyncSubject();

  ngOnInit(): void {
    this.observable$.subscribe((item) => {
      console.log('Observable : ', item);
    });
    this.ofData$.pipe(map(x => x * 10)).subscribe((item) => {
      console.log('ofData$ : ', item);
    });
    this._ofData$.subscribe((item) => {
      console.log('_ofData$ : ', item);
    });

    this.subject$.subscribe((item) => {
      console.log('subject$ : ', item);
    });
    this.behaviorSubject$.subscribe((item) => {
      console.log('behaviorSubject$ : ', item);
    });
    this.replaySubject$.subscribe((item) => {
      console.log('replaySubject$ : ', item);
    });
    this.asyncSubject$.subscribe((item) => {
      console.log('asyncSubject$ : ', item);
    });
  }
}
