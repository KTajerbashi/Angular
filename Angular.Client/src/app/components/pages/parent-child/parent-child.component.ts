import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DataGridComponent } from '../data-grid/data-grid.component';
import { SearchDataComponent } from '../search-data/search-data.component';
import { IAccountProfile } from '../../../interfaces/IAccountProfile';

@Component({
  selector: 'app-parent-child',
  standalone: true,
  imports: [SearchDataComponent, DataGridComponent],
  templateUrl: './parent-child.component.html',
  styleUrl: './parent-child.component.css',
})
export class ParentChildComponent {
  dataSource: IAccountProfile[] = [
    {
      id: 531,
      name: 'Kamran',
      family: 'Tajerbashi',
      email: 'Tajerbashi@mail.com',
      password: '@Kamran',
    },
    {
      id: 345,
      name: 'Kaihan',
      family: 'Yousofi',
      email: 'Yousofi@mail.com',
      password: '@Kaihan',
    },
    {
      id: 653,
      name: 'Mohammad',
      family: 'Sharifi',
      email: 'Sharifi@mail.com',
      password: '@Mohammad',
    },
    {
      id: 7845,
      name: 'Javad',
      family: 'Karimi',
      email: 'Karimi@mail.com',
      password: '@Javad',
    },
  ];

  constructor() {}

  onNgInit(): void {}

  @Output() pushDatasource = new EventEmitter<IAccountProfile[]>();

  getData = (model: IAccountProfile) => {
    model.id = this.newId();
    this.dataSource.push(model);
    console.log('Parent Push : ', this.dataSource);
    this.pushDatasource.emit(this.dataSource);
  };

  newId = (): number => {
    return Math.floor(Math.random() * 9999999);
  };
}
