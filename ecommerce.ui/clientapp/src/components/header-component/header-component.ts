import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NavBarComponent } from '../nav-bar-component/nav-bar-component';

@Component({
  selector: 'app-header-component',
  imports: [RouterLink,RouterLinkActive,CommonModule,NavBarComponent],
  templateUrl: './header-component.html',
  styleUrl: './header-component.css',
})
export class HeaderComponent {}
