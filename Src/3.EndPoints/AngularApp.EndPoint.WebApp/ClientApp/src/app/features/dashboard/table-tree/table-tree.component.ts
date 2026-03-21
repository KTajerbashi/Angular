import { CommonModule } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';

@Component({
  selector: 'app-table-tree',
  standalone: true,
  templateUrl: './table-tree.component.html',
  styleUrl: './table-tree.component.scss',
  imports: [CommonModule],
})
export class TableTreeComponent implements OnInit {
  ngOnInit(): void {
    this.loadData();
  }
  datasource = signal<IChartTreeDTO[]>([]);

  expanded = signal<Record<number, boolean>>({}); // وضعیت باز/بسته بودن هر نود

  toggle(id: number) {
    const current = this.expanded()[id];
    this.expanded.update((v) => ({ ...v, [id]: !current }));
  }

  isExpanded(id: number) {
    return !!this.expanded()[id];
  }

  onAddChild(node: IChartTreeDTO) {
    console.log('onAddChild : ', node);
  }
  onUpdate(node: IChartTreeDTO) {
    console.log('onUpdate : ', node);
  }
  onRemove(node: IChartTreeDTO) {
    console.log('onRemove : ', node);
  }
  onExtendedProperty(node: IChartTreeDTO) {
    console.log('onExtendedProperty : ', node);
  }
  onExcelFile(node: IChartTreeDTO) {
    console.log('onExcelFile : ', node);
  }
  onOwner(node: IChartTreeDTO) {
    console.log('onOwner : ', node);
  }

  loadData() {
    const data: IChartTreeDTO[] = [
      {
        id: 1,
        title: 'شهرداری',
        parentId: null,
        children: [
          {
            id: 10,
            title: 'تهران',
            parentId: 1,
            children: [
              { id: 101, title: 'منطقه 1', parentId: 10, children: [] },
              { id: 102, title: 'منطقه 2', parentId: 10, children: [] },
              { id: 103, title: 'منطقه 3', parentId: 10, children: [] },
            ],
          },
          {
            id: 11,
            title: 'خراسان رضوی',
            parentId: 1,
            children: [
              { id: 111, title: 'مشهد', parentId: 11, children: [] },
              { id: 112, title: 'نیشابور', parentId: 11, children: [] },
              { id: 113, title: 'سبزوار', parentId: 11, children: [] },
            ],
          },
        ],
      },
      {
        id: 2,
        title: 'سازمان',
        parentId: null,
        children: [
          {
            id: 10,
            title: 'تهران',
            parentId: 1,
            children: [
              { id: 101, title: 'منطقه 1', parentId: 10, children: [] },
              { id: 102, title: 'منطقه 2', parentId: 10, children: [] },
              { id: 103, title: 'منطقه 3', parentId: 10, children: [] },
            ],
          },
          {
            id: 11,
            title: 'خراسان رضوی',
            parentId: 1,
            children: [
              { id: 111, title: 'مشهد', parentId: 11, children: [] },
              { id: 112, title: 'نیشابور', parentId: 11, children: [] },
              { id: 113, title: 'سبزوار', parentId: 11, children: [] },
            ],
          },
        ],
      },
    ];

    this.datasource.set(data);
  }
}
