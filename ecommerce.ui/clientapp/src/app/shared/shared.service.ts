import { forwardRef, Inject, Injectable } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ApiResponse } from './models/apiResponse_m';
import { NotificationComponent } from '../../components/notification-component/notification-component';
import { Observable } from 'rxjs';
import { ConfirmBoxComponent } from './components/confirm-box-component/confirm-box-component';

@Injectable({
  providedIn: 'root'
})

export class SharedService {
  constructor(private toastr: ToastrService,
    @Inject(forwardRef(() => NgbModal)) private modalService: NgbModal
  ) {}

  showNotification(apiResponse: ApiResponse<any>, backdrop: boolean = false) {
    let isSuccess = false;

    if (apiResponse.statusCode == 200 || apiResponse.statusCode == 201) {
      isSuccess = true;
    }

    if (apiResponse.showWithToastr) {
      if (isSuccess) {
        this.toastr.success(apiResponse.message, apiResponse.title);
      } else {
        this.toastr.error(apiResponse.message, apiResponse.title);
      }
    } else {
      const options: NgbModalOptions = {
        backdrop
      };

      const modalRef = this.modalService.open(NotificationComponent, options);
      modalRef.componentInstance.isSuccess = isSuccess;
      modalRef.componentInstance.title = apiResponse.title;
      modalRef.componentInstance.message = apiResponse.message;
      modalRef.componentInstance.isHtmlEnabled = apiResponse.isHtmlEnabled;
    }
  }

  confirmBox(message: string, backdrop: boolean = false): Observable<boolean> {
    const options: NgbModalOptions = {
      backdrop
    };

    const modalRef = this.modalService.open(ConfirmBoxComponent, options);
    modalRef.componentInstance.message = message;

    return new Observable<boolean>((observable) => {
      modalRef.result
        .then((result) => {
          observable.next(result);
          observable.complete();
        }).catch(() => {
          observable.next(false);
          observable.complete();
        })
    })
  }
  
}