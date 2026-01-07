import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLinkWithHref, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-guards-intro',
  imports: [RouterOutlet, RouterLinkWithHref, FormsModule],
  templateUrl: './guards-intro.html',
  styleUrl: './guards-intro.scss',
})
export class GuardsIntro {
  userinput: string = '';

  canNavigate() {
    if (this.userinput !== '') {
      if(confirm('Your Data will be lost. Are you sure to navigate?')){
        return true;
      }
      else{
        return false;
      }
    }else{
      return true;
    }
  }
}
