import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IAccountProfile } from '../../../interfaces/IAccountProfile';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-user-grid',
  standalone: true,
  imports: [NgFor],
  templateUrl: './user-grid.component.html',
  styleUrl: './user-grid.component.css',
})
export class UserGridComponent {
  @Input() dataSourceEvent: IAccountProfile[] = [];

  @Output() onRemoveEvent = new EventEmitter<number>();
  @Output() onEditEvent = new EventEmitter<number>();

  onEdit = (model: IAccountProfile) => {
    console.log('Edit Model : ', model);
    this.onEditEvent.emit(model.id);
  };
  onRemove = (model: IAccountProfile) => {
    console.log('Remove Model : ', model);
    this.onRemoveEvent.emit(model.id);
  };
}
