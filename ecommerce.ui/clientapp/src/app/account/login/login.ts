import { Component } from '@angular/core';
import { BreadCrumbComponent } from '../../../components/bread-crumb-component/bread-crumb-component';

@Component({
  selector: 'app-login',
  imports: [BreadCrumbComponent],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {}
