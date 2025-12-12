import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
   private message: string = 'Hello from Service!';

  getMessage(): string {
    return this.message;
  }

  setMessage(newMessage: string) {
    this.message = newMessage;
  }
}
