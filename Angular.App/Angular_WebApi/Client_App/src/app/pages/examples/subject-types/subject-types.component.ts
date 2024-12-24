import { Component, OnInit } from '@angular/core';
import { AsyncSubject, BehaviorSubject, ReplaySubject, Subject } from 'rxjs';

@Component({
  selector: 'app-subject-types',
  imports: [],
  templateUrl: './subject-types.component.html',
  styleUrl: './subject-types.component.css',
})
export class SubjectTypesComponent implements OnInit {
  subject$ = new Subject();
  behaviorSubject$ = new BehaviorSubject(1);
  replaySubject$ = new ReplaySubject(1);
  asyncSubject$ = new AsyncSubject();

  ngOnInit(): void {
    this.subjectRun();
    this.behaviorSubject();
    this.replaySubject();
    this.asyncSubject();
  }

  subjectRun() {
    this.logger('===========  Subject  ===========', 'yellow');
    this.logger('Subscribe 1', 'black');
    this.subject$.subscribe((item) => {
      this.logger(`Subject Observe 1 ${item}`, 'red');
    });
    this.subject$.next(1);
    this.subject$.next(2);
    this.logger('Subscribe 2', 'black');
    this.subject$.subscribe((item) => {
      this.logger(`Subject Observe 2 ${item}`, 'green');
    });
    this.subject$.next(3);
    this.subject$.next(4);
  }
  behaviorSubject() {
    this.logger('===========  Behavior Subject  ===========', 'yellow');
    this.logger('Subscribe 1', 'black');
    this.behaviorSubject$.subscribe((item) => {
      this.logger(`Behavior Subject Observe 1 ${item}`, 'red');
    });
    this.behaviorSubject$.next(1);
    this.behaviorSubject$.next(2);
    this.logger('Subscribe 2', 'black');
    this.behaviorSubject$.subscribe((item) => {
      this.logger(`Behavior Subject Observe 1 ${item}`, 'green');
    });
    this.behaviorSubject$.next(3);
    this.behaviorSubject$.next(4);
  }
  replaySubject() {
    this.logger('===========  Replay Subject  ===========', 'yellow');
    this.logger('Subscribe 1', 'black');
    this.replaySubject$.subscribe((item) => {
      this.logger(`Replay Subject Observe 1 ${item}`, 'red');
    });
    this.replaySubject$.next(1);
    this.replaySubject$.next(2);
    this.logger('Subscribe 2', 'black');
    this.replaySubject$.subscribe((item) => {
      this.logger(`Replay Subject Observe 2 ${item}`, 'green');
    });
    this.replaySubject$.next(3);
    this.replaySubject$.next(4);
  }
  asyncSubject() {
    this.logger('===========  Async Subject  ===========', 'yellow');
    this.logger('Subscribe 1', 'black');
    this.asyncSubject$.subscribe((item) => {
      this.logger(`Async Subject Observe 1 ${item}`, 'red');
    });
    this.asyncSubject$.next(1);
    this.asyncSubject$.next(2);
    this.asyncSubject$.complete();

    this.logger('Subscribe 2', 'black');

    this.asyncSubject$.subscribe((item) => {
      this.logger(`Async Subject Observe 2 ${item}`, 'green');
    });
    this.asyncSubject$.next(3);
    this.asyncSubject$.next(4);
    this.asyncSubject$.complete();
  }

  logger(text: string, color: string) {
    let _color = `color:${color};`;
    let _text = `%c ${text}`;
    console.log(_text, _color);
  }
}
