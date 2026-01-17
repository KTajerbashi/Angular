import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-child-to-parent',
  imports: [],
  templateUrl: './child-to-parent.html',
  styleUrl: './child-to-parent.scss',
})
export class ChildToParent {

  @Input("Type") _type : string = '';
  @Output("Description") _description = new EventEmitter<string>();
}
