import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { HomeComponent } from './components/pages/home/home.component';
import { AboutComponent } from './components/pages/about/about.component';
import { CommonModule } from '@angular/common';
import { ReversPipe } from './pipes/revers.pipe';
@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    MatCardModule,
    MatButtonModule,
    HomeComponent,
    AboutComponent,
    CommonModule,
    ReversPipe,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  /// Pipes
  title: string = 'Angular Full Course';
  info: string = 'Angular Version 19';
  dateTime: Date = new Date();
  testWords: string[] = [
    'Kaihan',
    'Kairun',
    'sharif',
    'Javad',
    'mohammad',
    'Tajer',
  ];

  /// Property Binding
  isDisable = false;

  //  Event Binding
  eventBindingInput: string = '';
  changeKeyDown = (e: any) => {
    this.eventBindingInput = e.target.value;
  };

  //  Two Way Binding
  printValue: string = '';
  printChangeValue = (e: any) => {
    this.printValue = e.target.value;
  };
}
