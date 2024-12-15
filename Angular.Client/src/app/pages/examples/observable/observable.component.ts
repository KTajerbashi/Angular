import { Component, OnInit } from '@angular/core';
import {
  catchError,
  filter,
  from,
  map,
  mergeMap,
  Observable,
  of,
  take,
  tap,
} from 'rxjs';
import { concatMap, delay } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { externalModelApi } from '../../../interfaces/models/IModels';
import { NgFor, NgIf } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { DataService } from './bases/dataService';

@Component({
  selector: 'app-observable',
  imports: [NgIf, NgFor, MatButton],
  templateUrl: './observable.component.html',
  styleUrl: './observable.component.css',
})
export class ObservableComponent implements OnInit {
  constructor(private dataServiec: DataService, private http: HttpClient) {}
  numbers: Number[] = [];
  strings: string[] = [];
  objects: externalModelApi[] = [];
  ngOnInit(): void {
    this.ofExample();
    this.fromExamples();
  }
  _logger = (value: any): any => {
    console.log('Logger : ', value);
    return value;
  };
  configButtons = [
    {
      title: 'Table',
      index: 0,
      visible: false,
    },
    {
      title: 'Number',
      index: 1,
      visible: true,
    },
    {
      title: 'String',
      index: 2,
      visible: false,
    },
    {
      title: 'Object',
      index: 3,
      visible: false,
    },
  ];
  tableToggle = (index: number) => {
    this.configButtons[index].visible = !this.configButtons[index].visible;
  };

  callApi = () => {
    this.dataServiec.getPosts().subscribe({
      next: (data) => (this.objects = data),
      error: (err) => console.error(err),
    });
  };

  ofExample = () => {
    // of([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])
    //   .pipe()
    //   .subscribe((res) => {
    //     console.log('Response :', res);
    //     this.numbers = res;
    //   });
    of([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])
      .pipe(mergeMap((item) => this._logger(item)))
      .subscribe((item) => {
        // this.numbers = item;
        console.log('Res : ', item);
      });
    of([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])
      .pipe(concatMap((item) => this._logger(item)))
      .subscribe((item) => {
        console.log('ConcatMap : ', item);
      });
  };

  fromExamples = () => {
    // from([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])
    //   .pipe()
    //   .subscribe((res) => {
    //     console.log('Response A:', res);
    //     // this.numbers = res;
    //   });
    // from(of([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]))
    //   .pipe()
    //   .subscribe((res) => {
    //     console.log('Response B:', res);
    //     this.numbers = res;
    //   });

    from(of([1, 2, 3]))
      .pipe(
        mergeMap((item) => this._logger(item)),
        tap(console.log)
      )
      .subscribe((item) => {
        console.log('Res : ', item);
        // this.numbers = item;
      });
  };
}
