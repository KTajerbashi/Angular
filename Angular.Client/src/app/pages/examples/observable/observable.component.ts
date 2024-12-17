import { Component, OnInit } from '@angular/core';
import {
  catchError,
  concat,
  filter,
  from,
  fromEvent,
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
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { DataService } from './bases/dataService';

@Component({
  selector: 'app-observable',
  imports: [NgIf, NgFor, MatButton, CommonModule],
  templateUrl: './observable.component.html',
  styleUrl: './observable.component.css',
})
export class ObservableComponent implements OnInit {
  constructor(private dataServiec: DataService, private http: HttpClient) {}

  waiting: boolean = false;
  numbers: Number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
  strings: string[] = ['A', 'B', 'C', 'D', 'E'];
  objects: externalModelApi[] = [
    { id: 1, body: 'Body 1', title: 'Title 1', userId: 1 },
    { id: 2, body: 'Body 2', title: 'Title 2', userId: 2 },
    { id: 3, body: 'Body 3', title: 'Title 3', userId: 3 },
    { id: 4, body: 'Body 4', title: 'Title 4', userId: 4 },
    { id: 5, body: 'Body 5', title: 'Title 5', userId: 5 },
    { id: 6, body: 'Body 6', title: 'Title 6', userId: 6 },
    { id: 7, body: 'Body 7', title: 'Title 7', userId: 7 },
    { id: 8, body: 'Body 8', title: 'Title 8', userId: 8 },
    { id: 9, body: 'Body 9', title: 'Title 9', userId: 9 },
    { id: 10, body: 'Body 10', title: 'Title 10', userId: 10 },
  ];
  dataList$ = of(this.objects);
  ngOnInit(): void {}
  ofMethod = () => {
    this.waiting = true;

    let res$ = of(this.objects).subscribe({
      next: (response) => {
        this.objects = response;
        console.log('Of Next : ', response);
        this.waiting = false;
      },
    });
    console.log('Of : ', res$);
  };
  dataList: externalModelApi[] = [];
  fromMethod = () => {
    this.dataList = [];
    this.waiting = true;
    var res$ = from(this.objects)
      .pipe(
        tap(console.log),
        concatMap((item) => of(item))
      )
      .subscribe({
        next: (response) => {
          console.log('From Next : ', response);
          this.dataList.push(response);
          this.waiting = false;
        },
      });
    this.objects = this.dataList;
    console.log('Data : ', this.dataList);
    console.log('From : ', res$);
  };
}
