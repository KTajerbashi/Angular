import { Component, EventEmitter } from '@angular/core';
import { DataGridComponent } from '../data-grid/data-grid.component';
import { SearchDataComponent } from '../search-data/search-data.component';

@Component({
  selector: 'app-parent-child',
  standalone: true,
  imports: [SearchDataComponent],
  templateUrl: './parent-child.component.html',
  styleUrl: './parent-child.component.css'
})
export class ParentChildComponent {

  count: number = 0;

  emitter = new EventEmitter<number>();

  addCount = (): void => {
    this.count++;
    this.emitter.emit(this.count);
  };
  removeCount = (): void => {
    this.count--;
    this.emitter.emit(this.count);
  };
}
