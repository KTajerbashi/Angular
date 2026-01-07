import { Component } from '@angular/core';
import { CopyTextDirective } from "../../directives/copy-text";
import { ChangebgColorDirective } from '../../directives/changebg-color';
import { MinimalTextDirective } from '../../directives/minimal-text';

@Component({
  selector: 'app-directive-intro',
  imports: [CopyTextDirective,ChangebgColorDirective,MinimalTextDirective],
  templateUrl: './directive-intro.html',
  styleUrl: './directive-intro.scss',
})
export class DirectiveIntro {

}
