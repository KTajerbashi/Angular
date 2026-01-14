import { Component, OnInit, signal } from '@angular/core';
import { IZoneModel } from '../../models/ICommon.dto';
import { CommonModule } from '@angular/common';
import { concat, delay, filter, map, merge, Observable, of, Subject, tap } from 'rxjs';
import { toObservable } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-rxjs-intro',
  imports: [CommonModule],
  templateUrl: './rxjs-intro.html',
  styleUrl: './rxjs-intro.scss',
})
export class RxjsIntro implements OnInit {
  zoneData: IZoneModel[] = [
    { title: 'Golden 1', crateDate: new Date('2019/01/01') },
    { title: 'Silver 1', crateDate: new Date('2020/01/01') },
    { title: 'Teter 1', crateDate: new Date('2021/01/01') },
    { title: 'BitCoin 1', crateDate: new Date('2022/01/01') },
    { title: 'Aterium 1', crateDate: new Date('2023/01/01') },
    { title: 'Silver 1', crateDate: new Date('2024/01/01') },
    { title: 'Nvidia 1', crateDate: new Date('2025/01/01') },
    { title: 'Apple 1', crateDate: new Date('2026/01/01') },
  ];
  zoneData$ = of(this.zoneData);

  age$ = of([14, 11, 34, 12, 53, 23, 54, 32, 43, 65]);
  _age$ = of(11, 22, 99, -33, 44, 55, 66, -77, 88, 99);
  __age$ = of(0.13, 0.23, 99, 0.33, 0.43, 0.53);

  subject$ = new Subject();
  ngOnInit(): void {
    // this.zoneData$
    //   .pipe(
    //     tap((x) => {
    //       console.log('Tap : ', x);
    //     })
    //   )w
    //   .subscribe({
    //     next(value) {
    //       console.trace('Value : ', value);
    //     },
    //   });

    // this._age$.pipe(map((x) => x * 10)).subscribe((subs) => {
    //   console.error('Subs : ', subs);
    // });
    // concat(this._age$, this.__age$)
    //   .pipe(map((x) => `${x} - ${x / 2}`))
    //   .subscribe((item) => {
    //     console.log('Concat : ', item);
    //   });

    // merge(this._age$, this.__age$)
    //   // .pipe(map((x) => `${x} - ${x / 2}`))
    //   .subscribe((item) => {
    //     console.log('Merge : ', item);
    //   });
    // this._age$
    //   .pipe(
    //     // tap((x) => {console.log('tap 1 : ', x, new Date());}),
    //     delay(3),
    //     // tap((x) => {console.log('tap 2 : ', x);}),
    //     map((x) => x * 10),
    //     // tap((x) => {console.log('tap 3 : ', x);}),
    //     filter((x) => x > 100)
    //     // tap((x) => {console.log('tap 4 : ', x);})
    //   )
    //   .subscribe((item) => {
    //     console.error('Sub 1 => ', item);
    //   });

    this.subject$.subscribe((item) => {
      console.log('Subject A =>', item);
    });
    this.subject$.next(1)
    this.subject$.next(2)
    this.subject$.subscribe(item => {
      console.log('Subject B =>', item);
    })
    this.subject$.next(3)
  }
}
