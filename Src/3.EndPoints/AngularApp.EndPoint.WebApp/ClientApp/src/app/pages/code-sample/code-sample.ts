import { CommonModule } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MessageService } from '../../services/message.service';
import { DataService } from '../../services/data.service';
@Component({
  selector: 'app-code-sample',
  imports: [FormsModule, CommonModule],
  templateUrl: './code-sample.html',
  styleUrl: './code-sample.scss',
})
export class CodeSample implements OnInit {
  constructor(private messageService: MessageService, private dataService: DataService) {}
  posts: any[] = [];
  ngOnInit(): void {
    this.dataService.getPosts().subscribe({
      next: (data) => {
        //  Take 10 row
        this.posts = data.slice(0, 10);
        console.log("Data : ",data);
      },
      error: (err) => console.error(err),
    });
  }
}
