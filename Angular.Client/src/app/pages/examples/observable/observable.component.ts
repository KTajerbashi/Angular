import { Component, OnInit } from '@angular/core';
import {
  catchError,
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
  ngOnInit(): void {
    // this.ofExample();
    // this.fromExamples();
    this.fromEventExample();
  }

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
    console.log(':::::::::::::: Of ::::::::::::::');
    // let data$ = of(10, 20, 30);
    let data$ = of('Kaihan');
    console.log('Of : ', data$);
    data$.subscribe((item) => {
      console.log('sub : ', item);
    });
    console.log('=============================');
  };
  fromExamples = () => {
    console.log(':::::::::::::: From ::::::::::::::');
    // let data$ = from(['A', 'B', 'C']);
    let data$ = from('Kaihan');
    console.log('From : ', data$);
    data$
      .pipe(concatMap((item) => of(item).pipe(tap(console.log))))
      .pipe(concatMap((item) => from(item).pipe(tap(console.log))))
      .subscribe((item) => {
        console.log('sub : ', item);
      });
    console.log('=============================');
  };
  fromEventExample = () => {
    console.log(':::::::::::::: From Event ::::::::::::::');
    let data$ = fromEvent(document, 'click');
    data$.subscribe((item) => console.log('From Event : ', item));
    console.log('=============================');
  };
}
