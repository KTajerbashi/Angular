import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DataGridComponent } from '../data-grid/data-grid.component';
import { SearchDataComponent } from '../search-data/search-data.component';
import { IAccountProfile } from '../../../interfaces/IAccountProfile';

@Component({
  selector: 'app-parent-child',
  standalone: true,
  imports: [SearchDataComponent],
  templateUrl: './parent-child.component.html',
  styleUrl: './parent-child.component.css',
})
export class ParentChildComponent {
  constructor() {}

  @Output() getDataFromChild = new EventEmitter<IAccountProfile>();

  getData = (model: IAccountProfile) => {
    console.log('Parent Log : ', model);
  };
  pushData = () => {};
}
