import { Component } from '@angular/core';
import { MainComponent } from '../../components/main-component/main-component';

@Component({
  selector: 'app-home',
  imports: [MainComponent],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {}
