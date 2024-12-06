import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import {
  ActivatedRoute,
  NavigationEnd,
  Router,
  RouterLink,
  RouterOutlet,
} from '@angular/router';

@Component({
  selector: 'app-parameter-controller',
  imports: [MatButton, RouterLink, RouterOutlet, FormsModule],
  templateUrl: './parameter-controller.component.html',
  styleUrl: './parameter-controller.component.css',
})
export class ParameterControllerComponent implements OnInit {
  idPrams!: any;
  parameter!: string;
  currentUrl: string = '';
  constructor(private route: ActivatedRoute, private router: Router) {}
  ngOnInit(): void {
    // this.idPrams = this.route.snapshot.paramMap.get('id');
    // console.log(this.idPrams);
    this.route.paramMap.subscribe((params) => {
      this.idPrams = params.get('id'); // Get 'id' from route parameters
      this.currentUrl = `http://localhost:4200/parameter-controller/${this.idPrams}`;
      console.log(this.idPrams); // Log the updated parameter
    });
  }
  onGoRoute = () => {
    if (this.parameter) {
      this.router.navigate([`/parameter-controller`, this.parameter]);
    } else {
      alert('Please enter a parameter value!'); // Optional validation
    }
  };
}
