import { Component, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { Fruits } from './children/fruits/fruits';
import { Devices } from './children/devices/devices';

@Component({
  selector: 'app-view-intro',
  imports: [Fruits, Devices],
  templateUrl: './view-intro.html',
  styleUrl: './view-intro.scss',
})
export class ViewIntro {
  @ViewChild(Fruits) _child!: Fruits;

  @ViewChildren(Devices) _children!: QueryList<Devices>;

  onAddFruit(name: string) {
    let result = this._child.add(name);
    alert(result);
  }

  onAddDevice(name: string) {
    console.log('onAddDevice : ', name);
    console.log('onAddDevice : ', this._children);
    this._children.forEach((comp) => {
      comp.add('Item By System');
    });
  }
}
