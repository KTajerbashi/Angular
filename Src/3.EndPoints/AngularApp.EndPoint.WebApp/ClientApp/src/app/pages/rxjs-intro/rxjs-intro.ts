import { Component, OnInit, signal } from '@angular/core';
import { IZoneModel } from '../../models/ICommon.dto';
import { CommonModule } from '@angular/common';
import { concat, merge, Observable, of, tap } from 'rxjs';

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
  ngOnInit(): void {
    this.zoneData$
      .pipe(
        tap((x) => {
          console.log("Tap : ",x);
        })
      )
      .subscribe({
        next(value) {
          console.log('Value : ', value);
        },
      });
  }
}
