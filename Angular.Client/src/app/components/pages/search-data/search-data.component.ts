import { Component, EventEmitter, Input, output } from '@angular/core';

@Component({
  selector: 'app-search-data',
  standalone: true,
  imports: [],
  templateUrl: './search-data.component.html',
  styleUrl: './search-data.component.css',
})
export class SearchDataComponent {
  @Input() count: number = 0;
}
