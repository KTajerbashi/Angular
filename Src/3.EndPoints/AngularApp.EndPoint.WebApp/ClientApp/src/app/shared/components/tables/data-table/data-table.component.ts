import { HttpClient } from '@angular/common/http';
import { Component, effect, EventEmitter, Input, OnInit, Output, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataTableActionEvent, IDataTableConfig } from './IModel';

@Component({
  selector: 'app-data-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './data-table.component.html',
  styleUrl: './data-table.component.scss',
})
export class DataTableComponent implements OnInit {
  ngOnInit(): void {}
  // Inputs as signals
  private _entityName = signal<string>('');
  private _actionName = signal<string>('');

  @Input({ required: true })
  set entityName(value: string) {
    this._entityName.set(value);
  }

  @Input()
  set actionName(value: string) {
    this._actionName.set(value || '');
  }

  @Input({ required: true }) configOptions!: IDataTableConfig;

  @Output() action = new EventEmitter<DataTableActionEvent>();

  // state signals
  data = signal<any[]>([]);
  loading = signal<boolean>(false);
  error = signal<any>(null);

  constructor(private http: HttpClient) {
    // 🔥 Auto load when entity/action changes
    effect(() => {
      const entity = this._entityName();
      const action = this._actionName();
      console.log('Effect');
      if (!entity) return;

      this.loadData(entity, action);
    });
  }

  private loadData(entity: string, action: string): void {
    this.loading.set(true);
    this.error.set(null);

    const url = `/api/${entity}/${action}`;

    this.http.get<any[]>(url).subscribe({
      next: (res) => {
        this.data.set(res);
        this.loading.set(false);
      },
      error: (err) => {
        this.error.set(err);
        this.loading.set(false);
      },
    });
  }

  onEvent(eventName: string, row: any): void {
    this.action.emit({ event: eventName, row });
  }
}
