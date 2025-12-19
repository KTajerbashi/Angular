import { Component } from '@angular/core';
import { ChildToParent } from "./children/child-to-parent/child-to-parent";
import { ParentToChild } from "./children/parent-to-child/parent-to-child";

@Component({
  selector: 'app-input-output',
  imports: [ChildToParent, ParentToChild],
  templateUrl: './input-output.html',
  styleUrl: './input-output.scss',
})
export class InputOutput {

}
