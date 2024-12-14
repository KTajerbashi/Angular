import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-service-example',
  imports: [],
  templateUrl: './service-example.component.html',
  styleUrls: ['./service-example.component.css'],
})
export class ServiceExampleComponent implements OnInit, AfterViewInit {
  ngAfterViewInit(): void {}
  ngOnInit(): void {}
constructor(private toastr:ToastrService){

}
  showAlert(){
    this.toastr.success('Completed','Success');
    this.toastr.error('Error','Exception');
  }
}
