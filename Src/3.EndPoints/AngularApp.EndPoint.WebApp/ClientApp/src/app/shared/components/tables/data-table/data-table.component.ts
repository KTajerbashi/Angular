import { HttpClient } from '@angular/common/http';
import { Component, Input, Output, EventEmitter, signal, effect, DestroyRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-data-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './data-table.component.html',
  styleUrl: './data-table.component.scss',
})
export class DataTableComponent {
  /* ================= INPUT SIGNALS ================= */

  private entityNameSig = signal<string | null>(null);
  private actionNameSig = signal<string>('ReadDataGrid');
  protected readonly columnType = columnType;

  @Input({ required: true })
  set entityName(value: string) {
    this.entityNameSig.set(value);
  }

  @Input()
  set actionName(value: string | undefined) {
    if (value) this.actionNameSig.set(value);
  }

  @Input({ required: true })
  set config(value: IDataTableConfig) {
    this._config = value;
    this.columns.set(value.columns ?? []);
    this.events.set(value.events ?? []);
  }
  private _config!: IDataTableConfig;

  /* ================= OUTPUT ================= */

  @Output()
  action = new EventEmitter<DataTableActionEvent>();

  /* ================= STATE ================= */

  readonly rows = signal<any[]>([]);
  readonly columns = signal<IColumn[]>([]);
  readonly events = signal<IDataTableEvent[]>([]);
  readonly loading = signal(false);
  readonly error = signal<unknown | null>(null);

  /* ================= QUERY ================= */
  readonly columnFilters = signal<Record<string, unknown>>({});
  private readonly query = signal({
    pageNumber: 1,
    take: 10,
    query: '',
    columnFilters: {} as Record<string, unknown>,
  });

  constructor(
    private http: HttpClient,
    private destroyRef: DestroyRef,
  ) {
    effect(() => {
      const entity = this.entityNameSig();
      const action = this.actionNameSig();
      const query = this.query();

      if (!entity) return;

      this.fetchData(entity, action, query);
    });
  }

  /* ================= API ================= */

  private fetchData(
    entity: string,
    action: string,
    query: {
      pageNumber: number;
      take: number;
      query: string;
      columnFilters: Record<string, unknown>;
    },
  ): void {
    this.loading.set(true);
    this.error.set(null);

    const url = `/api/${entity}/${action}`;

    this.http
      .post<IJsonResult<ITableData<any>>>(url, query)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: (res) => {
          this.columns.set(res.data.columns);
          this.rows.set(res.data.rows);
          this.loading.set(false);
        },
        error: (err) => {
          this.error.set(err);
          this.loading.set(false);
        },
      });
  }

  /* ================= EVENTS ================= */
  private castFilterValue(column: IColumn, value: string): unknown {
    switch (column.columnType) {
      case columnType.Number:
      case columnType.NumberNullable:
        return Number(value);
      case columnType.Boolean:
        return value === 'true';
      case columnType.DateTime:
        return new Date(value).toISOString();
      default:
        return value;
    }
  }

  search(column: IColumn, value: string): void {
    this.columnFilters.update((filters) => {
      const updated = { ...filters };

      if (!value) {
        delete updated[column.field]; // remove filter if input is empty
      } else {
        updated[column.field] = this.castFilterValue(column, value);
      }

      this.query.update((q) => ({
        ...q,
        pageNumber: 1, // reset page
        columnFilters: updated,
      }));

      return updated;
    });
  }

  onAction(eventName: string, row: any): void {
    this.action.emit({ event: eventName, row });
  }
}

enum columnType  {
  // [Description("تاریخ")]
  DateTime = 1,

  // [Description("عدد")]
  Number = 2,

  // [Description("رشته")]
  String = 3,

  // [Description("شمارشی")]
  Enum = 4,

  // [Description("بله - خیر")]
  Boolean = 5,

  // [Description("لیست")]
  List = 6,

  // [Description("دارای عکس")]
  HasImage = 7,

  // [Description("عدد قابل نال بودن")]
  NumberNullable = 8,

  // [Description("عدد اعشاری")]
  NumberWithDecimals = 9,

  // [Description("مسیر عکس")]
  ImageUrl = 10,

  // [Description("مسیر  نسبی عکس")]
  ImageRelativeUrl = 12,

  // [Description("لینک")]
  Link = 11,
}
