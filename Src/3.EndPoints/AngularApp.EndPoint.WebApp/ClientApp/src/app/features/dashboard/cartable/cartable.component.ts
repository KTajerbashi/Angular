import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidationErrors,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';

@Component({
  selector: 'component-cartable',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './cartable.component.html',
  styleUrl: './cartable.component.scss',
})
export class CartableComponent implements OnInit {
  userForm!: FormGroup;

  constructor(private fb: FormBuilder) {
    this.userForm = this.fb.nonNullable.group({
      aggregateId: this.fb.control(12323423, [Validators.required]),
      information: this.fb.nonNullable.group({
        name: this.fb.control('', [Validators.required, Validators.minLength(5)]),
        family: this.fb.control('', [Validators.required, Validators.minLength(5)]),
        email: this.fb.control('', [Validators.required, Validators.email]),
        password: this.fb.control('', [Validators.required, Validators.minLength(5)]),
      }),
      address: this.fb.nonNullable.group({
        street: this.fb.control('', [Validators.required, Validators.minLength(3)]),
        pelak: this.fb.control(0, [Validators.required]),
      }),
    });
  }

  ngOnInit(): void {}

  get form(): FormGroup {
    return this.userForm as FormGroup;
  }

  get information(): FormGroup {
    return this.userForm.get('information') as FormGroup;
  }

  get address(): FormGroup {
    return this.userForm.get('address') as FormGroup;
  }

  getErrorMessage(control: AbstractControl | null, fieldName: string): string {
    if (!control) return '';

    if (control.hasError('required')) {
      return `${this.formatFieldName(fieldName)} اجباری است`;
    }
    if (control.hasError('minlength')) {
      const minLength = control.errors?.['minlength'].requiredLength;
      return `${this.formatFieldName(fieldName)} باید حداقل ${minLength} کاراکتر باشد`;
    }
    if (control.hasError('maxlength')) {
      const maxLength = control.errors?.['maxlength'].requiredLength;
      return `${this.formatFieldName(fieldName)} نمی‌تواند بیش از ${maxLength} کاراکتر باشد`;
    }
    if (control.hasError('email')) {
      return 'لطفا یک ایمیل معتبر وارد کنید';
    }
    if (control.hasError('pattern')) {
      if (fieldName === 'password') {
        return 'رمز عبور باید حداقل شامل یک حرف بزرگ، یک حرف کوچک و یک عدد باشد';
      }
      if (fieldName === 'aggregateId') {
        return 'فقط حروف و فاصله مجاز است';
      }
      if (fieldName === 'pelak') {
        return 'فقط اعداد مجاز است';
      }
      return `فرمت ${this.formatFieldName(fieldName)} نامعتبر است`;
    }
    return '';
  }
  private formatFieldName(fieldName: string): string {
    const fieldMap: { [key: string]: string } = {
      aggregateId: 'نام',
      name: 'نام',
      family: 'نام خانوادگی',
      email: 'ایمیل',
      password: 'رمز عبور',
      street: 'خیابان',
      pelak: 'پلاک',
    };
    return fieldMap[fieldName] || fieldName;
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      console.log('Form Submitted!', this.userForm.value);
      alert('فرم با موفقیت ثبت شد!\nاطلاعات در کنسول قابل مشاهده است.');
    } else {
      console.log('Form is invalid');
      this.markAllAsTouched();
      alert('لطفا تمام فیلدها را به درستی پر کنید');
    }
  }

  private markAllAsTouched(): void {
    Object.keys(this.userForm.controls).forEach((key) => {
      const control = this.userForm.get(key);
      if (control instanceof FormGroup) {
        Object.keys(control.controls).forEach((subKey) => {
          const subControl = control.get(subKey);
          subControl?.markAsTouched();
        });
      } else {
        control?.markAsTouched();
      }
    });
  }

  resetForm(): void {
    this.userForm.reset();
  }
}
