import { Injectable } from '@angular/core';
import { Confirmation, ConfirmationService } from 'primeng/api';

@Injectable()
export class ConfirmDialogService {

  constructor(private confirmationService: ConfirmationService) 
  { }

  confirm(confirmation: Confirmation){
    this.confirmationService.confirm(confirmation);
  }
}
