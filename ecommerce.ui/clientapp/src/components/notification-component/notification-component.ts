import { CommonModule } from '@angular/common';
import { Component, forwardRef, Inject, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-notification-component',
  imports: [CommonModule],
  templateUrl: './notification-component.html',
  styleUrl: './notification-component.css',
})
export class NotificationComponent {
  
  @Input() isSuccess: boolean = true;
  @Input() title: string = '';
  @Input() message: string = '';
  @Input() isHtmlEnabled: boolean = false;
  constructor(@Inject(forwardRef(() => NgbActiveModal)) public activeModal: NgbActiveModal) {}

  yes() {
    this.activeModal.close(true);
  }

  no() {
    this.activeModal.close(false);
  }
}
