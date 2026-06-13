import { Component } from '@angular/core';
import { SliderComponent } from '../slider-component/slider-component';

@Component({
  selector: 'app-main-component',
  imports: [SliderComponent],
  templateUrl: './main-component.html',
  styleUrl: './main-component.css',
})
export class MainComponent {}
