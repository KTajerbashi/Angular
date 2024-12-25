import {
  Component,
  inject,
  OnInit,
  ChangeDetectionStrategy,
  ViewChild,
  AfterViewInit,
} from '@angular/core';
import { NgFor } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatButtonModule } from '@angular/material/button';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { CreateProductComponent } from './children/create-product/create-product.component';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { Store } from '@ngrx/store';
import { loadProducts } from '../../../_stores/product.action';
import { getProductList } from '../../../_stores/product.selector';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { IProductModel } from '../../../_stores/product.model';
@Component({
  selector: 'app-sample-a',
  imports: [
    // NgFor,
    MatButton,
    MatButton,
    MatFormFieldModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatInputModule,
  ],
  templateUrl: './sample-a.component.html',
  styleUrl: './sample-a.component.css',
})
export class SampleAComponent implements OnInit, AfterViewInit {
  displayColumn: string[] = ['id', 'name', 'description', 'price', 'status'];
  dataSource!: MatTableDataSource<IProductModel>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  productList: IProductModel[] = [
    {
      id: 1,
      name: 'Product Title',
      description: 'Poduct desc',
      price: 25000,
      status: true,
    },
  ];
  constructor(private dialog: MatDialog, private store: Store) {}
  ngOnInit(): void {
    this.dataSource = new MatTableDataSource<IProductModel>([]); // Initialize with empty data
  }

  ngAfterViewInit(): void {
    this.loadProduct();
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  loadProduct = () => {
    this.store.dispatch(loadProducts());
    this.store.select(getProductList).subscribe((res) => {
      console.log('RES : ', res);
      this.productList = res;
      this.dataSource = new MatTableDataSource(this.productList);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  };
  openDialog(
    enterAnimationDuration: string,
    exitAnimationDuration: string
  ): void {
    this.dialog.open(CreateProductComponent, {
      width: '1000px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }
  onEdit = (item: IProductModel) => {
    console.log('onEdit : ', item);
  };
  onDelete = (item: IProductModel) => {
    console.log('onDelete : ', item);
  };
  onRead = (item: IProductModel) => {
    console.log('onRead : ', item);
  };
}
