import { AfterViewInit, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-service-example',
  imports: [],
  templateUrl: './service-example.component.html',
  styleUrls: ['./service-example.component.css'],
})
export class ServiceExampleComponent implements OnInit, AfterViewInit {
  ngAfterViewInit(): void {}
  ngOnInit(): void {}
}
