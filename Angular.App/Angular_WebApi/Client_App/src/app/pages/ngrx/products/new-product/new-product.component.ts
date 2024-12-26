import { NgIf } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { ApiService } from '../../../../bases/services/api.service';
import { ToastrService } from 'ngx-toastr';
import { Store } from '@ngrx/store';
import { IProductModel } from '../../../../_stores/product.model';
import {
  createProducts,
  updateProducts,
} from '../../../../_stores/product.action';

@Component({
  selector: 'app-new-product',
  imports: [
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    NgIf,
    ReactiveFormsModule,
  ],
  templateUrl: './new-product.component.html',
  styleUrl: './new-product.component.css',
})
export class NewProductComponent implements OnInit {
  productForm!: FormGroup;
  isEditMode: boolean = false;
  _dialogdata: {
    id: number;
    title: string;
  } = {
    id: 0,
    title: '',
  };
  constructor(
    private apiService: ApiService,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<NewProductComponent>,
    @Inject(MAT_DIALOG_DATA) public dialogData: { id: number },
    private toastr: ToastrService,
    private store: Store
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    if (this.dialogData?.id) {
      this.isEditMode = true;
      this.loadProductDetails(this.dialogData.id);
    }
  }

  private initializeForm(): void {
    this.productForm = this.formBuilder.group({
      id: [{ value: 0, disabled: true }],
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: [1, [Validators.required, Validators.min(0)]],
      status: [true],
    });
  }

  private loadProductDetails(productId: number): void {
    this.apiService.get<IProductModel>(`GetById/${productId}`).subscribe(
      (response) => {
        const product = response.data;
        this.productForm.patchValue({
          id: product.id,
          name: product.name,
          description: product.description,
          price: product.price,
          status: product.status,
        });
      },
      (error) => {
        this.toastr.error('Failed to load product details.', 'Error');
      }
    );
  }

  saveProduct(): void {
    if (this.productForm.invalid) {
      this.toastr.warning('Please fill out the required fields.', 'Warning');
      return;
    }

    const productData: IProductModel = {
      id: this.isEditMode ? this.dialogData.id : 0,
      name: this.productForm.get('name')?.value,
      description: this.productForm.get('description')?.value,
      price: this.productForm.get('price')?.value,
      status: this.productForm.get('status')?.value,
    };

    if (this.isEditMode) {
      this.updateProduct(productData);
    } else {
      this.createProduct(productData);
    }
  }

  private updateProduct(product: IProductModel): void {
    this.store.dispatch(updateProducts());
  }

  private createProduct(product: IProductModel): void {
    this.store.dispatch(createProducts());
  }

  closeDialog(): void {
    this.dialogRef.close();
  }
}
