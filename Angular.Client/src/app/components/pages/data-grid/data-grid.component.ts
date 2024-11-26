import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IAccountProfile } from '../../../interfaces/IAccountProfile';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-data-grid',
  standalone: true,
  imports: [NgFor],
  templateUrl: './data-grid.component.html',
  styleUrl: './data-grid.component.css',
})
export class DataGridComponent implements OnInit {
  @Input() dataSource: IAccountProfile[] = [];
  ngOnInit(): void {
    console.log('Data : ', this.dataSource);
  }

  deleteRow = (model: IAccountProfile) => {
    console.log('DeleteRow Model : ', model);
    this.dataSource = this.dataSource.filter((item) => item.id != model.id);
  };
  updateRow = (model: IAccountProfile) => {
    console.log('UpdateRow Model : ', model);
  };
}
