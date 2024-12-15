import { Component, inject, AfterViewInit, ViewChild } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { UserCreateComponent } from './children/user-create/user-create.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { IUser } from '../../interfaces/models/IModels';
import { ApiService } from '../../bases/services/api.service';

@Component({
  selector: 'app-user',
  imports: [
    MatButton,
    MatFormFieldModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatInputModule,
  ],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})
export class UserComponent implements AfterViewInit {
  readonly dialog = inject(MatDialog);
  dataList: IUser[] = [];

  displayedColumns: string[] = [
    'id',
    'name',
    'family',
    'email',
    'phoneNumber',
    'userName',
    'passwordHash',
    'action',
  ];
  dataSource: MatTableDataSource<IUser>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private apiService: ApiService) {
    //
    // Create 100 users
    const users = this.dataList;
    // Array.from({ length: 100 }, (_, k) => createNewUser(k + 1));
    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource(users);
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.loadData();
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  loadData = () => {
    this.apiService.get<IUser[]>('User').subscribe({
      next: (response) => {
        if (response.success) {
          this.dataList = response.data;
          this.dataSource = new MatTableDataSource(response.data);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        } else {
          alert('Not Get Data');
        }
      },
      complete: () => {},
      error: (error) => {},
    });
  };

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string) {
    const dialogRef = this.dialog.open(UserCreateComponent, {
      width: '1000px',
      enterAnimationDuration,
      exitAnimationDuration,
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
////////////////////////////
/** Builds and returns a new User. */
function createNewUser(id: number): IUser {
  return {
    id: id,
    name: '',
    family: '',
    email: '',
    username: '',
    password: '',
    phoneNumber: '',
    isActive: true,
    roleId: 0,
  };
}
