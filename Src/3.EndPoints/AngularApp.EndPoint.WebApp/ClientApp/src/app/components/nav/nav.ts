import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import INavDTO from '../../models/INav.dto';

@Component({
  selector: 'app-nav',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.scss',
})
export class Nav implements OnInit {
  menus: INavDTO[] = [];

  ngOnInit(): void {
    this.menus = this.loadMenus();
  }

  private loadMenus(): INavDTO[] {
    return [
      { Name: 'Dashboard', Link: '/dashboard', IsDeleted: false },
      { Name: 'Components', Link: '/components', IsDeleted: false },
      { Name: 'Pipes', Link: '/pipes', IsDeleted: false },
      { Name: 'Data Binding', Link: '/data-binding', IsDeleted: false },
      { Name: 'Modules', Link: '/modules', IsDeleted: false },
      { Name: 'Router', Link: '/router/10', IsDeleted: false },
      { Name: 'Guards', Link: '/guards', IsDeleted: false },
      { Name: 'Directives', Link: '/directives', IsDeleted: false },
      { Name: 'Forms', Link: '/forms', IsDeleted: false },
      { Name: 'Services', Link: '/service', IsDeleted: false },
      { Name: 'Hooks', Link: '/hooks', IsDeleted: false },
      { Name: 'Signal', Link: '/signal', IsDeleted: false },
      { Name: 'Products', Link: '/products', IsDeleted: false },

      { Name: 'Templates', Link: '/templates', IsDeleted: false },
      { Name: 'Input / Output', Link: '/input-output', IsDeleted: false },
      { Name: 'Template Syntax', Link: '/template-syntax', IsDeleted: false },
      { Name: 'Routing', Link: '/routing', IsDeleted: false },
      { Name: 'HTTP', Link: '/http-client', IsDeleted: false },
      { Name: 'RXJS', Link: '/rxjs', IsDeleted: false },
      { Name: 'Observables', Link: '/observables', IsDeleted: false },
      { Name: 'Users', Link: '/users', IsDeleted: false },
      { Name: 'Settings', Link: '/settings', IsDeleted: false },
    ];
  }
}
