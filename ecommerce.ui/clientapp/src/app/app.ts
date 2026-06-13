import { Component, Input, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import * as $ from 'jquery';
import { HeaderComponent } from '../components/header-component/header-component';
import { MainComponent } from '../components/main-component/main-component';
import { FooterComponent } from '../components/footer-component/footer-component';
import { GotoTopComponent } from '../components/goto-top-component/goto-top-component';
import { AsideComponent } from '../components/aside-component/aside-component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,
            HeaderComponent,            
            FooterComponent,
            GotoTopComponent,
            AsideComponent],
  templateUrl: './app.html',
  styleUrl: './app.css',
})



export class App {
  protected readonly title = signal('clientapp');
}
