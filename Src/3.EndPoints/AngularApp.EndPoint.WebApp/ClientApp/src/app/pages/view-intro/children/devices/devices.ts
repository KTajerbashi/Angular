import { Component } from '@angular/core';

@Component({
  selector: 'app-devices',
  imports: [],
  templateUrl: './devices.html',
  styleUrl: './devices.scss',
})
export class Devices {
  devices: string[] = ['IPhone', 'Glaxy'];
  updateFruits(data: string[]) {
    this.devices = [...this.devices, ...data];
  }
  add(device: string): string {
    this.devices.push(device);
    return 'Data Added ...';
  }
  remove(device: string) {
    this.devices = this.devices.filter((i) => i != device);
  }
}
