import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
import { DataPersistanceService } from '../../../../../../core/services/data-persistance.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoggerService } from '../../../../../../core/services/logger.service';
import { AddProjectUserParameter, DeletedProjectParameter, ProjectListView, ProjectSearchParameter } from '../../models/project-list.model';
import { ProjectListService } from '../../services/project-list.service';
import { Route, Router, RouterLink } from '@angular/router';
import { AlertService } from '../../../../../../core/ui-services/alert.service';
import { ConfirmDialogService } from '../../../../../../core/ui-services/confirm-dialog.service';
import { ProjectInfoComponent } from "../project-info/project-info.component";
import { CustomValidatorService } from '../../services/custom-validator.service';
import { ProjectInfoService } from '../../services/project-info.service';
import { ProjectScheduleService } from '../../services/project-schedule.service';

@Component({
  selector: 'retail-my-project',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule, ProjectInfoComponent],
  templateUrl: './my-project.component.html',
  styleUrl: './my-project.component.scss',
  providers: [
    ProjectInfoService,
    CustomValidatorService,
    ProjectScheduleService,
    ProjectInfoService,
  ],
})
export class MyProjectComponent {
  constructor(
    private dataPersistenceService: DataPersistanceService,
    private logger: LoggerService,
    private projectListService: ProjectListService,
    private router: Router,
    private confirmDialogService: ConfirmDialogService,
    private alertService: AlertService,
    private customValidator: CustomValidatorService,
    private projectScheduleService: ProjectScheduleService,
    private projectInfoService: ProjectInfoService
  ) {}
  newProjectForm: FormGroup = new FormGroup({
    newProjectName: new FormControl('', {
      validators: [Validators.required, Validators.maxLength(50)],
      asyncValidators: [this.customValidator.DuplicateProjectNameValidator()],
      updateOn: 'submit',
    }),
  });

  myProjectListForm: FormGroup = new FormGroup({
    selectedStatus: new FormControl(''),
    selectedQuickSearch: new FormControl(''),
    txtSearchValue: new FormControl(''),
    selectedQuickSearchRestore: new FormControl(''),
    txtSearchValueRestore: new FormControl(''),
    btnOtherEmployeeProj: new FormControl(''),
  });

  projectUserStatusAndType: FormGroup = new FormGroup({
    selectedSearchBy: new FormControl(''),
    txtsearch: new FormControl(''),
  });

  isOtherEmployeeProjectDisplay: boolean = false;
  visible: boolean = false;
  display: boolean = false;
  user: boolean = false;
  access: boolean = false;
  lstStatus: Array<any> = [];
  lstQuickSearchValue: Array<any> = [];
  deletedProjectList: Array<ProjectListView> = [];
  projectList: Array<ProjectListView> = [];
  selectedPrjectList: Array<ProjectListView> = [];
  selectedDeletedProjList: Array<ProjectListView> = [];
  userName: string = '';
  customeLabel: string = 'Show Other Employee Projects';
  lstSearchBy: Array<any> = [];
  lstUsers: Array<any> = [];
  lstUsersPrj: Array<any> = [];
  addUserProjectId: string = '';
  newProjectName: string = '';
  isNewProjectFormSubmitted: boolean = false;

  ngOnInit() {
    this.fillStatus();
    this.getUserName();
    this.fillQuickSearchValue();
    this.showProductWithCondition();
    this.fillSearchBy();
  }

  fillStatus() {
    this.lstStatus = [
      { code: 0, name: 'InActive' },
      { code: 1, name: 'Active' },
      { code: 2, name: 'Show All' },
    ];
  }

  fillSearchBy() {
    this.lstSearchBy = [
      { code: 'firstName', name: 'First Name' },
      { code: 'lastName', name: 'Last Name' },
      { code: 'userId', name: 'User Id' },
    ];
  }

  getSearch() {
    let userID = localStorage.getItem('userId') || '';
    let searchCondition =
      this.projectUserStatusAndType.get('selectedSearchBy')?.value.code || '';
    let searchValue =
      this.projectUserStatusAndType.get('txtsearch')?.value || '';
    this.projectListService
      .getSearchInformation(searchCondition, searchValue, userID)
      .subscribe((users) => {
        this.lstUsers = users.map((user) => {
          return {
            firstName: user.firstName,
            lastName: user.lastName,
            userId: user.userId,
            id: user.id,
          };
        });
      });
  }

  getUniqueRecords(records: any[]): any[] {
    const uniqueNames = new Set();
    return records.filter((record) => {
      const isDuplicate = uniqueNames.has(record.userId);
      uniqueNames.add(record.userId);
      return !isDuplicate;
    });
  }

  setSelectActive(selectedItem: any) {
    selectedItem.isSelected = !selectedItem.isSelected;
  }

  fillQuickSearchValue() {
    this.lstQuickSearchValue = [
      { code: 0, name: 'All' },
      { code: 7, name: 'This Week' },
      { code: 30, name: 'This Month' },
      { code: 365, name: 'This Year' },
    ];
  }

  ShowOtherEmployeeProject() {
    this.isOtherEmployeeProjectDisplay = !this.isOtherEmployeeProjectDisplay;

    this.customeLabel = this.isOtherEmployeeProjectDisplay
      ? 'Show My Projects'
      : 'Show Other Employee Projects';

    this.showProductWithCondition();
  }

  showProductWithCondition() {
    this.isOtherEmployeeProjectDisplay
      ? this.searchOtherEmployeeProduct()
      : this.searchProduct();
  }

  advance() {
    this.visible = true;
  }
  restore() {
    this.display = true;
    this.searchDeletedProduct();
  }
  getUserName() {
    this.userName = this.dataPersistenceService.userName;
  }

  searchUserSave() {
    debugger;
    const selectedRows = this.lstUsers.filter((item) => item.isSelected);

    this.lstUsersPrj = [...this.lstUsersPrj, ...selectedRows].filter(
      (item) => item.isSelected
    );
    this.lstUsersPrj = this.getUniqueRecords(this.lstUsersPrj);

    let addUserParam: AddProjectUserParameter = new AddProjectUserParameter();
    addUserParam.createdUserId = this.dataPersistenceService.userGuid;
    addUserParam.projectId = this.addUserProjectId;
    let userIdList: Array<string> = [];
    for (let i = 0; i < this.lstUsersPrj.length; i++) {
      userIdList.push(this.lstUsersPrj[i]['id'] || '');
    }
    addUserParam.userIdList = userIdList;
    if (addUserParam.userIdList.length > 0) {
      this.projectListService
        .addAdditionalUsers(addUserParam)
        .subscribe((data) => {
          if (data) {
            this.alertService.success('success', 'user added successfully');
          } else
            this.alertService.success('failure', 'user has not been added');
        });
      this.visible = false;
    } else {
      this.alertService.error('Error', 'No user selected');
    }
  }

  searchOtherEmployeeProduct() {
    this.logger.log('search Other Employee called');
    let searchParam: ProjectSearchParameter = new ProjectSearchParameter();
    searchParam.basicSearchValue =
      this.myProjectListForm.get('txtSearchValue')?.value || '';
    searchParam.projectStatus =
      this.myProjectListForm.get('selectedStatus')?.value['code'] || 2;
    searchParam.quickSearchValue =
      this.myProjectListForm.get('selectedQuickSearch')?.value['code'] || 0;
    searchParam.userGuidValue = this.dataPersistenceService.userGuid;
    searchParam.IsDeleted = 0;
    searchParam.IsOtherEmployeeProject = true;

    this.projectListService
      .getProjectInfoList(searchParam)
      .subscribe((projectListViewColl) => {
        this.projectList = projectListViewColl;
      });
  }

  searchProduct() {
    this.logger.log('search product called');
    let searchParam: ProjectSearchParameter = new ProjectSearchParameter();
    searchParam.basicSearchValue =
      this.myProjectListForm.get('txtSearchValue')?.value || '';
    searchParam.projectStatus =
      this.myProjectListForm.get('selectedStatus')?.value['code'] || 2;
    searchParam.quickSearchValue =
      this.myProjectListForm.get('selectedQuickSearch')?.value['code'] || 0;
    searchParam.userGuidValue = this.dataPersistenceService.userGuid;
    searchParam.IsDeleted = 0;
    searchParam.IsOtherEmployeeProject = false;

    this.projectListService
      .getProjectInfoList(searchParam)
      .subscribe((projectListViewColl) => {
        this.projectList = projectListViewColl;
        this.logger.log('projectList ', this.projectList);
      });
  }

  searchDeletedProduct() {
    this.logger.log('search deleted product called');
    let searchParam: ProjectSearchParameter = new ProjectSearchParameter();
    searchParam.basicSearchValue =
      this.myProjectListForm.get('txtSearchValueRestore')?.value || '';
    searchParam.quickSearchValue =
      this.myProjectListForm.get('selectedQuickSearchRestore')?.value['code'] ||
      0;
    searchParam.userGuidValue = this.dataPersistenceService.userGuid;
    searchParam.IsDeleted = 1;
    searchParam.projectStatus = 2;
    searchParam.IsOtherEmployeeProject = false;

    this.logger.log('form value', searchParam);

    this.projectListService
      .getProjectInfoList(searchParam)
      .subscribe((projectListViewColl) => {
        this.deletedProjectList = projectListViewColl;
        this.logger.log('Deleted projectList ', this.deletedProjectList);
      });
  }

  moveToSchedule(projectid: string) {
    this.logger.log('move into schedule');
    this.router.navigate(['/home/featureone/project-schedule'], {
      queryParams: { projectId: projectid },
    });
  }

  moveToProjectInfo(projectid: string) {
    this.logger.log('move into Project Info');
    this.router.navigate(['/home/featureone/project-info'], {
      queryParams: { projectId: projectid },
    });
  }

  restoreSelectedProject(event: Event) {
    this.confirmDialogService.confirm({
      target: event.target as EventTarget,
      message: 'Do you want to restore this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',

      accept: () => {
        let searchParam: DeletedProjectParameter =
          new DeletedProjectParameter();
        searchParam.projectListId = this.selectedDeletedProjList.map(
          (x) => x.id
        );
        searchParam.userId = this.dataPersistenceService.userGuid;

        this.selectedDeletedProjList = [];
        this.projectListService
          .restoreProjects(searchParam)
          .subscribe((data) => {
            if (data) {
              this.alertService.success(
                'success',
                'project has been restore successfully'
              );
              this.searchDeletedProduct();
              this.showProductWithCondition();
              this.display = false;
            } else
              this.alertService.error(
                'failure',
                'project has not been restore'
              );
            this.display = false;
          });
      },
      reject: () => {
        //this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
      },
    });
  }

  deletedProject(event: Event, searchParam: DeletedProjectParameter) {
    this.confirmDialogService.confirm({
      target: event.target as EventTarget,
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',

      accept: () => {
        this.selectedPrjectList = [];

        this.projectListService
          .deleteProjects(searchParam)
          .subscribe((data) => {
            if (data) {
              this.alertService.success(
                'success',
                'project has been deleted successfully'
              );
              this.showProductWithCondition();
            } else
              this.alertService.success(
                'failure',
                'project has not been deleted'
              );
          });
      },
      reject: () => {
        //this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
      },
    });
  }

  deleteSingleProject(event: Event, item: any) {
    let searchParam: DeletedProjectParameter = new DeletedProjectParameter();
    let projecIdList: Array<string> = [];
    projecIdList.push(item);
    searchParam.projectListId = projecIdList;
    searchParam.userId = this.dataPersistenceService.userGuid;

    this.deletedProject(event, searchParam);
  }

  deleteSelectedProject(event: Event) {
    let searchParam: DeletedProjectParameter = new DeletedProjectParameter();
    searchParam.projectListId = this.selectedPrjectList.map((x) => x.id);
    searchParam.userId = this.dataPersistenceService.userGuid;

    this.deletedProject(event, searchParam);
  }
  adduser(projectId: string) {
    this.projectInfoService
      .checkUserEditPermission(projectId, this.dataPersistenceService.userGuid)
      .subscribe((hasPermission) => {
        if (hasPermission) {
          this.addUserProjectId = projectId;
          this.user = true;
          this.getSearch();
        } else {
          this.alertService.error(
            'Access Denied',
            'Add User Permission Required'
          );
        }
      });
  }
  projectaccess() {
    this.access = true;
  }
  newFormdata() {
    this.isNewProjectFormSubmitted = true;
    setTimeout(() => {
      if (this.newProjectForm.valid) {
        this.newProjectName = this.newProjectForm.get('newProjectName')?.value;
        this.router.navigateByUrl(
          `/home/featureone/project-info?projectname=${this.newProjectName}`
        );
      } else {
        this.logger.log('Invalid project Name');
      }
    }, 100);
  }
  restrictSpace(event: KeyboardEvent) {
    if (event.key === ' ' || event.code === 'Space') {
      event.preventDefault();
    }
  }
}
