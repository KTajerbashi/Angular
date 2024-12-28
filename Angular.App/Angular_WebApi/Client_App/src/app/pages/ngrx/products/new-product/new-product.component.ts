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
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { ToastrService } from 'ngx-toastr';
import { Store } from '@ngrx/store';
import { IProductModel } from '../../../../_stores/product.model';
import { ProductActions } from '../../../../_stores/product.action';
import { getProduct } from '../../../../_stores/product.selector';

@Component({
  selector: 'app-new-product',
  imports: [
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatIconModule,
  ],
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css'],
})
export class NewProductComponent implements OnInit {
  productForm!: FormGroup; // Use non-null assertion here
  isEditMode: boolean = false;
  _productinfo?: IProductModel;
  title: string = 'Create';
  constructor(
    private store: Store,
    private builder: FormBuilder,
    private ref: MatDialogRef<NewProductComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IProductModel,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    // Extract dialog data for edit mode
    console.log('this.data', this.data);
    this._productinfo = this.data;
    const editId = this.data.id;
    // Initialize the form group
    this.productForm = this.builder.group({
      id: [{ value: this._productinfo.id, disabled: true }],
      name: [this._productinfo.name, Validators.required],
      description: [this._productinfo.description, Validators.required],
      price: [this._productinfo.price, Validators.required],
      status: [this._productinfo.status],
    });

    // If in edit mode, load product details from store
    if (editId !== 0) {
      this.isEditMode = true;
      this.store.select(getProduct).subscribe((product) => {
        if (product) {
          this._productinfo = product;
          this.productForm.setValue({
            id: editId,
            name: product.name,
            description: product.description,
            price: product.price,
            status: product.status,
          });
        }
      });
    }
  }

  proceedSave(): void {
    // Check if form is valid
    if (this.productForm.valid) {
      const productData: IProductModel = {
        id: this._productinfo?.id!,
        name: this.productForm.value.name,
        description: this.productForm.value.description,
        price: this.productForm.value.price,
        status: this.productForm.value.status,
      };

      if (this.isEditMode) {
        this.store.dispatch(
          ProductActions.updateProduct({ model: productData })
        );
      } else {
        this.store.dispatch(
          ProductActions.createProduct({ model: productData })
        );
      }

      // Reset the form and close the dialog
      this.productForm.reset();
      this.cancelPopup();
    } else {
      this.toastr.error('Please fill out all required fields');
    }
  }

  cancelPopup(): void {
    this.ref.close();
  }
}
