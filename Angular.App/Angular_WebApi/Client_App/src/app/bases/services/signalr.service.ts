import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;

  public messages: { user: string; message: string }[] = [];

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7100/chatHub') // Replace with your backend URL
      .build();
    console.log('hubConnection', this.hubConnection);
    this.startConnection();
    this.registerOnServerEvents();
  }

  private startConnection(): void {
    this.hubConnection
      .start()
      .then(() => console.log('SignalR connection started'))
      .catch((err) =>
        console.error('Error while starting SignalR connection:', err)
      );
  }

  private registerOnServerEvents(): void {
    this.hubConnection.on('ReceiveMessage', (user: string, message: string) => {
      this.messages.push({ user, message });
    });
  }

  public sendMessage(user: string, message: string): void {
    this.hubConnection
      .invoke('SendMessage', user, message)
      .catch((err) => console.error('Error while sending message:', err));
  }
}
