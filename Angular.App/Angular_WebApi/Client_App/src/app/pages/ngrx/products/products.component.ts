import { Component, ViewChild } from '@angular/core';
import { IProductModel } from '../../../_stores/product.model';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { loadProducts } from '../../../_stores/product.action';
import { getProductList } from '../../../_stores/product.selector';
import { NewProductComponent } from './new-product/new-product.component';
import { MatButton } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-products',
  imports: [
    MatButton,
    MatFormFieldModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatInputModule,
  ],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css',
})
export class ProductsComponent {
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
}
