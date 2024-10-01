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
import { AnnouncementService } from '../../home-features/toolbox-mgt/services/announcement.service';
import { IAnnouncement } from '../../home-features/toolbox-mgt/models/announcements-view.models';
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
  providers: [AnnouncementService]
})
export class DashboardComponent {

  products: Product[] = [
    {
      id: '1000',
      code: 'f230fh0g3',
      name: 'Bamboo Watch',
      description: 'Sustainable bamboo watch with a sleek design.',
      image: 'bamboo-watch.jpg',
      price: 65,
      category: 'Accessories',
      quantity: 24,
      inventoryStatus: 'INSTOCK',
      rating: 5
  },
  {
      id: '1001',
      code: 'h44sdj2k1',
      name: 'Leather Backpack',
      description: 'Genuine leather backpack with multiple compartments.',
      image: 'leather-backpack.jpg',
      price: 120,
      category: 'Bags',
      quantity: 15,
      inventoryStatus: 'INSTOCK',
      rating: 4.5
  },
  {
      id: '1002',
      code: 'j82fk4r5m',
      name: 'Eco-Friendly Water Bottle',
      description: 'Reusable water bottle made from recycled materials.',
      image: 'water-bottle.jpg',
      price: 25,
      category: 'Accessories',
      quantity: 50,
      inventoryStatus: 'INSTOCK',
      rating: 4.8
  },
  {
      id: '1003',
      code: 'k56mg9l8p',
      name: 'Wireless Earbuds',
      description: 'Bluetooth earbuds with noise-cancellation feature.',
      image: 'wireless-earbuds.jpg',
      price: 85,
      category: 'Electronics',
      quantity: 30,
      inventoryStatus: 'INSTOCK',
      rating: 4.7
  },
  {
      id: '1004',
      code: 'm72gh6v9x',
      name: 'Canvas Tote Bag',
      description: 'Durable canvas tote bag with adjustable straps.',
      image: 'tote-bag.jpg',
      price: 40,
      category: 'Bags',
      quantity: 60,
      inventoryStatus: 'INSTOCK',
      rating: 4.3
  },
  {
      id: '1005',
      code: 'n98kj3q7l',
      name: 'Smart Fitness Tracker',
      description: 'Fitness tracker with heart rate monitoring and GPS.',
      image: 'fitness-tracker.jpg',
      price: 110,
      category: 'Electronics',
      quantity: 20,
      inventoryStatus: 'INSTOCK',
      rating: 4.6
  },
  {
      id: '1006',
      code: 'o23lb8r0p',
      name: 'Organic Cotton T-Shirt',
      description: 'Comfortable t-shirt made from 100% organic cotton.',
      image: 'cotton-tshirt.jpg',
      price: 35,
      category: 'Clothing',
      quantity: 40,
      inventoryStatus: 'INSTOCK',
      rating: 4.4
  },
  {
      id: '1007',
      code: 'p16vd9y3w',
      name: 'Stainless Steel Thermos',
      description: 'Thermos with double-wall insulation to keep beverages hot or cold.',
      image: 'stainless-thermos.jpg',
      price: 55,
      category: 'Accessories',
      quantity: 35,
      inventoryStatus: 'INSTOCK',
      rating: 4.7
  },
  {
      id: '1008',
      code: 'q72cg5k9v',
      name: 'Wooden Desk Organizer',
      description: 'Elegant wooden desk organizer with multiple compartments.',
      image: 'desk-organizer.jpg',
      price: 75,
      category: 'Office Supplies',
      quantity: 18,
      inventoryStatus: 'INSTOCK',
      rating: 4.6
  },
  {
      id: '1009',
      code: 'r14mh2t7j',
      name: 'Leather Wallet',
      description: 'Stylish leather wallet with RFID protection.',
      image: 'leather-wallet.jpg',
      price: 60,
      category: 'Accessories',
      quantity: 22,
      inventoryStatus: 'INSTOCK',
      rating: 4.8
  },
  {
      id: '1010',
      code: 's67tf4u1z',
      name: 'Bluetooth Speaker',
      description: 'Portable Bluetooth speaker with high-quality sound.',
      image: 'bluetooth-speaker.jpg',
      price: 95,
      category: 'Electronics',
      quantity: 28,
      inventoryStatus: 'INSTOCK',
      rating: 4.9
  }
];

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
