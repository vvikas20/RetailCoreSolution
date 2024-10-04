import { Component, ElementRef, HostListener, inject } from '@angular/core';
import { UI_Modules } from '../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../shared/modules/angular-modules.export';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { LayoutService } from '../../../../core/services/layout.service';
import { CommonModule } from '@angular/common';
import { LoggerService } from '../../../../core/services/logger.service';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../../core/auth/authentication.service';
import { DataPersistanceService } from '../../../../core/services/data-persistance.service';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'retail-header',
  standalone: true,
  imports: [UI_Modules, FormsModule, angularModules, CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  providers: [SidebarComponent],
})
export class HeaderComponent {
  items: MenuItem[] | undefined;

  visible: boolean = false;
  display:boolean = false;
  languageStateClass = '';
  profileStateClass = '';
  private languageState = false;
  private profileState = false;
  userName:string='';

  constructor(private router: Router, private auth: AuthenticationService
    , private layoutService: LayoutService
    , private dataPersistenceService: DataPersistanceService) { }

    ngOnInit() {
      // this.fillAnnouncementList("");
      // this.userName=this.dataPersistenceService.userName;
    }



  toggleDropdown() {
    this.languageState = !this.languageState;
    this.languageStateClass = this.languageState ? 'show' : '';
  }

  toggleUserprofile() {
    this.profileState = !this.profileState;
    this.profileStateClass = this.profileState ? 'show' : '';
  }

  toggleMenuCollapse() {
    this.layoutService.toggleSidebar();
  }

  position: any = 'top';
  showDialog(position: string) {
    this.position = position;
    this.visible = true;
  }
  displayTemplate() {
    this.display = true;
  }

  Logout() {
    this.auth.removeToken();
    this.router.navigateByUrl('/auth/login');
  }
}
