import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

interface IUserDTO {
  id: number;
  name: string;
  family: string;
  phone: string;
  email: string;
}

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  userName: string = '';

  http = inject(HttpClient);
  dataList: IUserDTO[] = [];

  ngOnInit(): void {
    console.log('Run ...');
    this.loadAllUser();
  }

  // Action Methods
  remove(model: IUserDTO): void {
    console.log('Remove => Model :', model);
  }

  edit(model: IUserDTO): void {
    console.log('Edit => Model :', model);
  }

  read(model: IUserDTO): void {
    console.log('Read => Model :', model);
  }
  // Fetch Users from API
  loadAllUser(): void {
    this.http
      .get<IUserDTO[]>('https://localhost:7100/api/User/Read')
      .subscribe({
        next: (res: IUserDTO[]) => {
          this.dataList = res;
          console.log('Response: ', res);
        },
        error: (error: HttpErrorResponse) => {
          console.error('Error loading users:', error.message, error);
          if (error.status === 0) {
            console.error(
              'The server might not be reachable or CORS is not configured properly.'
            );
          }
        },
      });
  }
}
