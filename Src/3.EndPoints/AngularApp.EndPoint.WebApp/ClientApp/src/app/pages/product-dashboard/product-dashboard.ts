import { Component, effect, inject, OnInit, signal } from '@angular/core';
import { ProductService } from '../../services/product.service';
import IProduct from '../../models/IProduct.dto';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-dashboard',
  imports: [ReactiveFormsModule],
  templateUrl: './product-dashboard.html',
  styleUrl: './product-dashboard.scss',
})
export class ProductDashboard implements OnInit {
  guidGenerator(): string {
    return 'baf8e979-a4cb-4c8e-b711-9ed671ed639e';
  }
  datalist: IProduct[] = [];
  _datalist = signal<IProduct[]>([]);
  requestCount: number = 0;
  ngOnInit(): void {
    this.onReload();
  }
  productForm: FormGroup;
  constructor(private builder: FormBuilder) {
    this.productForm = builder.group({
      title: this.builder.control('', Validators.required),
      price: this.builder.control(1, Validators.compose([Validators.required, Validators.min(1)])),
      rate: this.builder.control(
        1,
        Validators.compose([Validators.required, Validators.min(1), Validators.max(5)])
      ),
    });
  }
  productService = inject(ProductService);

  updateList(data: any) {
    this.datalist = data as IProduct[];
    this._datalist.set(data as IProduct[]);
  }
  onCreate() {
    console.log('Form : ', this.productForm);
    if (!this.productForm.valid) {
      alert('❌ Form is not valid ❗❗❗');
      return;
    }

    let entity: IProduct = {
      key: this.guidGenerator(),
      title: this.productForm.value.title as string,
      price: this.productForm.value.price as number,
      rate: this.productForm.value.rate as number,
    };
    this.productService.add(entity).subscribe({
      next: (data) => {
        console.log('next => onCreate :', data);
        this.updateList(data);
        this.productForm.reset()
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
    this.productService.remove(model.key).subscribe({
      next: (data) => {
        console.log('next => onRemove :', data);
        this.updateList(data);
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
        this.updateList(data);
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
    this.productService.getById(model.key).subscribe({
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
        this.updateList(data);
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
        this.updateList(data);
      },
      error: (error) => {
        console.log('error => onReload :', error);
      },
      complete: () => {
        console.log('complete => onReload');
      },
    });
  }

  increase() {
    this.requestCount += 10;
  }
}
