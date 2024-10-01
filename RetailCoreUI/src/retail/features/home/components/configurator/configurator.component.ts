import { AfterViewInit, Component, DebugElement, NgZone, OnInit, inject } from '@angular/core';
import { UI_Modules } from '../../../../shared/modules/ui-modules.export';
import { FormsModule } from '@angular/forms';
import { DropdownChangeEvent } from 'primeng/dropdown';
import { AlertService } from '../../../../core/ui-services/alert.service';
import { CommonModule } from '@angular/common';
import { AnyCatcher } from 'rxjs/internal/AnyCatcher';

declare var kbmax: any;

@Component({
  selector: 'retail-configurator',
  standalone: true,
  imports: [UI_Modules, FormsModule, CommonModule],
  templateUrl: './configurator.component.html',
  styleUrl: './configurator.component.scss'
})
export class ConfiguratorComponent implements OnInit, AfterViewInit {
  config: any;

  selectedAddedProduct: any;
  addedProducts: Array<any> = [
    { id: 37, name: 'MY FIRST CONFIGURED PRODUCT', configuredProduct: null }
  ];

  selectedProduct: any;
  productOptions = [
    { id: 12, isConfigurable: true, name: 'Horizon (CPQ)' },
    { id: 29, isConfigurable: true, name: 'Curbs' },
    { id: 33, isConfigurable: true, name: 'Quote Detail' },
    { id: 34, isConfigurable: true, name: 'Horizon - Quote Mock-Up' },
    { id: 35, isConfigurable: true, name: 'Nested Set - Quote Line' },
    { id: 36, isConfigurable: false, name: 'FIRST STANDARD PRRODUCT' },
    { id: 37, isConfigurable: true, name: 'MY FIRST CONFIGURED PRODUCT' },
    { id: 38, isConfigurable: true, name: 'Curb - Quote Mock-Up' },
    { id: 42, isConfigurable: true, name: 'Curbs - Backup' },
    { id: 43, isConfigurable: true, name: 'Curbs - Copy' }

  ];


  constructor(private ngZone: NgZone, private alertService: AlertService) { }

  ngAfterViewInit(): void {

  }

  ngOnInit(): void {

  }

  productChange($event: DropdownChangeEvent) {
    if (this.selectedProduct.isConfigurable)
      this.loadConfigurator(this.selectedProduct.id, null);
    else
      this.alertService.info('Information', 'Selected product is not configurable');
  }

  private loadConfigurator(configuratorId: number, configuredProduct: any) {
    this.ngZone.runOutsideAngular(() => {
      this.tryDisposeEmbed();
      this.config = new kbmax.ConfiguratorEmbed({
        kbmaxUrl: "https://kccmfg-dev.kbmax.com",
        elementId: "viewer",
        configuratorId: configuratorId,
        configuredProduct: configuredProduct,
        showFields: true,
        showHeader: false,
        showConfigHeader: true,
        showDrawer: false,
        showMove: false,
        bindToFormSelector: "",
        loadStyle: "none",
      });
    });
  }

  addProductToQueue() {
    this.config.getConfiguredProduct((cp: any) => {
      debugger;
      this.addedProducts.push({ id: cp.idProduct, name: cp.name, configuredProduct: cp });
      this.tryDisposeEmbed();
      this.alertService.success('Success', 'Product Added to cart');
    });
  }

  displayProduct() {
    alert(this.selectedAddedProduct.id);
    this.loadConfigurator(this.selectedAddedProduct.id, this.selectedAddedProduct.configuredProduct);
  }

  private tryDisposeEmbed() {
    if (this.config) {
      this.config.dispose();
      this.config = null;
    }
  }
}
