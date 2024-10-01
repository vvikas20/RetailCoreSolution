import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable()
export class SpinnerService {

  constructor(private ngxSpinnerServices: NgxSpinnerService) { }

  public show() {
    this.ngxSpinnerServices.show();
  }

  public hide() {
    this.ngxSpinnerServices.hide();
  }
}
