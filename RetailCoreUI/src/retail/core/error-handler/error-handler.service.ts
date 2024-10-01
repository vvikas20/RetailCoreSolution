import { ErrorHandler, Injectable, inject } from '@angular/core';
import { LoggerService } from '../services/logger.service';

@Injectable()
export class ErrorHandlerService implements ErrorHandler {

  constructor(private logger: LoggerService) { }

  handleError(error: any): void {
    this.logger.error(`An error occurred with the following message:\n ${error.message}`);
    console.error(error);
  }

}
