import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-validation-message-component',
  imports: [],
  templateUrl: './validation-message-component.html',
  styleUrl: './validation-message-component.css',
})
export class ValidationMessageComponent {
  @Input() errorMessages: string[] | undefined;
}
