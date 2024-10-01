import { Component, Input, ViewChild, inject, viewChild } from '@angular/core';
import { RegistrationService } from '../../../../../auth/services/registration.service';
import {
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
import { CommonModule } from '@angular/common';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { ProjectInfoService } from '../../services/project-info.service';
import { LoggerService } from '../../../../../../core/services/logger.service';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { every, firstValueFrom, Observable } from 'rxjs';
import { ICustomerCompanyName } from '../../models/customer-company-name.model';
import { createProject, ProjectCustomerParameter, ProjectDocumentParameter, ProjectUserParameter } from '../../models/create-project.model';
import { setThrowInvalidWriteToSignalError } from '@angular/core/primitives/signals';
import { DataPersistanceService } from '../../../../../../core/services/data-persistance.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomValidatorService } from '../../services/custom-validator.service';
import { updateProject, UpdateProjectCustomerParameter } from '../../models/update-project.model';
import { ProjectListService } from '../../services/project-list.service';
import { ConfirmDialogService } from '../../../../../../core/ui-services/confirm-dialog.service';
import { DeletedProjectParameter } from '../../models/project-list.model';
import { AlertService } from '../../../../../../core/ui-services/alert.service';
import { selectRequestCounter } from '../../../../../../core/states/request-counter/request-counter.selector';
import { DeletedProjectDocument, ProjectDocument } from '../../models/projectInfo.model';

@Component({
  selector: 'retail-project-info',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule, AutoCompleteModule],
  templateUrl: './project-info.component.html',
  styleUrl: './project-info.component.scss',
  providers: [ProjectInfoService, RegistrationService],
})
export class ProjectInfoComponent {
  lstVerticalMarket: any[] = [];
  lstProjectPhase: Array<any> = [];
  lstCountries: Array<any> = [];
  lstCities: Array<any> = [];
  lstState: Array<any> = [];
  lstStatus: Array<any> = [];
  geoLocations: Array<any> = [];
  lstSearchBy: Array<any> = [];
  lstUsers: Array<any> = [];
  lstUsersPrj: Array<any> = [];
  disableDeletedUser : boolean  = true;
  lstDocuments: Array<any> = [];
  files: any = [];
  totalSize: number = 0;
  totalSizePercent: number = 0;
  selectedPersmission: Array<any> = [];
  selectedDocuments: any[] = [];
  permissionLevelDropdown: boolean = true;
  lstAdminPermissionLevel: Array<any> = [];
  lstPermissionLevel: Array<any> = [];
  visible: boolean = false;
  divProjectUsersStatusandType: boolean = false;
  divGeneralProjectInformation: boolean = true;
  divOtherInformation: boolean = false;
  activeGeneralProjectInfo: string = 'active';
  activeProjectUserStatusAndType: string = '';
  activeOtherInformation: string = '';
  selectedCustomerCompanyName = '';
  customerCompanyNameSuggestion: Array<any> = [];
  customerCompanyName: Array<any> = [];
  selectedDeletedDocument: Array<ProjectDocument> = [];
  generalProjectInfoisFormSubmitted: boolean = false;
  otherInformationisFormSubmitted: boolean = false;
  createproject = new createProject();
  updateProject = new updateProject();
  projectCustomerParameter = new ProjectCustomerParameter();
  UpdateprojectCustomerParameter = new UpdateProjectCustomerParameter();
  projectUserParameterList: ProjectUserParameter[] = [];
  projectDocumentParameterList: ProjectDocumentParameter[] = [];
  isUserAdministrator: boolean = false;
  projectId: string = '';
  defaultValue: string = '8ab26d2c-c2c7-4abc-b3af-4a6bf305ef6f';
  updatedGeneralProjectInfoDetails: any;
  updatedprojectUserStatusAndTypeDetails: any;
  updatedotherInformationFromDetails: any;
  projectCustomerObjID: string = '';
  projectCreatedOn: string = '';
  projectCreatedBy: string = '';
  projectUpdatedOn : string ='';
  projectUpdatedBy : string  ='';
  newProjectName: string = '';

  constructor(
    private config: PrimeNGConfig,
    private messageService: MessageService,
    private registrationService: RegistrationService,
    private projectInfoService: ProjectInfoService,
    private datapersistance: DataPersistanceService,
    private projectListService: ProjectListService,
    private confirmDialogService: ConfirmDialogService,
    private alertService: AlertService,
    private logger: LoggerService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  generalProjectInformationForm: FormGroup = new FormGroup({
    projectName: new FormControl({ value: '', disabled: true }),
    selectedVerticalMarket: new FormControl(''),
    selectedProjectPhase: new FormControl(''),
    description: new FormControl('', {
      validators: [Validators.maxLength(100)],
      updateOn: 'blur',
    }),
    ExpectedBidDueDate: new FormControl(''),
    probability: new FormControl('', {
      validators: [Validators.max(100), Validators.min(0)],
      updateOn: 'blur',
    }),
    customerCompanyName: new FormControl('', {
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ],
      updateOn: 'blur',
    }),
    locationName: new FormControl('', {
      validators: [Validators.maxLength(50)],
      updateOn: 'blur',
    }),
    address1: new FormControl('', {
      validators: [Validators.maxLength(100)],
      updateOn: 'blur',
    }),
    address2: new FormControl('', {
      validators: [Validators.maxLength(100)],
      updateOn: 'blur',
    }),
    selectedCountry: new FormControl(''),
    selectedState: new FormControl(''),
    selectedCity: new FormControl(''),
    zipCode: new FormControl('', {
      validators: [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(9),
        Validators.pattern('^[0-9]*$'),
      ],
      updateOn: 'blur',
    }),
  });

  projectUserStatusAndType: FormGroup = new FormGroup({
    selectedStatus: new FormControl(''),
    // selectedAdminPersmission: new FormControl(''),
    selectedUser: new FormControl(),
    selectedSearchBy: new FormControl(''),
    txtsearch: new FormControl(''),
  });

  otherInformationFrom: FormGroup = new FormGroup({
    purchasingContractor: new FormControl('', {
      validators: [Validators.maxLength(50)],
    }),
    designEngineer: new FormControl('', {
      validators: [Validators.maxLength(50)],
    }),
    accountManagerwithContactRelationship: new FormControl('', {
      validators: [Validators.maxLength(50)],
    }),
    accountManagerwithEngineerRelationship: new FormControl('', {
      validators: [Validators.maxLength(50)],
    }),
    customerAccountManager: new FormControl('', {
      validators: [Validators.maxLength(50)],
    }),
    customerManagerOffice: new FormControl('', {
      validators: [Validators.maxLength(50)],
    }),
    selectedPersmission: new FormControl('', {
      validators: [Validators.maxLength(50)],
    }),
    uploadDocumentDescription: new FormControl(''),
  });

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.projectId = params['projectId'] || '';
    });
    this.route.queryParams.subscribe((params) => {
      this.newProjectName = params['projectname'] || '';
    });
    this.fillVerticalMarket();
    this.fillProjectPhase();
    this.fillCountries();
    this.fillStatus();
    this.fillSearchBy();
    this.fillAdminPermissionLevel();
    this.fillProjectPermissionLevel();
    this.fillUsers();
    this.getProjectData(this.projectId);
    //this.disableProjectNameTextBox(this.projectId);
  }
  GeneralProjectInformation() {
    this.activeGeneralProjectInfo = 'active';
    this.activeProjectUserStatusAndType = '';
    this.activeOtherInformation = '';
    this.divProjectUsersStatusandType = false;
    this.divOtherInformation = false;
    this.divGeneralProjectInformation = true;
  }
  ProjectUserStatusAndType() {
    this.activeGeneralProjectInfo = '';
    this.activeProjectUserStatusAndType = 'active';
    this.activeOtherInformation = '';
    this.divGeneralProjectInformation = false;
    this.divOtherInformation = false;
    this.divProjectUsersStatusandType = true;
  }
  OtherInformation() {
    this.activeGeneralProjectInfo = '';
    this.activeProjectUserStatusAndType = '';
    this.activeOtherInformation = 'active';
    this.divProjectUsersStatusandType = false;
    this.divGeneralProjectInformation = false;
    this.divOtherInformation = true;
  }
  disableProjectNameTextBox(projectId: string) {
    if (projectId != '')
      this.generalProjectInformationForm.get('projectName')?.disable();
  }

  fillVerticalMarket() {
    this.projectInfoService.getVerticalMarket().subscribe((verticalMarkets) => {
      this.lstVerticalMarket = verticalMarkets.map((verticalmarket) => {
        return {
          label: verticalmarket.projectVerticalName,
          id: verticalmarket.id,
          children: verticalmarket.subProjectVerticalList.map((sub) => ({
            label: sub.subProjectVerticalName,
            id: sub.id,
          })),
        };
      });
    });
  }

  fillProjectPhase() {
    this.projectInfoService.getProjectPhase().subscribe((projectPhases) => {
      this.lstProjectPhase = projectPhases.map((projectPhase) => {
        return {
          name: projectPhase.projectPhaseName,
          code: projectPhase.id,
        };
      });
    });
  }

  fillCountries() {
    this.registrationService.getGeoLocations().subscribe((geoLocations) => {
      this.geoLocations = geoLocations;
      this.lstCountries = geoLocations.map((Geolocation) => {
        return {
          name: Geolocation.countryName,
          code: Geolocation.id,
        };
      });
    });
  }

  //function will be triggered on change of country
  fillState() {
    let countryid =
      this.generalProjectInformationForm.get('selectedCountry')?.value;
    const country = this.geoLocations.find((c: any) => c.id === countryid);
    let stateList = country ? country.stateList : [];
    this.lstState = stateList.map((state: any) => {
      return {
        name: state.stateName,
        code: state.id,
      };
    });
  }

  fillStateByCountryId(countryID: string) {
    const country = this.geoLocations.find((c: any) => c.id === countryID);
    let stateList = country ? country.stateList : [];
    this.lstState = stateList.map((state: any) => {
      return {
        name: state.stateName,
        code: state.id,
      };
    });
  }

  //function will be triggered on change of state
  fillCity() {
    let countryid =
      this.generalProjectInformationForm.get('selectedCountry')?.value;
    let stateId =
      this.generalProjectInformationForm.get('selectedState')?.value;
    const country = this.geoLocations.find((c: any) => c.id === countryid);
    const state = country?.stateList.find((s: any) => s.id === stateId);
    const cityList = state ? state.cityList : [];
    this.lstCities = cityList.map((city: any) => {
      return {
        name: city.cityName,
        code: city.id,
      };
    });
  }

  fillCityByStateId(countryID: string, stateID: string) {
    const country = this.geoLocations.find((c: any) => c.id === countryID);
    const state = country?.stateList.find((s: any) => s.id === stateID);
    const cityList = state ? state.cityList : [];
    this.lstCities = cityList.map((city: any) => {
      return {
        name: city.cityName,
        code: city.id,
      };
    });
  }

  fillProjectPermissionLevel() {
    this.isUserAdministrator = false;
    this.projectInfoService
      .getProjectPermissionLevel()
      .subscribe((permissionLevels) => {
        this.lstPermissionLevel = permissionLevels.map((permissionLevel) => {
          return {
            name: permissionLevel.permissionLevelName,
            code: permissionLevel.id,
          };
        });
      });
    //Administrator permission level
  }
  fillAdminPermissionLevel() {
    this.projectInfoService
      .getAdministratorProjectPermissionLevel()
      .subscribe((permissionLevels) => {
        this.lstAdminPermissionLevel = permissionLevels.map(
          (permissionLevel) => {
            return {
              name: permissionLevel.permissionLevelName,
              code: permissionLevel.id,
            };
          }
        );
        this.logger.log('permission levels are', this.lstAdminPermissionLevel);
      });
  }

  fillStatus() {
    this.lstStatus = [
      { code: 1, name: 'Active' },
      { code: 0, name: 'InActive' },
    ];
  }
  fillSearchBy() {
    this.lstSearchBy = [
      { code: 'firstName', name: 'First Name' },
      { code: 'lastName', name: 'Last Name' },
      { code: 'userId', name: 'User Name' },
    ];
  }

  SaveNext() {
    this.divProjectUsersStatusandType = !this.divProjectUsersStatusandType;
    this.divGeneralProjectInformation = false;
  }

  getSearch() {
    let userID = localStorage.getItem('userId') || '';
    let searchCondition =
      this.projectUserStatusAndType.get('selectedSearchBy')?.value.code || '';
    let searchValue = this.projectUserStatusAndType.get('txtsearch')?.value;
    this.logger.log('conditions are',userID,searchCondition,searchValue);
    this.projectInfoService
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

  resetAddUserModel(){
    this.logger.log('reset method called');
    this.projectUserStatusAndType.reset();
    this.projectUserStatusAndType.get('selectedSearchBy')?.setValue('');
    this.getSearch();
    
  }

  fillUsers() {
    if(this.projectId == ''){
    setTimeout(() => {
      if (this.lstAdminPermissionLevel.length > 0) {
        let userID = localStorage.getItem('userId') || '';
        this.projectInfoService
          .getSearchInformation('userid', userID, userID)
          .subscribe((users) => {
            this.lstUsersPrj = users
              .filter((item) => {
                return item.userId.includes(userID);
              })
              .map((user) => {
                return {
                  firstName: user.firstName,
                  lastName: user.lastName,
                  userId: user.userId,
                  isSelected: true,
                  permission: this.lstAdminPermissionLevel[0].code,
                  id: this.datapersistance.userGuid,
                };
              });
          });
      } else {
      }
    }, 300);
  }
  }
  setSelectActive(selectedItem: any) {
    selectedItem.isSelected = !selectedItem.isSelected;
  }

  searchUserSave() {
    const selectedRows = this.lstUsers.filter((item) => item.isSelected);
    if (this.projectId == '')
       {
      this.lstUsersPrj = [...this.lstUsersPrj, ...selectedRows].filter(
        (item) => item.isSelected
      );
      this.lstUsersPrj = this.getUniqueRecords(this.lstUsersPrj);
    }
     else {
      var _users = selectedRows.filter((item) => item.isSelected);
      const existingUserIds = new Set(this.lstUsersPrj.map((user) => user.id));
      //do not push the duplicate record
      _users.forEach((element) => {
        if (!existingUserIds.has(element.id)) {
          this.lstUsersPrj.push(element);
          existingUserIds.add(element.id);
        }
        else
        {
          this.alertService.error('Error','User already added')
        }
      });
    }
    if(this.lstUsersPrj.length > 1){
    this.disableDeletedUser = false;
    }
    this.visible = false;
  }

  deleteUser(userToDelete :any){
    this.lstUsersPrj = this.lstUsersPrj.filter(user => user.id !== userToDelete.id);
  }

  getUniqueRecords(records: any[]): any[] {
    const uniqueNames = new Set();
    return records.filter((record) => {
      const isDuplicate = uniqueNames.has(record.userId);
      uniqueNames.add(record.userId);
      return !isDuplicate;
    });
  }

  showDialog() {
    this.visible = true;
    this.getSearch();
  }

  addProjectDocument() {
    if(this.projectId!=''){
    this.checkUserEditPermission().then((hasPermission)=>{
      if(hasPermission){
        this.visible = true;
      }
      else{
       this.alertService.error('Access Denied','Edit permission required to upload documents');
      }
    }).catch((error)=>{
      this.logger.error('error checking user permsission')
    })
  }
  else{
    this.visible = true;
  }
  }
  uploadDocument() {
    this.visible = false;
    this.logger.log('uploaded files are ',this.files);
    this.files.forEach((file : any) => {
      if (!this.isDuplicate(file)) {
      const fileData = {
        documentDescription: this.otherInformationFrom.get('uploadDocumentDescription')?.value,
        fileName: file.name,
        uploadedBy: "", // Replace with actual user if available
        uploadedOn: new Date().toISOString(), // Use current date/time
        file: file // Include the actual file object
      };
      this.lstDocuments.push(fileData);
    }
    else{
      this.alertService.warn('Failed',`${file.name} already Exists`);
    }
    });
  }
  isDuplicate(file: File): boolean {
    return this.lstDocuments.some(doc => doc.fileName === file.name && doc.file.size === file.size);
  }
  choose(event: any, callback: any) {
    callback();
  }

  onRemoveTemplatingFile(
    event: any,
    file: any,
    removeFileCallback: any,
    index: any
  ) {
    removeFileCallback(event, index);
    this.totalSize -= parseInt(this.formatSize(file.size));
    this.totalSizePercent = this.totalSize / 10;
  }

  onClearTemplatingUpload(clear: any) {
    clear();
    this.totalSize = 0;
    this.totalSizePercent = 0;
  }

  onTemplatedUpload() {
    this.messageService.add({
      severity: 'info',
      summary: 'Success',
      detail: 'File Uploaded',
      life: 3000,
    });
  }

  onSelectedFiles(event: any) {
    this.files = event.currentFiles;
    this.files.forEach((file: any) => {
      this.totalSize += parseInt(this.formatSize(file.size));
    });
    this.totalSizePercent = this.totalSize / 10;
  }

  uploadEvent(callback: any) {
    callback();
  }

  formatSize(bytes: any) {
    const k = 1024;
    const dm = 3;
    const sizes: any = this.config.translation.fileSizeTypes;
    if (bytes === 0) {
      return `0 ${sizes[0]}`;
    }

    const i = Math.floor(Math.log(bytes) / Math.log(k));
    const formattedSize = parseFloat((bytes / Math.pow(k, i)).toFixed(dm));
    return `${formattedSize} ${sizes[i]}`;
  }

  searchCustomerCompanyName($event: any) {
    this.projectInfoService
      .getCustomerCompanyNameList($event.query)
      .subscribe((companyNames) => {
        this.customerCompanyNameSuggestion = companyNames.map((companyName) => {
          return {
            name: companyName.customerCompanyName,
            code: companyName.id,
          };
        });
      });
  }

  permissionLevel(event: any, selectedValue: any) {
    selectedValue.permission = event.value;
    selectedValue.permissionType = event.value.name;
  }


  //create project
  GeneralProjectInformationFromData() {
    this.generalProjectInfoisFormSubmitted = true;

    if (this.generalProjectInformationForm.valid) {
      this.ProjectUserStatusAndType();
      this.createproject.projectName = this.newProjectName;
    
      this.createproject.verticalMarketId = this.generalProjectInformationForm.get('selectedVerticalMarket')?.value?.['id'] || null;
      this.createproject.projectPhaseId = this.generalProjectInformationForm.get('selectedProjectPhase')?.value || null;
      this.createproject.description = this.generalProjectInformationForm.get('description')?.value || null;
    
      const expectedBidDueDateValue = this.generalProjectInformationForm.get('ExpectedBidDueDate')?.value;
      this.createproject.ExpectedBidDueDate = expectedBidDueDateValue === null || expectedBidDueDateValue === '' ? null : new Date(expectedBidDueDateValue).toISOString();
    
      const probabilityValue = this.generalProjectInformationForm.get('probability')?.value;
      this.createproject.probability = probabilityValue === null || probabilityValue === '' ? 0 : probabilityValue;
    
      this.projectCustomerParameter.ID = null;
      this.projectCustomerParameter.customerCompanyDetailID = this.generalProjectInformationForm.get('customerCompanyName')?.value?.['code'] || null;
      this.projectCustomerParameter.customerLocationName = this.generalProjectInformationForm.get('locationName')?.value || null;
      this.projectCustomerParameter.customerAddress1 = this.generalProjectInformationForm.get('address1')?.value || null;
      this.projectCustomerParameter.customerAddress2 = this.generalProjectInformationForm.get('address2')?.value || null;
      this.projectCustomerParameter.countryID = this.generalProjectInformationForm.get('selectedCountry')?.value?.['code'] || null;
      this.projectCustomerParameter.stateId = this.generalProjectInformationForm.get('selectedState')?.value?.['code'] || null;
      this.projectCustomerParameter.cityId = this.generalProjectInformationForm.get('selectedCity')?.value?.['code'] || null;
      this.projectCustomerParameter.zipCode = this.generalProjectInformationForm.get('zipCode')?.value;
      this.createproject.createdBy = this.datapersistance.userGuid || '';
    } else {
      this.logger.log('Form is invalid');
    }
  }
  projectUserStatusAndTypeFormData() {
    for (let i = 0; i < this.lstUsersPrj.length; i++) {
      this.projectUserParameterList[i] = {
        //UserId: this.lstUsersPrj[i]['id'],
        UserId: this.lstUsersPrj[i]['id'] || '',
        permissionLevelID: this.lstUsersPrj[i]['permission'] || '',
      };
    }
    if (this.projectUserStatusAndType.get('selectedStatus')?.value.code == 0) {
      this.createproject.projectStatus = 0;
    } else this.createproject.projectStatus = 1;
  }
  otherInformationFormData() { 
    if (this.generalProjectInformationForm.valid && this.otherInformationFrom.valid) {
      this.createproject.purchasingContractor = this.otherInformationFrom.get('purchasingContractor')?.value || null;
      this.createproject.designEngineer = this.otherInformationFrom.get('designEngineer')?.value || null;
      this.createproject.accountManagerWithContractor = this.otherInformationFrom.get('accountManagerwithContactRelationship')?.value || null;
      this.createproject.accountManagerWithEngineer = this.otherInformationFrom.get('accountManagerwithEngineerRelationship')?.value || null;
      this.createproject.customerAccountManager = this.otherInformationFrom.get('customerAccountManager')?.value || null;
      this.createproject.customerManager = this.otherInformationFrom.get('customerManagerOffice')?.value || null;
    
      for (let i = 0; i < this.files.length; i++) {
        this.projectDocumentParameterList[i] = {
          fileName: this.files[i]['name'] || '',
          documentDescription: this.otherInformationFrom.get('uploadDocumentDescription')?.value || null
        };    
      }
      if (this.projectId === '') {
        this.createNewProject(
          this.createproject,
          this.projectCustomerParameter,
          this.projectUserParameterList,
          this.projectDocumentParameterList,
          this.files
        );
      } else {
        this.checkUserEditPermission().then((hasPermission)=>{
          if(hasPermission){
            this.UpdateProject()
          }
          else{
           this.alertService.error('Access Denied','You do not have edit permisson');
          }
        }).catch((error)=>{
          this.logger.error('error checking user permsission')
        })
      }
    } else {
      this.alertService.error('Can not create project','mandatory fields can not be blank')
      this.logger.log('form is invalid');
    }
  }

    checkUserEditPermission() : Promise<boolean> {
      return firstValueFrom(this.projectInfoService.checkUserEditPermission(this.projectId, this.datapersistance.userGuid)).then(result=>{
        return Boolean(result);
      }).catch(error=>{
        this.logger.error('Error checking user permission')
        throw error;
      })
    }

  //create New project
  createNewProject(
    createProject: createProject,
    projectCustomerParameter: ProjectCustomerParameter,
    projectUserParameterList: ProjectUserParameter[],
    projectDocumentParameterList: ProjectDocumentParameter[],
    files: File[]
  ) {
    this.projectInfoService
      .createProject(
        createProject,
        projectCustomerParameter,
        projectUserParameterList,
        projectDocumentParameterList,
        files
      )
      .subscribe(
        (response) => {
          if (response.statusCode === 200) {
            this.alertService.success('Success', response.message);
            this.router.navigateByUrl('/home/featureone/my-project');
          }
        },
        (error) => {
          this.alertService.error('Failed', 'Something went wrong');
        }
      );
  }
  UpdateProject() {
    this.logger.log('user project data is ',this.lstUsersPrj);
    const projectUserParameterList = this.lstUsersPrj.map((user) => ({
      UserId: user.id,
      permissionLevelID: user.permissionId,
    }));

    this.AddFormDataToUpdateModel(
      this.generalProjectInformationForm.value,
      this.otherInformationFrom.value
    );
    this.projectInfoService
      .updateProject(
        this.updateProject,
        this.UpdateprojectCustomerParameter,
        projectUserParameterList
      )
      .subscribe(
        (response) => {
          if (response.statusCode === 200) {
            this.alertService.success('Success', response.message);
            this.router.navigateByUrl('/home/featureone/my-project');
          }
        },
        (error) => {
          this.alertService.error('Failed', error.message);
        }
      );
  }
  //udpate Existing project
  getProjectData(projectID: string) {
    if (projectID != ''){
      const userGuid = this.datapersistance.userGuid;
      this.projectInfoService
        .getExistingProject(projectID,userGuid)
        .subscribe((projectDetail) => {
          this.editFormDetails(projectDetail);
        });
      }
  }
  editFormDetails(projectDetail: any) {
    this.logger.log('project detail ', projectDetail);
    this.projectCreatedOn = new Date(projectDetail.createdOn).toLocaleDateString();
    this.projectCreatedBy = projectDetail.createdBy;
    this.projectUpdatedOn = new Date(projectDetail.updatedOn).toLocaleDateString();
    this.projectUpdatedBy  = projectDetail.updatedBy;
    const formattedStartDate = new Date(projectDetail.expectedBidDueDate);

    this.fillStateByCountryId(projectDetail.projectCustomerObj.countryID);
    this.fillCityByStateId(
      projectDetail.projectCustomerObj.countryID,
      projectDetail.projectCustomerObj.stateId
    );

    this.projectCustomerObjID = projectDetail.projectCustomerObj.id;

    this.generalProjectInformationForm.get('projectName')?.setValue(projectDetail.projectName);
    this.generalProjectInformationForm.get('selectedProjectPhase')?.setValue(projectDetail.projectPhaseId);

// Replace hardcoded label value with dynamic value
    let defaultSelectedItem = {
      label: 'Farming/Livestock',
      id: projectDetail.projectVerticalID,
      children: [],
    };
    this.generalProjectInformationForm.get('selectedVerticalMarket')?.setValue(defaultSelectedItem);
    this.generalProjectInformationForm.get('description')?.setValue(projectDetail.description);

    if (formattedStartDate.toLocaleDateString() === '1/1/1970') {
      this.generalProjectInformationForm.controls['ExpectedBidDueDate'].setValue('');
    } else {
      this.generalProjectInformationForm.controls['ExpectedBidDueDate'].setValue(formattedStartDate);
    }

    this.generalProjectInformationForm.get('probability')?.setValue(projectDetail.probability);
    // Replace hardcoded customerCompanyName with actual value
    this.generalProjectInformationForm.get('customerCompanyName')?.setValue({
      name: projectDetail.projectCustomerObj.customerCompanyDetailName,
      code: projectDetail.projectCustomerObj.customerCompanyDetailID,
    });
    this.generalProjectInformationForm.get('locationName')?.setValue(projectDetail.projectCustomerObj.customerLocationName);
    this.generalProjectInformationForm.get('address1')?.setValue(projectDetail.projectCustomerObj.customerAddress1);
    this.generalProjectInformationForm.get('address2')?.setValue(projectDetail.projectCustomerObj.customerAddress2);
    this.generalProjectInformationForm.get('selectedCountry')?.setValue(projectDetail.projectCustomerObj.countryID);
    this.generalProjectInformationForm.get('selectedState')?.setValue(projectDetail.projectCustomerObj.stateId);
    this.generalProjectInformationForm.get('selectedCity')?.setValue(projectDetail.projectCustomerObj.cityId);
    this.generalProjectInformationForm.get('zipCode')?.setValue(projectDetail.projectCustomerObj.zipCode);
    // Project user status and type
    this.projectUserStatusAndType.get('selectedStatus')?.setValue(projectDetail.projectStatus);
    if(this.projectId!=''){
    this.lstUsersPrj = projectDetail.customProjectUserList.map((user: any) => ({
      userId: user.userName,
      firstName: user.firstName,
      lastName: user.lastName,
      permissionId: user.permissionLevelID,
      id: user.userID,
    }));
  }
    // Other contact details
    this.otherInformationFrom.get('purchasingContractor')?.setValue(projectDetail.purchasingContractor);
    this.otherInformationFrom.get('designEngineer')?.setValue(projectDetail.designEngineer);
    this.otherInformationFrom.get('accountManagerwithContactRelationship')?.setValue(projectDetail.accountManagerWithContractor);
    this.otherInformationFrom.get('accountManagerwithEngineerRelationship')?.setValue(projectDetail.accountManagerWithContractor);
    this.otherInformationFrom.get('customerAccountManager')?.setValue(projectDetail.customerAccountManager);
    this.otherInformationFrom.get('customerManagerOffice')?.setValue(projectDetail.customerManager);
    // Project document list
    this.lstDocuments = projectDetail.projectDocumentList;
  }

  AddFormDataToUpdateModel(
    generalProjectInformation: any,
    otherInformationFrom: any
  ) {
    this.updateProject.ID = this.projectId;
    this.updateProject.projectName = generalProjectInformation.projectName;
    this.updateProject.verticalMarketId = generalProjectInformation.selectedVerticalMarket?.id || null;
    this.updateProject.projectPhaseId = generalProjectInformation.selectedProjectPhase || null;
    this.updateProject.description = generalProjectInformation.description || null;
    if(generalProjectInformation.ExpectedBidDueDate ===''){
      generalProjectInformation.ExpectedBidDueDate = null;
    }
    else
    {
    this.updateProject.ExpectedBidDueDate = new Date(generalProjectInformation.ExpectedBidDueDate).toISOString() || null;
    }
    this.updateProject.probability = generalProjectInformation.probability || 0;
    this.updateProject.purchasingContractor = otherInformationFrom.purchasingContractor || null;
    this.updateProject.designEngineer = otherInformationFrom.designEngineer || null;
    this.updateProject.accountManagerWithContractor = otherInformationFrom.accountManagerwithContactRelationship || null;
    this.updateProject.accountManagerWithEngineer = otherInformationFrom.accountManagerwithEngineerRelationship || null;
    this.updateProject.customerAccountManager = otherInformationFrom.customerAccountManager || null;
    this.updateProject.customerManager = otherInformationFrom.customerManagerOffice || null;

    const selectedStatusCode = this.projectUserStatusAndType.get('selectedStatus')?.value.code;
    this.updateProject.projectStatus = typeof selectedStatusCode === 'undefined' ? 1 : selectedStatusCode;

    this.updateProject.createdBy = this.datapersistance.userGuid;
    this.UpdateprojectCustomerParameter.ID = this.projectCustomerObjID;
    this.UpdateprojectCustomerParameter.customerCompanyDetailID = generalProjectInformation.customerCompanyName.code;
    this.UpdateprojectCustomerParameter.customerLocationName = generalProjectInformation.locationName || null;
    this.UpdateprojectCustomerParameter.customerAddress1 = generalProjectInformation.address1 || null;
    this.UpdateprojectCustomerParameter.customerAddress2 = generalProjectInformation.address2 || null;
    this.UpdateprojectCustomerParameter.countryID = generalProjectInformation.selectedCountry || null;
    this.UpdateprojectCustomerParameter.stateId = generalProjectInformation.selectedState || null;
    this.UpdateprojectCustomerParameter.cityId = generalProjectInformation.selectedCity || null;
    this.UpdateprojectCustomerParameter.zipCode = generalProjectInformation.zipCode;
  }

  cancelGeneralProjectInfoForm() {
    this.generalProjectInformationForm.reset();
    this.generalProjectInformationForm.markAsPristine();
    this.generalProjectInformationForm.markAsUntouched();
    this.generalProjectInfoisFormSubmitted = false;
  }

  deleteDocument() {

    this.checkUserEditPermission().then((hasPermission)=>{
      if(hasPermission){
        let searchParam: DeletedProjectDocument = new DeletedProjectDocument();
        searchParam.projectId = this.projectId;
        searchParam.documentListId = this.selectedDeletedDocument.map((x) => x.id);
        searchParam.userId = this.datapersistance.userGuid;
    
        this.confirmDialogService.confirm({
          message: 'Do you want to delete this record?',
          header: 'Delete Confirmation',
          icon: 'pi pi-info-circle',
          acceptButtonStyleClass: 'p-button-danger p-button-text',
          rejectButtonStyleClass: 'p-button-text p-button-text',
          acceptIcon: 'none',
          rejectIcon: 'none',
    
          accept: () => {
            this.projectInfoService
              .deleteDocuments(searchParam)
              .subscribe((data) => {
                if (data) {
                  this.alertService.success(
                    'success',
                    'document has been deleted successfully'
                  );
                } else
                  this.alertService.success(
                    'failure',
                    'document has not been deleted'
                  );
              });
          },
          reject: () => {
            //this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
          },
        });
      }
      else{
       this.alertService.error('Access Denied','Edit permission required to delete documents');
      }
    }).catch((error)=>{
      this.logger.error('error checking user permsission')
    })


  }

  deleteSingleProject(item: any) {
    let searchParam: DeletedProjectParameter = new DeletedProjectParameter();
    let projecIdList: Array<string> = [];
    projecIdList.push(item);
    searchParam.projectListId = projecIdList;
    searchParam.userId = this.datapersistance.userGuid;

    this.confirmDialogService.confirm({
      message: 'Do you want to Archive this record?',
      header: 'Archive Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',

      accept: () => {
        this.projectListService
          .deleteProjects(searchParam)
          .subscribe((data) => {
            if (data) {
              this.alertService.success(
                'success',
                'project has been Archived successfully'
              );
              this.router.navigateByUrl('/home/featureone/my-project');
            } else
              this.alertService.success(
                'failure',
                'project has not been Archived'
              );
          });
      },
      reject: () => {
        //this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
      },
    });
  }
  downloadDocument(documentDetail: any) {
    debugger;
    this.projectInfoService
      .downloadDocument(
        `Project/${documentDetail.projectId}`,
        documentDetail.fileName
      )
      .subscribe((result) => {
        this.logger.log(result);
      });
  }
  restrictKey(event: KeyboardEvent) {
    const allowedKeys = [
      'Backspace',
      'Tab',
      'ArrowLeft',
      'ArrowRight',
      'Delete',
      'End',
      'Home',
    ];
    if (!allowedKeys.includes(event.key) && !/^[0-9]$/.test(event.key)) {
      event.preventDefault();
    }
  }
}
