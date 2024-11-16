import { Component } from '@angular/core';
import { IUserModel } from '../../../../Models/generalModels';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-user-manager',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './user-manager.component.html',
  styleUrl: './user-manager.component.css',
})
export class UserManagerComponent {
  userForm: FormGroup;
  dataList: IUserModel[] = [];
  isEditMode = false;
  editUserId: number | null = null;
  paginatedData: IUserModel[] = [];
  rowsPerPage: number = 10;
  currentPage: number = 1;
  totalPages: number = 0;
  pages: number[] = [];
  constructor(private fb: FormBuilder) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      family: ['', Validators.required],
      phone: ['', Validators.required],
      nationalCode: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  ngOnInit() {
    this.loadData();
    this.paginate();
  }
  paginate() {
    const startIndex = (this.currentPage - 1) * this.rowsPerPage;
    const endIndex = startIndex + this.rowsPerPage;
    this.paginatedData = this.dataList.slice(startIndex, endIndex);
  }

  updatePagination() {
    this.pages = Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  goToPage(page: number) {
    if (page < 1 || page > this.totalPages) return;
    this.currentPage = page;
    this.paginate();
  }
  loadData(): void {
    this.dataList = [
      {
        id: 1,
        name: 'Alex',
        family: 'Mahoon',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 2,
        name: 'Narvey',
        family: 'Xaan',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 3,
        name: 'Toshio',
        family: 'Ito',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 4,
        name: 'Alexander',
        family: 'Maches',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 5,
        name: 'Obama',
        family: 'jkdnvksndv',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 6,
        name: 'Trump',
        family: 'ldvlsdv',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 7,
        name: 'Donald',
        family: 'dknvslkdv',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 8,
        name: 'Maxi',
        family: 'dvskdvn',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 9,
        name: 'Maxi',
        family: 'dvskdvn',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 10,
        name: 'Maxi',
        family: 'dvskdvn',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 11,
        name: 'Maxi',
        family: 'dvskdvn',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 12,
        name: 'Maxi',
        family: 'dvskdvn',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 13,
        name: 'Maxi',
        family: 'dvskdvn',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 14,
        name: 'Maxi',
        family: 'dvskdvn',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 15,
        name: 'Maxi',
        family: 'dvskdvn',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
    ];
    this.totalPages = Math.ceil(this.dataList.length / this.rowsPerPage);
    this.paginate();
  }
  onSubmit() {
    const user: IUserModel = {
      id: this.editUserId || 0,
      ...this.userForm.value,
    };

    if (this.isEditMode) {
      console.log('Edit', user);
      const index = this.dataList.findIndex((u) => u.id === this.editUserId);
      if (index !== -1) {
        this.dataList[index] = user;
      }
      this.isEditMode = false;
    } else {
      console.log('Add', user);
      this.dataList.push(user);
    }
    this.userForm.reset();
    // this.loadData();
  }

  onEdit(user: IUserModel) {
    this.isEditMode = true;
    this.editUserId = user.id;
    this.userForm.patchValue(user);
  }

  onDelete(user: IUserModel) {
    console.log('Delete', user);
    this.dataList = this.dataList.filter((item) => item.id != user.id);
  }
  showReadDialog(user: IUserModel) {
    console.log('Delete');
  }
}
