import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ApiService } from '../../../services/api.service';

interface IUserDTO {
  id: number;
  name: string;
  family: string;
  phone: string;
  email: string;
}
interface ApiResponse<T> {
  success: boolean;
  data: T;
  message: string;
  error: any;
  token?: string;
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

  constructor(private httpClient: HttpClient) {}
  http = inject(HttpClient);
  baseService = inject(ApiService);
  dataList: IUserDTO[] = [];

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
    this.baseService.get<ApiResponse<IUserDTO[]>>('User/Read').subscribe({
      next: (response) => {
        if (response.success) {
          console.log('Data successfully fetched:', response.data);
          this.dataList = response.data; // Extract the `data` array from the response
        } else {
          console.error('Error: ', response.message);
        }
      },
      error: (error) => {
        console.error('Error fetching users:', error);
      },
    });
  }
  loadHttp(): void {
    this.httpClient
      .get('https://localhost:7100/api/User/Read')
      .subscribe((res) => {
        console.log('Http : ', res);
      });
  }
  ngOnInit(): void {
    console.log('Run ...');
    this.loadAllUser();
    // this.loadHttp();
  }
}
