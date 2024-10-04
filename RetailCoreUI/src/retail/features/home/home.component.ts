import { MenuManagementService } from './services/menu-mangement.service';
import { Component, ElementRef, inject } from '@angular/core';
import { ActivatedRoute, NavigationEnd, RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Layout_Components } from './layout/layout-export';
import { Shared_Components } from '../../shared/components/shared.components.export';
import { UI_Modules } from '../../shared/modules/ui-modules.export';
import { LayoutService } from '../../core/services/layout.service';
import { DataPersistanceService } from '../../core/services/data-persistance.service';
import { IPermission } from '../../core/models/app-permission';
import { HomeResolverService } from './resolvers/home-resolver.service';
import { MenuItem } from 'primeng/api';
import { filter } from 'rxjs';

@Component({
  selector: 'retail-home',
  standalone: true,
  imports: [RouterModule, CommonModule, Layout_Components, UI_Modules],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  providers: [HomeResolverService]
})
export class HomeComponent {
  toggleStateClass = "";

  breadcrumbItems: MenuItem[] | undefined;

  home: MenuItem | undefined;

  constructor(private router: Router, private activatedRoute: ActivatedRoute
    , private dataPersistance: DataPersistanceService
    , private layoutService: LayoutService) { }
    
  ngOnInit() {
    this.activatedRoute.data.subscribe(()=>{
      this.breadcrumbItems = this.createBreadcrumbs();
    })
    // this.activatedRoute.data.subscribe((response: any) => {
    //   //debugger;
    //   // console.log('PRODUCT FETCHING', response);
    //   this.dataPersistance.userPermission = response.Permissions.id;
    //   // console.log('PRODUCT FETCHED');

    //   var str = '';
    //   if (this.dataPersistance.hasPermission(response.Permissions.id)) { str = 'permission' } else { str = 'not permission' }
    //   // console.log(str);
    // });

    this.layoutService.toggleObervable.subscribe((expand) => {
      this.toggleStateClass = expand ? "sidebar_open" : "";
    });
  }

  private createBreadcrumbs(): MenuItem[] {
    const breadcrumbs: MenuItem[] = [];
    let currentUrl = '';
    const urlSegments = this.router.url.split('/').filter(segment => segment);

    // Loop through each segment and build breadcrumb items
    urlSegments.forEach((segment, index) => {
      currentUrl += `/${segment}`;
      if(index==0){
        breadcrumbs.push({
          icon: 'pi pi-home',
          route: currentUrl
        });
      }else{
        breadcrumbs.push({
          label: this.formatLabel(segment), // Optional: Format the label as needed
          route: currentUrl
        });
      }
    });
    debugger
    return breadcrumbs;
  }

  private formatLabel(segment: string): string {
    segment = segment.replace('-', ' ');
    return segment.charAt(0).toUpperCase() + segment.slice(1);
  }
}
