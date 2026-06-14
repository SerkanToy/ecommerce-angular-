import { Component, forwardRef, Inject, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirm-box-component',
  imports: [],
  templateUrl: './confirm-box-component.html',
  styleUrl: './confirm-box-component.css',
})
export class ConfirmBoxComponent {
  @Input() message: string = '';
  result?: boolean;

  constructor(@Inject(forwardRef(() => NgbActiveModal)) private activeModal: NgbActiveModal) { }

  yes() {
    this.activeModal.close(true);
  }

  no() {
    this.activeModal.close(false);
  }
}
