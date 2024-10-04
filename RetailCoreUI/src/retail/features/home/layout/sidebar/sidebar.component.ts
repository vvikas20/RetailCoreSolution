import { CommonModule } from '@angular/common';
import { Component, ElementRef, inject } from '@angular/core';
import { Router } from '@angular/router';
import { MenuManagementService } from '../../services/menu-mangement.service';
import { LayoutService } from '../../../../core/services/layout.service';
import { DomSanitizer } from '@angular/platform-browser';
import { UI_Modules } from '../../../../shared/modules/ui-modules.export';
import { Utility } from '../../../../core/utility/utility';

@Component({
  selector: 'retail-sidebar',
  standalone: true,
  imports: [CommonModule, UI_Modules],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
  providers: [MenuManagementService]
})
export class SidebarComponent {
  selectedMenu = '';
  toggleState: boolean = false;
  menuItems: Array<any> = [];
  _viewSVG:any= '';

  constructor(private router: Router
    , private menuManagementService: MenuManagementService
    , public layoutService: LayoutService
  , private sanitizer: DomSanitizer) { }

  setActive(selectedItem: any) {
    this.menuItems.forEach(item => item.active = false);
    selectedItem.active = true;
    this.navigateToUrl(selectedItem.url);
  }
  
  navigateToUrl(url: string) {
    this.router.navigateByUrl(url);
  }

  ngOnInit() {
    this.menuItems = this.menuManagementService.appMenuItems;
    // this.fillLeftMenu();
    this.layoutService.toggleObervable.subscribe((expand) => {
      this.toggleState = expand;
    });
  }

  fillLeftMenu() {
    this.menuManagementService.getMenuItems().subscribe((menus) => {
      this.menuItems = menus;
    }, (err) => {
      // this.lstLeftMenu = Utility.innerJoin(this.menuManagementService.lstAppMenu, this.menuManagementService.lstAppMenu, 'validationKey', 'validationKey');
      this.menuItems = []
    });
  }
}
