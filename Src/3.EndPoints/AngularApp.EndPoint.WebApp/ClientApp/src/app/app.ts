import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Nav } from "./components/nav/nav";
import { Header } from "./components/header/header";
import { Footer } from "./components/footer/footer";
import { CodeSample } from "./pages/code-sample/code-sample";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Nav, Header, Footer, CodeSample],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('ClientApp');
}
