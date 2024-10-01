import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api'
import { AlertType } from '../enums/alerts.enum';

@Injectable()
export class AlertService {

  constructor(private messageService: MessageService) { }

  success(summary: string, message: string) {
    this.alert(AlertType.Success, summary, message);
  }

  error(summary: string, message: string) {
    this.alert(AlertType.Error, summary, message);
  }

  info(summary: string, message: string) {
    this.alert(AlertType.Info, summary, message);
  }

  warn(summary: string, message: string) {
    this.alert(AlertType.Warning, summary, message);
  }

  private alert(type: AlertType, summary: string, message: string) {
    let regex = /(<([^>]+)>)/ig;
    message = message.replace(regex, '');
    this.messageService.add({ severity: this.getAlertTypeKey(type), summary: summary, detail: message });
  }

  private getAlertTypeKey(alertType: AlertType) {
    // return key based on alert type
    switch (alertType) {
      case AlertType.Success:
        return 'success';
      case AlertType.Error:
        return 'error';
      case AlertType.Info:
        return 'info';
      case AlertType.Warning:
        return 'warn';
      default:
        return 'Custom';
    }
  }
}
