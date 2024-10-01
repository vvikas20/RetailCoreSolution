import { bootstrapApplication } from '@angular/platform-browser';
import { retailConfig } from './retail/retail.config';
import { RetailComponent } from './retail/retail.component';

bootstrapApplication(RetailComponent, retailConfig)
  .catch((err) => console.error(err));
