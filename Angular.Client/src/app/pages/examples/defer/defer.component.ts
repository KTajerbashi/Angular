import { Component } from '@angular/core';

@Component({
  selector: 'app-defer',
  imports: [],
  templateUrl: './defer.component.html',
  styleUrl: './defer.component.css',
})
export class DeferComponent {
  config = {
    defer: false,
    loading: false,
  };
}
