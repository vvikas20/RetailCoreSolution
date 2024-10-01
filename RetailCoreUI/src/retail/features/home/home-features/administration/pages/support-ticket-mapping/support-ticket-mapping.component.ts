import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
import { SupportTicketMappingService } from '../../services/support-ticket-mapping.service';
import { IssueType } from '../../../featureone/models/issue-type.models';
import { IIssueType, IIssueTypeUser, issueMappedWithUser } from '../../../../models/IssueType.model';
import { DropdownChangeEvent } from 'primeng/dropdown';
import { DataPersistanceService } from '../../../../../../core/services/data-persistance.service';
import { AlertService } from '../../../../../../core/ui-services/alert.service';
@Component({
  selector: 'retail-support-ticket-mapping',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './support-ticket-mapping.component.html',
  styleUrl: './support-ticket-mapping.component.scss',
  providers: [SupportTicketMappingService]
})
export class SupportTicketMappingComponent {
  parent_visible: boolean = false;
  IsEdit: boolean = false;
  IssueTypes: Array<IIssueType> = [];
  selectedIssueType: string = "";
  IssueTypeId: string = "";
  IssueTypeUserList: Array<IIssueTypeUser> = [];
  selectedUserList:Array<IIssueTypeUser> = [];
  MappingUser = [{ "Name": "Mapped User", "Id": 1 }, { "Name": "Unmapped User", "Id": 2 }, { "Name": "All User", "Id": 3 }]
  SelectUserType: any;

  constructor(
    private supportTicketMappingService: SupportTicketMappingService,
    private dataPersistance: DataPersistanceService,
    private alertService: AlertService
  ) { }

  ngOnInit() {
    this.GetAllIssueType();
  }
  addparent() {
    this.parent_visible = true;
  }
  Edit() {
    this.IsEdit = !this.IsEdit;
  }
  GetAllIssueType() {
    this.supportTicketMappingService.GetAllIssueType().subscribe((issutype) => {
      this.IssueTypes = issutype.map((issues) => {
        return {
          Id: issues.id,
          Name: issues.name
        }
      })
    }
    )

  }
  selectedIssueTypeId($event: DropdownChangeEvent) {
    this.IssueTypeId = this.selectedIssueType;
  }

  SaveIssueTypeWithUser(event: Event) {
    debugger;
    let userTypeMapping: issueMappedWithUser = new issueMappedWithUser();
    userTypeMapping.userIdList = this.selectedUserList.map(x => x.UserId);
    userTypeMapping.issueTypeId = this.IssueTypeId;
    userTypeMapping.mappedIdList = this.selectedUserList.map(x => x.IssueTypeMappingId);
    userTypeMapping.createdBy = this.dataPersistance.userGuid;

    this.supportTicketMappingService.saveIssueUserMapping(userTypeMapping).subscribe((data) => {
        if(data) {
          this.alertService.success('success', 'Issue mapped with User Successfully');
        }
      })
  }

  SelectUderType($event: DropdownChangeEvent) {
    let userid = this.dataPersistance.userId;
    this.supportTicketMappingService.GetUserType(this.IssueTypeId, this.SelectUserType).subscribe((issutypUser) => {
      this.IssueTypeUserList = issutypUser.map((user) => {
        return {
          UserId: user.userId,
          IssueTypeId: user.issueType,
          IssueTypeMappingId: user.issueTypeMappingId,
          CompanyName: user.companyName,
          Name: user.name,
          IssueType: user.issueType,
          CreatedOn: user.createdOn
        }
      }
      )
    }
    )
  }
  GetIssueTypeUser() {
    debugger;
    this.supportTicketMappingService.GetIssueTypeUser(this.IssueTypeId).subscribe((issutypUser) => {
      this.IssueTypeUserList = issutypUser.map((user) => {
        return {
          UserId: user.userId,
          IssueTypeId: user.issueType,
          IssueTypeMappingId: user.issueTypeMappingId,
          CompanyName: user.companyName,
          Name: user.name,
          IssueType: user.issueType,
          CreatedOn: user.createdOn
        }
      }
      )
    }
    )
  }
}
