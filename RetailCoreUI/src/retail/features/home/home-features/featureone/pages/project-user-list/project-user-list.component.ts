import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';

@Component({
  selector: 'retail-project-user-list',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './project-user-list.component.html',
  styleUrl: './project-user-list.component.scss'
})
export class ProjectUserListComponent {
  visible: boolean = false;
  ngOnInit() {

  }

  showDialog() {
    this.visible = true;
  }
}
