import { RouterOutlet } from '@angular/router';
import { Component } from '@angular/core';
import { Header } from "../../components/header/header";
import { Nav } from "../../components/nav/nav";
import { Footer } from "../../components/footer/footer";

@Component({
  selector: 'app-main-layout',
  imports: [RouterOutlet, Header, Nav, Footer],
  templateUrl: './main-layout.html',
  styleUrl: './main-layout.scss',
})
export class MainLayout {

}
