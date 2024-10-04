import { Component, inject } from '@angular/core';
import { UI_Modules } from '../../../../shared/modules/ui-modules.export';
import { SpinnerService } from '../../../../core/ui-services/spinner.service';
import { Store } from '@ngrx/store';
import { AppState } from '../../../../core/states/app.state';
import { filter, Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { LoggerService } from '../../../../core/services/logger.service';
import { RouterModule } from '@angular/router';
import { DataPersistanceService } from '../../../../core/services/data-persistance.service';
import { CommonModule } from '@angular/common';
import { ConfirmDialogService } from '../../../../core/ui-services/confirm-dialog.service';


interface Range {
  name: string;
  code: string;
}

interface Column {
  field: string;
  header: string;
}

interface Product {
    id: string;
    code: string;
    name: string;
    description: string;
    image: string;
    price: number;
    category: string;
    quantity: number;
    inventoryStatus: string;
    rating: number;
}

@Component({
  selector: 'retail-dashboard',
  standalone: true,
  imports: [UI_Modules, FormsModule, RouterModule, CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  providers: []
})
export class DashboardComponent {

  products: Product[] = [];

  cols: Column[] = [
    { field: 'code', header: 'Code' },
    { field: 'name', header: 'Name' },
    { field: 'category', header: 'Category' },
    { field: 'quantity', header: 'Quantity' },
    { field: 'inventoryStatus', header: 'Status' },
    { field: 'rating', header: 'Rating' }
  ];

  knobValue = 10;

  rangeList: Range[] | undefined = [
    {
      name: 'Last Week',
      code: '0'
    },
    {
      name: 'This Week',
      code: '1'
    }
  ];

  selectedRange: Range | undefined = {
          name: 'Last Week',
          code: '0'
  };

  constructor() { }


  ngOnInit() {

  }

  getSeverity(status: string) {
    switch (status) {
        case 'INSTOCK':
            return 'success';
        case 'LOWSTOCK':
            return 'warning';
        case 'OUTOFSTOCK':
            return 'danger';
        default:
            return 'danger'
    }
}

}
