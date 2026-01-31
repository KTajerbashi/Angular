import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "../../shared/components/header/header.component";
import { AsideComponent } from "../../shared/components/aside/aside.component";

@Component({
  selector: 'app-main-layout',
  imports: [RouterOutlet, CommonModule, HeaderComponent, AsideComponent],
  templateUrl: './main-layout.html',
  styleUrl: './main-layout.scss',
})
export class MainLayout {}
