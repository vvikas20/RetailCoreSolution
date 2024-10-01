import { CommonModule } from '@angular/common';
import { Component, ElementRef, inject } from '@angular/core';
import { Router } from '@angular/router';
import { MenuManagementService } from '../../services/menu-mangement.service';
import { LayoutService } from '../../../../core/services/layout.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'retail-sidebar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
  providers: [MenuManagementService]
})
export class SidebarComponent {
  selectedMenu = '';
  toggleStateClass = "";
  lstLeftMenu: Array<any> = [];
  _viewSVG:any= '';

  constructor(private router: Router
    , private menuManagementService: MenuManagementService
    , private layoutService: LayoutService
  , private sanitizer: DomSanitizer) { }

  setActive(selectedItem: any) {
    this.lstLeftMenu.forEach(item => item.active = false);
    selectedItem.active = true;
    this.navigateToUrl(selectedItem.url);
  }
  
  navigateToUrl(url: string) {
    this.router.navigateByUrl(url);
  }

  ngOnInit() {
    // this.fillLeftMenu();
    this.layoutService.toggleObervable.subscribe((expand) => {
      this.toggleStateClass = expand ? "open" : "";
    });
  }
  fillLeftMenu() {
    this.menuManagementService.getLeftSideMenus().subscribe((menus) => {
      this.lstLeftMenu = menus
        .filter(menu => menu.isActive) // Filter by isActive
        .map((menu) => {
          return {
            name: menu.name,
            parent: menu.parentId,
            active: false,
            url: menu.routePath,
            child: menu.child,
            menuOrder: menu.menuOrder,
            menuIcon:this.sanitizer.bypassSecurityTrustHtml(menu.menuIcon)
          };
        })
        .sort((a, b) => a.menuOrder.localeCompare(b.menuOrder));
    });
  }
}
