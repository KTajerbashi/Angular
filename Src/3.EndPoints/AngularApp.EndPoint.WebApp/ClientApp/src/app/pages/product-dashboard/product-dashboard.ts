import { Component, inject, OnInit, signal } from '@angular/core';
import { ProductService } from '../../services/product.service';
import IProduct from '../../models/IProduct.dto';

@Component({
  selector: 'app-product-dashboard',
  imports: [],
  templateUrl: './product-dashboard.html',
  styleUrl: './product-dashboard.scss',
})
export class ProductDashboard implements OnInit {
  datalist: IProduct[] = [];
  _datalist = signal<IProduct[]>([]);
  ngOnInit(): void {
    this.onReload();
  }
  productService = inject(ProductService);

  onCreate() {
    this.productService.add({}).subscribe({
      next: (data) => {
        console.log('next => onCreate :', data);
        this.datalist = data as IProduct[];
        this._datalist.set(data as IProduct[]);
      },
      error: (error) => {
        console.log('error => onCreate :', error);
      },
      complete: () => {
        console.log('complete => onCreate');
      },
    });
  }
  onRemove(model: IProduct) {
    this.productService.remove(model.id).subscribe({
      next: (data) => {
        console.log('next => onRemove :', data);
        this.datalist = data as IProduct[];
        this._datalist.set(data as IProduct[]);
      },
      error: (error) => {
        console.log('error => onRemove :', error);
      },
      complete: () => {
        console.log('complete => onRemove');
      },
    });
  }
  onUpdate(model: IProduct) {
    this.productService.update(model).subscribe({
      next: (data) => {
        console.log('next => onUpdate :', data);
        this.datalist = data as IProduct[];
        this._datalist.set(data as IProduct[]);
      },
      error: (error) => {
        console.log('error => onUpdate :', error);
      },
      complete: () => {
        console.log('complete => onUpdate');
      },
    });
  }
  onGetById(model: IProduct) {
    this.productService.getById(model.id).subscribe({
      next: (data) => {
        console.log('next => onGetById :', data);
      },
      error: (error) => {
        console.log('error => onGetById :', error);
      },
      complete: () => {
        console.log('complete => onGetById');
      },
    });
  }
  onGetAll() {
    this.productService.getAll().subscribe({
      next: (data) => {
        console.log('next => Get All :', data);
        this.datalist = data as IProduct[];
        this._datalist.set(data as IProduct[]);
      },
      error: (error) => {
        console.log('error => Get All :', error);
      },
      complete: () => {
        console.log('complete => Get All');
      },
    });
  }
  onReload() {
    this.productService.get('Reload').subscribe({
      next: (data) => {
        console.log('next => onReload :', data);
        this.datalist = data as IProduct[];
        this._datalist.set(data as IProduct[]);
      },
      error: (error) => {
        console.log('error => onReload :', error);
      },
      complete: () => {
        console.log('complete => onReload');
      },
    });
  }
}
