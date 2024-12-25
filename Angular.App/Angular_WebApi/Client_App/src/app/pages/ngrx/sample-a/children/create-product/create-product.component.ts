import { Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  Validators,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ApiService } from '../../../../../bases/services/api.service';
import { ToastrService } from 'ngx-toastr';
import { MatCard, MatCardHeader } from '@angular/material/card';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { NgFor, NgIf } from '@angular/common';
import { Store } from '@ngrx/store';
import {
  createProducts,
  updateProducts,
} from '../../../../../_stores/product.action';
import { IProductModel } from '../../../../../_stores/product.model';
@Component({
  selector: 'app-create-product',
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
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})
export class CreateProductComponent implements OnInit {
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
    private dialogRef: MatDialogRef<CreateProductComponent>,
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
