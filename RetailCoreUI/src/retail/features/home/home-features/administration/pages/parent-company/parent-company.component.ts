import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
@Component({
  selector: 'retail-user-account',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './parent-company.component.html',
  styleUrl: './parent-company.component.scss'
})
export class ParentCompanyComponent {
  maped:boolean = false;
  edit:boolean = false;

  mappedproduct() {
    this.maped = true;
  }
  editParent() {
    this.edit = true;
  }
}
