import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { IProductModel } from '../../../_stores/product.model';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { NewProductComponent } from './new-product/new-product.component';
import { MatButton } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { loadProductsData } from '../../../_stores/product.selector';
import { ProductActions } from '../../../_stores/product.action';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-products',
  imports: [
    MatButton,
    MatFormFieldModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatInputModule,
    CommonModule,
  ],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css',
})
export class ProductsComponent implements OnInit, AfterViewInit {
  displayColumn: string[] = [
    'id',
    'name',
    'description',
    'price',
    'status',
    'action',
  ];
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
    this.loadData();
  }

  ngAfterViewInit(): void {}
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  loadData = () => {
    this.store.dispatch(ProductActions.loadProduct());
    this.store.select(loadProductsData).subscribe((response) => {
      this.loadDataSource(response);
    });
  };
  openDialog(
    enterAnimationDuration: string,
    exitAnimationDuration: string
  ): void {
    this.dialog.open(NewProductComponent, {
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

  loadDataSource = (data: IProductModel[]) => {
    console.log('loadDataSource : ', data);
    this.productList = data;
    this.dataSource = new MatTableDataSource(this.productList);
    this.dataSource.paginator = this.paginator;
    this.sort = this.sort;
  };
}
