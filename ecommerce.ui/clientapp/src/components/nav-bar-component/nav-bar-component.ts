import { Component } from '@angular/core';
import { NgClass } from "../../../node_modules/@angular/common/types/_common_module-chunk";

@Component({
  selector: 'app-nav-bar-component',
  imports: [NgClass],
  templateUrl: './nav-bar-component.html',
  styleUrl: './nav-bar-component.css',
})
export class NavBarComponent {
  collapse = true;
  toggleCollapsed()
  {
    this.collapse = !this.collapse;
  }
}
