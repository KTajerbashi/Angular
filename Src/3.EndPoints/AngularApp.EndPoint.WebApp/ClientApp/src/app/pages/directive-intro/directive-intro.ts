import { Component } from '@angular/core';
import { CopyTextDirective } from '../../directives/copy-text';
import { ChangebgColorDirective } from '../../directives/changebg-color';
import { MinimalTextDirective } from '../../directives/minimal-text';
import { HasPermissionDirective } from '../../directives/hasPermission';
import { CommonModule } from '@angular/common';
import { HighlightDirective } from '../../directives/highlight';
import { F } from '@angular/cdk/keycodes';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-directive-intro',
  imports: [
    CopyTextDirective,
    ChangebgColorDirective,
    MinimalTextDirective,
    HasPermissionDirective,
    HighlightDirective,
    CommonModule,
    FormsModule
],
  templateUrl: './directive-intro.html',
  styleUrl: './directive-intro.scss',
})
export class DirectiveIntro {
  isAdmin = true;

  card1: boolean = false;
  card2: boolean = false;
  card3: boolean = false;
  card4: boolean = false;
  card5: boolean = true;

  colorValue: string = '';


  toggleIsAdmin() {
    this.isAdmin = !this.isAdmin;
  }
}
