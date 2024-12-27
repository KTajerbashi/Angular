import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { IProductModel } from '../../../_stores/product.model';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../../bases/services/api.service';
import { Subscription } from 'rxjs';
import { NewProductComponent } from './new-product/new-product.component';
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
export class ProductsComponent implements OnInit, OnDestroy {
  displayedColumns: string[] = [
    'id',
    'name',
    'description',
    'price',
    'status',
    'action',
  ];
  model?: IProductModel;
  dataSource!: MatTableDataSource<IProductModel>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  subscription = new Subscription();

  constructor(private apiService: ApiService, private dialog: MatDialog) {}

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
  ngOnInit(): void {
    this.Loadproducts();
  }
  productlist: IProductModel[] = [];
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  Loadproducts() {
    let sub1 = this.apiService.get<IProductModel[]>('Product').subscribe({
      next: (response) => {
        this.productlist = response.data ?? [];
        this.dataSource = new MatTableDataSource(this.productlist);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (error) => {},
    });

    this.subscription.add(sub1);
  }
  Createproduct() {
    let model: IProductModel = {
      id: 0,
      name: '',
      description: '',
      price: 0,
      status: false,
    };
    this.Openpopup(model, 'Create Product');
  }
  Openpopup(model: IProductModel, title: string) {
    this.dialog
      .open(NewProductComponent, {
        width: '50%',
        enterAnimationDuration: '1000ms',
        exitAnimationDuration: '1000ms',
        data: model,
      })
      .afterClosed()
      .subscribe((item) => {
        this.Loadproducts();
      });
  }
  DeleteProduct(model: IProductModel) {
    if (confirm('Do you want to remove?')) {
      let sub2 = this.apiService
        .delete('Product', model.id)
        .subscribe((item) => {
          alert('Removed successfully.');
          this.Loadproducts();
        });
      this.subscription.add(sub2);
    }
  }
  EditProduct(model: IProductModel) {
    this.Openpopup(model, 'Edit Product');
  }
  ReadProduct(model: IProductModel) {
    // this.Openpopup(model, 'Edit Product');
  }
}
