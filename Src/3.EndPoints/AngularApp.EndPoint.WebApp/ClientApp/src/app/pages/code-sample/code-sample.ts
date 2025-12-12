import { CommonModule } from '@angular/common';
import { Component, computed, effect, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DataService } from '../../services/data.service';
import IPost from '../../interfaces/IPost.dto';

@Component({
  selector: 'app-code-sample',
  imports: [FormsModule, CommonModule],
  templateUrl: './code-sample.html',
  styleUrl: './code-sample.scss',
})
export class CodeSample {
  // --------------------
  // Signals
  // --------------------
  datasource = signal<IPost[]>([]);
  dataCount = computed(() => this.datasource().length);
  dataLogs = signal<string[]>([]);
  deleteCount = signal(0);

  // --------------------
  // Normal Variable
  // --------------------
  countVariable = 0;

  // --------------------
  // Signal
  // --------------------
  countSignal = signal(0);

  constructor(private dataService: DataService) {
    // Load data
    this.dataService.getPosts().subscribe({
      next: (data) => this.datasource.set(data),
      error: (err) => console.error(err),
    });

    // Reactivity example
    effect(() => {
      console.log('Data Count:', this.dataCount());
      const timestamp = new Date().toLocaleTimeString();
      this.dataLogs.update((logs) => [...logs, `Log at ${timestamp}`]);
    });
  }

  // --------------------
  // Remove item + update delete count
  // --------------------

  removeItem(post: IPost) {
    // // Update normal variable datasource
    // this.datasource.set(this.datasource().filter((i) => i.id !== post.id));
    // Update signal datasource
    this.datasource.update((items) => items.filter((i) => i.id !== post.id));

    // // Update signal delete count
    this.deleteCount.update((d) => d + 1);

    // // Update normal variable
    this.countVariable++;
  }

  // --------------------
  // Update signal manually
  // --------------------
  addSignalCount() {
    this.countSignal.update((c) => c + 1);
  }
}
