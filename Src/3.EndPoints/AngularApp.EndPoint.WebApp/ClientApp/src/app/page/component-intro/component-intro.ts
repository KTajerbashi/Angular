import { Component } from '@angular/core';

@Component({
  selector: 'app-component-intro',
  imports: [],
  templateUrl: './component-intro.html',
  styleUrl: './component-intro.scss',
})
export class ComponentIntro {
activities: string[] = [
    'User John created a record',
    'Order #1203 completed',
    'Settings updated',
  ];

  onCreate() {
    console.log('Create clicked');
  }

  onView() {
    console.log('View clicked');
  }

  onExport() {
    console.log('Export clicked');
  }
}
