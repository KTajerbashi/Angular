import { CommonModule, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SignalRService } from '../../../bases/services/signalr.service';
import {
  MatFormField,
  MatInput,
  MatInputModule,
  MatLabel,
} from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { AboutComponent } from '../../main/about/about.component';

@Component({
  selector: 'app-chat-room',
  imports: [
    CommonModule,
    FormsModule,
    MatInput,
    NgFor,
    MatFormField,
    MatLabel,
    MatButton,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatGridListModule,
  ],
  templateUrl: './chat-room.component.html',
  styleUrl: './chat-room.component.css',
})
export class ChatRoomComponent {
  userChats: IUserProfile[] = [];
  user = '';
  constructor(public signalRService: SignalRService) {}

  sendMessage(user: IUserProfile): void {
    if (user.message) {
      this.signalRService.sendMessage(user.name, user.message);
      user.message = '';
    }
    console.log('Send signalRService : ', this.signalRService);
  }

  addUserToChat = () => {
    let guid = Math.round(Math.random() * 10000);
    let bgColor = this.getRandomBackgroundColor();
    let textColot = this.getInvertedColor(bgColor);
    if (!this.userChats.some((item) => item.name === this.user)) {
      this.userChats.push({
        name: this.user,
        bgColor: `${bgColor}`,
        textColor: `${textColot}`,
        message: '',
        guid: `${guid}`,
      });
      this.user = '';
    }
  };
  getUser = (name: string) => {
    return this.userChats.find((item) => item.name === name);
  };

  leaveChat(user: IUserProfile): void {
    // Find the index of the user in the array
    console.log('signalRService :', this.signalRService);
    const index = this.userChats.findIndex((u) => u.guid === user.guid);

    // Remove the user from the chat list if found
    if (index !== -1) {
      this.userChats.splice(index, 1);
      console.log(`User ${user.name} (ID: ${user.guid}) has left the chat.`);
    }
  }
  getRandomBackgroundColor() {
    const r = Math.floor(Math.random() * 256); // Red: 0–255
    const g = Math.floor(Math.random() * 256); // Green: 0–255
    const b = Math.floor(Math.random() * 256); // Blue: 0–255
    return `rgb(${r}, ${g}, ${b})`;
  }
  getInvertedColor(rgb: string): string {
    // Extract RGB values from 'rgb(x, y, z)'
    const [r, g, b] = rgb.match(/\d+/g)!.map((val) => parseInt(val, 10));

    // Invert colors
    const invertedR = 255 - r;
    const invertedG = 255 - g;
    const invertedB = 255 - b;

    return `rgb(${invertedR}, ${invertedG}, ${invertedB})`;
  }
}
interface IUserProfile {
  name: string;
  guid: string;
  bgColor: string;
  textColor: string;
  message: string;
}
