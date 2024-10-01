import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
@Component({
  selector: 'retail-user-account',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './default-user-permission.component.html',
  styleUrl: './default-user-permission.component.scss'
})
export class DefaultUserPermissionComponent {

}
