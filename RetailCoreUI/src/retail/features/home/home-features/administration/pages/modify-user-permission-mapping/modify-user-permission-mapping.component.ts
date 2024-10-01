import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
@Component({
  selector: 'retail-user-account',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './modify-user-permission-mapping.component.html',
  styleUrl: './modify-user-permission-mapping.component.scss'
})
export class ModifyUserPermissionMappingComponent {

}
