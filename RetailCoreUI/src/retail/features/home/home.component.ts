import { Component, ElementRef, inject } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Layout_Components } from './layout/layout-export';
import { Shared_Components } from '../../shared/components/shared.components.export';
import { UI_Modules } from '../../shared/modules/ui-modules.export';
import { LayoutService } from '../../core/services/layout.service';
import { DataPersistanceService } from '../../core/services/data-persistance.service';
import { IPermission } from '../../core/models/app-permission';
import { HomeResolverService } from './resolvers/home-resolver.service';

@Component({
  selector: 'retail-home',
  standalone: true,
  imports: [RouterModule, CommonModule, Layout_Components],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  providers: [HomeResolverService]
})
export class HomeComponent {
  toggleStateClass = "";

  constructor(private router: Router, private activatedRoute: ActivatedRoute
    , private dataPersistance: DataPersistanceService
    , private layoutService: LayoutService) { }

  ngOnInit() {
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
}
