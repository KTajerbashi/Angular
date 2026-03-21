import { Component, OnInit, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-aside',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './aside.component.html',
  styleUrl: './aside.component.scss',
})
export class AsideComponent implements OnInit {
  ngOnInit(): void {
    this.loadNavs();
  }
  menusData = signal<INavMenu[]>([]);

  loadNavs() {
    const result: INavMenu[] = [
      { name: 'Dashboard', path: 'dashboard', title: 'Dashboard' },
      { name: 'Chart Tree', path: 'chart-tree', title: 'ChartTree' },
      { name: 'Table Tree', path: 'table-tree', title: 'TableTree' },
      { name: 'Cartable', path: 'cartable', title: 'Cartable' },
      { name: 'About', path: 'about', title: 'About' },
      { name: 'History', path: 'history', title: 'History' },
      { name: 'User', path: 'user', title: 'User' },
      { name: 'Role', path: 'role', title: 'Role' },
      { name: 'Group', path: 'group', title: 'Group' },
      { name: 'Privilege', path: 'privilege', title: 'Privilege' },
      { name: 'Menu', path: 'menu', title: 'Menu' },
    ];
    this.menusData.set(result);
  }
}
interface INavMenu {
  title: string;
  path: string;
  name: string;
}
