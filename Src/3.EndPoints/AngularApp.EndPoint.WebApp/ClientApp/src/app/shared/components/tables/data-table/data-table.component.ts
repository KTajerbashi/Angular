import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-data-table',
  imports: [],
  templateUrl: './data-table.component.html',
  styleUrl: './data-table.component.scss',
})
export class DataTableComponent {
  @Input({ required: true }) entityName!: string;
  @Input({ required: true }) actionName!: string;
  @Input({ required: true }) configOptions!: IDataTableConfig;

  data: any[] = [];
  loading = false;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    this.loading = true;

    const url = `/api/${this.entityName}/${this.actionName}`;

    this.http.get<any[]>(url).subscribe({
      next: (res) => {
        this.data = res;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      },
    });
  }

  onEvent(eventName: string, row: any): void {
    console.log(`Event: ${eventName}`, row);
  }
}

export interface IDataColumn {
  name: string; // property name from API
  title: string; // column header text
  hasFilter?: boolean; // optional
  sortable?: boolean; // optional
}

export interface IDataTableConfig {
  columns: IDataColumn[];
  events?: {
    name: string; // edit | delete | view | custom
    label: string;
  }[];
}
