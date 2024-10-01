import { Component, ElementRef } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
import { DataPersistanceService } from '../../../../../../core/services/data-persistance.service';
import { UserAccountApprovalService } from '../../services/user-account-approval.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AlertService } from '../../../../../../core/ui-services/alert.service';
import { AnnouncementService } from '../../../toolbox-mgt/services/announcement.service';
import { ProjectScheduleService } from '../../../featureone/services/project-schedule.service';
import { ISubProductTypes } from '../../../toolbox-mgt/models/subproduct-types.models';
import { TreeSelectModule } from 'primeng/treeselect';
import { Utility } from '../../../../../../core/utility/utility';
import { SendEmailUserApproval } from '../../models/send-email-user.modes';
import * as FileSaver from 'file-saver';
import { RegistrationService } from '../../../../../auth/services/registration.service';

@Component({
  selector: 'retail-user-account',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './user-account-approval.component.html',
  styleUrl: './user-account-approval.component.scss',
  providers: [UserAccountApprovalService, AnnouncementService, ProjectScheduleService
    , DatePipe, RegistrationService]
})
export class UserAccountApprovalComponent {
  parent_visible: boolean = false;
  user: boolean = false;
  edituser: boolean = false;
  sendEmailPopUp: boolean = false;
  decline: boolean = false;
  isAddFormSubmitted: boolean = false;
  isEmailSentForm: boolean = false;
  isUserDeclineForm: boolean = false;
  isAddParentCompany: boolean = false;
  userId: string = '';
  lstUsersView: Array<any> = [];
  lstUsersExoprt: Array<any> = [];
  lstUserType: Array<any> = [];
  lstStatus: Array<any> = [];
  lstProductType: Array<any> = [];
  lstBrand: Array<any> = [];
  lstDomains: Array<any> = [];
  lstBrandParentCompanyUserAccess: Array<any> = [];
  lstCountries: Array<any> = [];
  lstCities: Array<any> = [];
  lstState: Array<any> = [];

  constructor(
    private userAccountApprovalService: UserAccountApprovalService
    , private announcementService: AnnouncementService
    , private projectScheduleService: ProjectScheduleService
    , private formBuilder: FormBuilder
    , private elementref: ElementRef
    , private alert: AlertService
    , private datePipe: DatePipe
    , private registrationService: RegistrationService
  ) { }
  ngOnInit() {
    this.fillUsers("");
    this.fillUserTypes();
    this.fillStatus();
    this.fillProductFamily();
    this.fillBrands();
    this.fillGeoLocation();
    this.initializeAssignPermissionForm();
    this.initializeSendEmailForm();
    this.initializeDeclineUserForm();
    this.initializeParentCompanyForm();
  }
  frmViewUserInfo: FormGroup = new FormGroup({
    txtFirstName: new FormControl(''),
    txtMiddleName: new FormControl(''),
    txtLastName: new FormControl(''),
    txtUsername: new FormControl(''),
    txtCompanyEmail: new FormControl(''),
    ddlphoneextension: new FormControl(''),
    txtPhone: new FormControl(''),
    txtMobileNo: new FormControl(''),
    txtJobTitle: new FormControl(''),
    txtCompanyName: new FormControl(''),
    txtAddress1: new FormControl(''),
    txtAddress2: new FormControl(''),
    ddlCountry: new FormControl(''),
    ddlState: new FormControl(''),
    ddlCity: new FormControl(''),
    txtZipCode: new FormControl(''),
  });
  frmTextSearch: FormGroup = new FormGroup({
    txtSearch: new FormControl(''),
  });
  frmEditUserPermission: FormGroup = new FormGroup({
    hdnUserId: new FormControl(''),
    txtCompanyName: new FormControl(''),
    txtFirstName: new FormControl(''),
    txtMiddleName: new FormControl(''),
    txtLastName: new FormControl(''),
    txtCompanyEmail: new FormControl(''),
    selectProductType: new FormControl(''),
    selectUserType: new FormControl(''),
    selectedStatus: new FormControl(''),
  });
  frmSendEmailUser: FormGroup = new FormGroup({
    hdnEmailUserId: new FormControl(''),
    hdnEmailUserName: new FormControl(''),
    hdnEmailUserEmail: new FormControl(''),
    txtSubject: new FormControl(''),
    txtMessage: new FormControl(''),
  });
  frmDeclineUser: FormGroup = new FormGroup({
    hdnDeclineUserId: new FormControl(''),
    txtDeclineRemark: new FormControl(''),
  });
  frmAddParentCompany: FormGroup = new FormGroup({
    hdnUserIdAddParent: new FormControl(''),
    hdnParentCompanyId: new FormControl(''),
    txtCompanyName: new FormControl(''),
    selectProductType: new FormControl(''),
    selectBrand: new FormControl(''),
    txtDomain: new FormControl(''),
    switchAutoApprove: new FormControl(false),
  });
  private initializeAssignPermissionForm() {
    this.frmEditUserPermission = this.formBuilder.group({
      hdnUserId: ['', [Validators.required]],
      txtCompanyName: [''],
      txtFirstName: [''],
      txtMiddleName: [''],
      txtLastName: [''],
      txtCompanyEmail: [''],
      selectProductType: ['', [Validators.required]],
      selectUserType: ['', [Validators.required]],
      selectedStatus: ['', [Validators.required]],
    });
  }
  private initializeSendEmailForm() {
    this.frmSendEmailUser = this.formBuilder.group({
      hdnEmailUserId: ['', [Validators.required]],
      hdnEmailUserName: ['', [Validators.required]],
      hdnEmailUserEmail: ['', [Validators.required]],
      txtSubject: ['', [Validators.required]],
      txtMessage: ['', [Validators.required]],
    });
  }
  private initializeDeclineUserForm() {
    this.frmDeclineUser = this.formBuilder.group({
      hdnDeclineUserId: ['', [Validators.required]],
      txtDeclineRemark: ['', [Validators.required]],
    });
  }
  private initializeParentCompanyForm() {
    this.frmAddParentCompany = this.formBuilder.group({
      hdnUserIdAddParent: ['', [Validators.required]],
      hdnParentCompanyId: ['', [Validators.required]],
      txtCompanyName: ['', [Validators.required]],
      selectProductType: ['', [Validators.required]],
      selectBrand: ['', [Validators.required]],
      switchAutoApprove: [''],
      txtDomain: [''],
    });
  }
  fillUsers(searchText: string) {
    this.userAccountApprovalService.getUsers(searchText).subscribe((models) => {
      this.lstUsersView = models.map((model) => {
        return {
          id: model.id,
          userId: model.userId,
          firstName: model.firstName,
          lastName: model.lastName,
          customerDetailId: model.customerDetailId,
          customerCompanyName: model.customerCompanyName,
          address1: model.address1,
          address2: model.address2,
          countryID: model.countryID,
          countryName: model.countryName,
          stateID: model.stateID,
          stateName: model.stateName,
          cityID: model.cityID,
          cityName: model.cityName,
          companyEmail: model.companyEmail,
          zipCode: model.zipCode,
          mobileNo: model.mobileNo,
          phoneNo: model.phoneNo,
          jobTitle: model.jobTitle,
          isActive: model.isActive,
          created: this.datePipe.transform(model.created, 'yyyy-MM-dd'),
          isCompanyExists: model.isCompanyExists,
          brandId: model.brandId,
          brandName: model.brandName,
          domainName: model.domainName
        };
      });
      this.lstUsersExoprt = this.lstUsersView.map((item) => {
        return {
          "User Id": item.userId,
          "Company": item.customerCompanyName,
          "First Name": item.firstName,
          "Middle Name": item.middleName,
          "Last Name": item.lastName,
          "Email Address": item.companyEmail,
          "Product Requested": '',
          "Requsted Date": this.datePipe.transform(item.created, 'yyyy-MM-dd'),
          "Parent Company Exists": item.isCompanyExists ? 'Parent Company Already Exists' : 'Parent Company Not Exists',
          "Account Status": item.isActive ? 'Inactive' : 'Active'
        }
      })
    });
  }
  fillProductFamily() {
    this.projectScheduleService.getProductFamily().subscribe((prodFamily) => {
      this.lstProductType = prodFamily.map((prodF) => {
        return {
          id: prodF.id,
          label: prodF.productName,
          children: prodF.subProductTypeList.map((sub) => ({
            label: sub.subProductTypeName,
            id: sub.id,
            parent: prodF
          })) ?? [],
        };
      });
    });
  }

  fillUserTypes() {
    this.announcementService.getUsertype().subscribe((models) => {
      this.lstUserType = models.map((model) => {
        return {
          id: model.id
          , name: model.userTypeName
        };
      });
    });
  }
  fillStatus() {
    this.lstStatus = [
      { id: 0, name: "InActive" },
      { id: 1, name: "Active" },
    ]
  }
  fillBrands() {
    this.announcementService.getBrands().subscribe((models) => {
      this.lstBrand = models.map((model) => {
        return {
          id: model.id, name: model.brandName
        };
      });
    });
  }
  fillParentCompanyUserAccess(companyId: string) {
    this.userAccountApprovalService.getParentCompanyUserAccess(companyId).subscribe((models) => {
      this.lstBrandParentCompanyUserAccess = models.map((model) => {
        return {
          id: model.id,
          productId: model.productId,
          productName: model.productName,
          subProductId: model.subProductId,
          subProductName: model.subProductName,
          brandId: model.brandId,
          brandName: model.brandName,
          domainName: model.domainName,
        };
      });
    });
  }
  fillGeoLocation() {
    this.registrationService.getGeoLocations().subscribe((geoLocations) => {
      this.lstCountries = geoLocations.map((Geolocation) => {
        return {
          name: Geolocation.countryName,
          code: Geolocation.id,
          StateList:Geolocation.stateList,
          extension: Geolocation.countryCode,
        };
      });
    });    
  }
  fillState(selectedCountry: any) {
    Utility.clearDropdown(this.frmViewUserInfo, 'ddlState', '');
    Utility.clearDropdown(this.frmViewUserInfo, 'ddlCity', '');
    this.lstCities = [];
    this.lstState = this.lstCountries
      .filter((item) => {
        return item.code.includes(selectedCountry);
      })[0]
      .StateList.map((states: any) => {
        return {
          name: states.stateName,
          code: states.id,
          cityList: states.cityList,
        };
      });
  }
  fillCity(selectedState: any) {
    Utility.clearDropdown(this.frmViewUserInfo, 'ddlCity', '');
    this.lstCities = this.lstState
      .filter((item) => {
        return item.code.includes(selectedState);
      })[0]
      .cityList.map((cities: any) => {
        return {
          name: cities.cityName,
          code: cities.id,
        };
      });
  }
  searchTextUserList() {
    let searchText = this.frmTextSearch.get('txtSearch')?.value;
    this.fillUsers(searchText);
  }
  addparent(selectedVal: any) {
    this.frmAddParentCompany.get("hdnUserIdAddParent")?.setValue(selectedVal.id);
    this.frmAddParentCompany.get("hdnParentCompanyId")?.setValue(selectedVal.customerDetailId);
    this.frmAddParentCompany.get("txtCompanyName")?.setValue(selectedVal.customerCompanyName);
    this.frmAddParentCompany.get("selectBrand")?.setValue(selectedVal.brandId);

    if(selectedVal.domainName!=''||selectedVal.domainName!=undefined){
      let domain = selectedVal.domainName.split(',');
      
      domain.forEach((element:any) => {
        this.lstDomains.push({ name: element });
      });
    }

    this.fillParentCompanyUserAccess(selectedVal.customerDetailId);
    
    this.parent_visible = true;
  }
  edit_user(selectedVal: any) {
    this.frmViewUserInfo.get("txtFirstName")?.setValue(selectedVal.firstName);
    this.frmViewUserInfo.get("txtMiddleName")?.setValue(selectedVal.middleName);
    this.frmViewUserInfo.get("txtLastName")?.setValue(selectedVal.lastName);
    this.frmViewUserInfo.get("txtUsername")?.setValue(selectedVal.userId);
    this.userId = selectedVal.userId;
    this.frmViewUserInfo.get("txtCompanyEmail")?.setValue(selectedVal.companyEmail);
    this.frmViewUserInfo.get("txtPhone")?.setValue(selectedVal.phoneNo);
    this.frmViewUserInfo.get("ddlphoneextension")?.setValue(selectedVal.extension);
    this.frmViewUserInfo.get("txtMobileNo")?.setValue(selectedVal.mobileNo);
    this.frmViewUserInfo.get("txtJobTitle")?.setValue(selectedVal.jobTitle);
    this.frmViewUserInfo.get("txtCompanyName")?.setValue(selectedVal.customerCompanyName);
    this.frmViewUserInfo.get("txtAddress1")?.setValue(selectedVal.address1);
    this.frmViewUserInfo.get("txtAddress2")?.setValue(selectedVal.address2);
    this.frmViewUserInfo.get("txtAddress2")?.setValue(selectedVal.address2);
    this.frmViewUserInfo.get("ddlCountry")?.setValue(selectedVal.countryID);
    this.fillState(selectedVal.countryID);
    this.frmViewUserInfo.get("ddlState")?.setValue(selectedVal.stateID);
    this.fillCity(selectedVal.stateID);
    this.frmViewUserInfo.get("ddlCity")?.setValue(selectedVal.cityID);
    this.frmViewUserInfo.get("txtZipCode")?.setValue(selectedVal.zipCode);

    this.user = true;

  }
  edit_userPermission(selectedVal: any) {
    this.frmEditUserPermission.get("hdnUserId")?.setValue(selectedVal.id);
    this.frmEditUserPermission.get("txtCompanyName")?.setValue(selectedVal.customerCompanyName);
    this.frmEditUserPermission.get("txtFirstName")?.setValue(selectedVal.firstName);
    this.frmEditUserPermission.get("txtMiddleName")?.setValue(selectedVal.middleName);
    this.frmEditUserPermission.get("txtLastName")?.setValue(selectedVal.lastName);
    this.frmEditUserPermission.get("txtCompanyEmail")?.setValue(selectedVal.companyEmail);

    this.edituser = true;
  }
  sendEmail(selectedVal: any) {
    this.frmSendEmailUser.get("hdnEmailUserId")?.setValue(selectedVal.id);
    this.frmSendEmailUser.get("hdnEmailUserName")?.setValue(selectedVal.firstName);
    this.frmSendEmailUser.get("hdnEmailUserEmail")?.setValue(selectedVal.companyEmail);
    this.sendEmailPopUp = true;
  }
  declination(selectedUser: any) {
    this.frmDeclineUser.get("hdnDeclineUserId")?.setValue(selectedUser.id);
    this.decline = true;
  }
  assignRoleProduct() {
    this.isAddFormSubmitted = true;
    let userId = this.frmEditUserPermission.get("hdnUserId")?.value;
    let selectedProductType = this.frmEditUserPermission.get("selectProductType")?.value;
    let selectedUserType = this.frmEditUserPermission.get("selectUserType")?.value.id;
    let selectedStatus = this.frmEditUserPermission.get("selectedStatus")?.value.id;

    console.log('values', selectedProductType);

    let lstProductTypes: Array<any> = [];

    selectedProductType.forEach((element: any) => {
      if (!element.parent) {
        lstProductTypes.push({
          parentId: element.id,
          child: []
        })
      }
      else {
        let filteredItems = lstProductTypes.filter(item => item.parentId == element.parent.id);
        if (filteredItems.length > 0) {
          let singleItem = filteredItems[0];
          singleItem.child.push({
            subId: element.id,
            subName: element.label
          })
        } else {
          lstProductTypes.push({
            parentId: element.parent.id,
            child: [{
              subId: element.id,
              subName: element.label
            }]
          })
        }
      }
    });


    console.log('final lst', lstProductTypes);

    if (this.frmEditUserPermission.valid) {
      this.userAccountApprovalService.assignProductPermissionStatus(lstProductTypes, userId, selectedUserType, selectedStatus).subscribe(
        (response) => {
          this.alert.success("Success", "User updated successfully.");
          this.fillUsers('');
          this.sendEmailPopUp = false;
        },
        (error) => {
          this.alert.error('Failed', error.message);
        }
      );
    }
  }
  sendEmailtoUser() {
    this.isEmailSentForm = true;
    let sendEmailUserApproval: SendEmailUserApproval = new SendEmailUserApproval();
    sendEmailUserApproval.userId = this.frmSendEmailUser.get('hdnEmailUserId')?.value;
    sendEmailUserApproval.userName = this.frmSendEmailUser.get('hdnEmailUserName')?.value;
    sendEmailUserApproval.emailId = this.frmSendEmailUser.get('hdnEmailUserName')?.value;
    sendEmailUserApproval.subject = this.frmSendEmailUser.get('txtSubject')?.value;
    sendEmailUserApproval.body = this.frmSendEmailUser.get('txtMessage')?.value;

    if (this.frmSendEmailUser.valid) {
      this.userAccountApprovalService.userEmailAccountApproval(sendEmailUserApproval).subscribe(
        (response) => {
          this.alert.success("Success", "Email sent to user successfully.");
          this.fillUsers('');
          this.sendEmailPopUp = false;
        },
        (error) => {
          this.alert.error('Failed', error.message);
        }
      );
    }
  }
  declineUser() {
    this.isUserDeclineForm = true;

    let id = this.frmDeclineUser.get('hdnDeclineUserId')?.value;
    let remark = this.frmDeclineUser.get('txtDeclineRemark')?.value;


    if (this.frmDeclineUser.valid) {
      this.userAccountApprovalService.updateDeclineUser(id, remark).subscribe(
        (response) => {
          this.alert.success("Success", "User declined successfully.");
          this.decline = false;
          this.fillUsers('');
        },
        (error) => {
          this.alert.error('Failed', error.message);
        }
      );
    }
  }
  approveUser(selectedUser: any) {
    if (selectedUser.isCompanyExists) {
      this.userAccountApprovalService.updateApproveUser(selectedUser.id).subscribe(
        (response) => {
          this.alert.success("Success", "User approved successfully.");
          this.fillUsers('');
        },
        (error) => {
          this.alert.error('Failed', error.message);
        }
      );
    } else {
      this.alert.warn('InValid Inputs', "Parent company not added for this user.");
    }
  }
  cancelDecline() {
    this.decline = false;
    this.frmDeclineUser.reset();
  }
  cancelEditPermission() {
    this.edituser = false;
    this.frmEditUserPermission.reset();
  }
  cancelSendEmail() {
    this.sendEmailPopUp = false;
    this.frmSendEmailUser.reset();
  }
  addDomainToGrid() {
    let domainName = this.frmAddParentCompany.get('txtDomain')?.value;
    this.lstDomains.push({ name: domainName });
    this.frmAddParentCompany.get('txtDomain')?.setValue('');
  }
  addParentCompany() {
    this.isAddParentCompany = true;
    let id = this.frmAddParentCompany.get('hdnUserIdAddParent')?.value;
    let parentCompanyId = this.frmAddParentCompany.get('hdnParentCompanyId')?.value;
    let barndId = this.frmAddParentCompany.get('selectBrand')?.value.id;
    let selectedProductType = this.frmAddParentCompany.get("selectProductType")?.value;
    let switchAutoApprove = this.frmAddParentCompany.get('switchAutoApprove')?.value;

    let domains: Array<any> = [];
    if (this.lstDomains.length > 0) {
      domains = this.lstDomains.map(item => item.name);
    } else {
      this.alert.warn('InValid Inputs', "Please add domain.");
    }

    let lstProductTypes: Array<any> = [];

    selectedProductType.forEach((element: any) => {
      if (!element.parent) {
        lstProductTypes.push({
          parentId: element.id,
          child: []
        })
      }
      else {
        let filteredItems = lstProductTypes.filter(item => item.parentId == element.parent.id);
        if (filteredItems.length > 0) {
          let singleItem = filteredItems[0];
          singleItem.child.push({
            subId: element.id,
            subName: element.label
          })
        } else {
          lstProductTypes.push({
            parentId: element.parent.id,
            child: [{
              subId: element.id,
              subName: element.label
            }]
          })
        }
      }
    });

    if (this.frmAddParentCompany.valid) {
      this.userAccountApprovalService.editParentCompany(lstProductTypes, parentCompanyId
        , domains, barndId, switchAutoApprove).subscribe(
          (response) => {
            this.alert.success("Success", "Parent compant updated successfully.");
            this.frmAddParentCompany.reset();
            this.fillParentCompanyUserAccess(parentCompanyId);
            this.fillUsers('');
            this.lstDomains = [];
          },
          (error) => {
            this.alert.error('Failed', error.message);
          }
        );
    } else {
      this.alert.warn("Invalid Inputs", "Please check inputs.");
    }
  }
  cancelAddParent() {
    this.frmAddParentCompany.reset();
    this.parent_visible = false;
  }
  removeDomain(selectedDomain: any) {
    const index = this.lstDomains.indexOf(selectedDomain);
    if (index > -1) {
      this.lstDomains.splice(index, 1);
    }
  }
  exportExcel() {
    import("xlsx").then(xlsx => {
      const worksheet = xlsx.utils.json_to_sheet(this.lstUsersExoprt);
      const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
      this.saveAsExcelFile(excelBuffer, "users");
    });
  }

  saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + '_' + new Date().getTime() + EXCEL_EXTENSION);
  }
}
