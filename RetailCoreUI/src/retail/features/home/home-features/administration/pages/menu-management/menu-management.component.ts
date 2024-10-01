import { Component, ElementRef } from '@angular/core';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
import { CommonModule } from '@angular/common';
import { AnnouncementService } from '../../../toolbox-mgt/services/announcement.service';
import { MenuManagementService } from '../../../../services/menu-mangement.service';
import { DataPersistanceService } from '../../../../../../core/services/data-persistance.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserRoleMappingService } from '../../services/user-role-mapping.service';
import { Utility } from '../../../../../../core/utility/utility';
import { AlertService } from '../../../../../../core/ui-services/alert.service';

@Component({
  selector: 'retail-menu-management',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './menu-management.component.html',
  styleUrl: './menu-management.component.scss',
  providers: [AnnouncementService, UserRoleMappingService, MenuManagementService]
})
export class MenuManagementComponent {
  addPopUp: boolean = false;
  editPopUp: boolean = false;
  viewPopUp: boolean = false;
  isAddEditOnly: boolean = true;
  isEditOnly: boolean = false;
  isAddOnly: boolean = false;
  lstUserPermissionsView: Array<any> = [];
  lstUserType: Array<any> = [];
  lstMainMenus: Array<any> = [];
  lstSubMenus: Array<any> = [];
  lstUserPermissionsSingle: Array<any> = [];
  _subMenu:Array<any> = [];
  isAddFormSubmitted: boolean = false;
  headerName:string='Add New Mapping';

  constructor(
    private dataPersistenceService: DataPersistanceService
    , private announcementService: AnnouncementService
    , private userRoleMappingService: UserRoleMappingService
    , private menuManagementService: MenuManagementService
    , private formBuilder: FormBuilder
    , private elementref: ElementRef
    , private alert: AlertService
  ) { }
  ngOnInit() {
    this.fillUserTypes();
    this.fillMenus();
    this.initializeAddNewMappingForm();
    this.fillUserMenuPermissionList('');
  }
  formAddMapping: FormGroup = new FormGroup({
    selectUserType: new FormControl(''),
    selectMainMenu: new FormControl(''),
    selectSubMenu: new FormControl(''),
  });
  frmTextSearch: FormGroup = new FormGroup({
    txtSearch: new FormControl(''),
  });
  private initializeAddNewMappingForm() {
    this.formAddMapping = this.formBuilder.group({
      selectUserType: ['', [Validators.required]],
      selectMainMenu: ['', [Validators.required]],
      selectSubMenu: [''],
    });
  }
  fillUserMenuPermissionList(searchText:string) {
    this.userRoleMappingService.getUserMenuPermissionList(searchText).subscribe((models) => {
      this.lstUserPermissionsView = models.map((model) => {
        return {
          roleId: model.roleId,
          userTypeName: model.userTypeName,
          mainMenuId: model.mainMenuId,
          mainMenuName: model.mainMenuName,
          subMenuId: model.subMenuId,
          subMenuName:model.subMenuName,
          createdDate: model.createdDate,
          createdBy: model.createdBy,
          createdByName: model.createdByName,
          userMenuPermission:model.lstUserMenuPermission,
          roleUserPermission: model.lstRoleUserPermission
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
  fillMenus() {
    this.menuManagementService.getLeftSideMenus().subscribe((menus) => {
      this.lstMainMenus = menus
        .filter(menu => menu.isActive) // Filter by isActive
        .map((menu) => {
          return {
            id: menu.id,
            name: menu.name,
            parent: menu.parentId,
            active: false,
            url: menu.routePath,
            child: menu.child,
            menuOrder: menu.menuOrder,
          };
        })
        .sort((a, b) => a.menuOrder.localeCompare(b.menuOrder));
    });
  }
  fillSubMenus() {
    let selectMainMenus = this.formAddMapping.get('selectMainMenu')?.value;
    if (selectMainMenus.length <= 0) {
      return;
    }
    let menus = this.lstMainMenus.filter(item =>
      selectMainMenus.some((x: any) =>
        x.id == item.id));

    let subMenus = menus.map((model) => {
      return {
        child: model.child
      };
    });
    this.lstSubMenus = [];
    subMenus.forEach(element => {
      let child = element.child;

      child.forEach((elementSub: any) => {
        this.lstSubMenus.push(elementSub);
      });

    });
    if(this._subMenu.length>0){
      let subMenus = Utility.innerJoin(this.lstSubMenus,this._subMenu,'id','id');
    this.formAddMapping.get("selectSubMenu")?.setValue(subMenus);
    }
  }
  
  addMappingPopUp() {
    this.addPopUp = true;
    this.isAddEditOnly=true;
    this.isAddOnly=true;
    this.isEditOnly=false;
  }
  addMapping() {
    debugger;
    this.isAddFormSubmitted = true;

    let userTypeIds = this.formAddMapping.get('selectUserType')?.value;
    if (userTypeIds.length <= 0) {
      return;
    }

    let mainMenus: any[] = this.formAddMapping.get('selectMainMenu')?.value;
    if (mainMenus.length <= 0) {
      return;
    }
    let filteredSubMenus: any[] = []
    let filteredMainMenus: any[] = []
    let subMenus = this.formAddMapping.get('selectSubMenu')?.value;
    if (subMenus.length > 0) {
      filteredSubMenus = this.lstSubMenus.filter(item =>
        subMenus.some((x: any) =>
          x.id == item.id)).map((item) => ({
            parentId: item.parentId,
            id: item.id
          })
          );

      let subMenuMainMenuIds = filteredSubMenus.map(item => item.parentId);
      filteredMainMenus = mainMenus.filter(menu => !subMenuMainMenuIds.includes(menu.id))
        .map((item) => ({ parentId: item.id }));
    } else {
      filteredMainMenus = mainMenus.map((item) => ({ parentId: item.id }));
    }

    let inputs: any = [];
    userTypeIds.forEach((item:any) => {
      inputs.push({
        "userTypeId": item.id,
        "mainMenu": filteredMainMenus,
        "subMenus": filteredSubMenus,
      });
    });

    if (this.formAddMapping.valid) {
      this.userRoleMappingService.createUserPermissionMapping(inputs).subscribe(
        (response) => {
          console.log('Menu assigned successfully.', response);
          this.alert.success("Success", "Menu assigned successfully.");
          this.addPopUp = false;
          this.reset();
          this.fillUserMenuPermissionList('');
        },
        (error) => {
          this.alert.error("Failed", error.message);
        }
      );
    } else {
      this.alert.warn('InValid Inputs', "Please enter valid inputs.")
      Utility.focusOnInvalidFormControl(this.formAddMapping, this.elementref);
    }
  }
  cancel() {
    this.reset();
    this.addPopUp = false;
  }
  cancelView(){
    this.viewPopUp=false;
  }
  reset() {
    this.formAddMapping.get("selectUserType")?.setValue('');
    this.formAddMapping.get("selectMainMenu")?.setValue('');
    this.lstSubMenus = [];
    this.formAddMapping.get("selectSubMenu")?.setValue('');
    this.initializeAddNewMappingForm();
    this.isAddEditOnly=true;
    this.formAddMapping.reset();
  }
  revokeMapping() {
    debugger;
    let userTypeIds = this.formAddMapping.get('selectUserType')?.value;
    if (userTypeIds.length <= 0) {
      this.alert.warn("InValid Inputs", "No user selected.");
      return;
    }
    
    let inputs: any = [];
    userTypeIds.forEach((item:any) => {
      inputs.push({
        "userTypeId": item.id
      });
    });

    this.userRoleMappingService.revokeUserPermissionMapping(inputs).subscribe(
      (response) => {
        console.log('User Permission Mapping Revoked Successfully.', response);
        this.alert.success("Success", "Permission Revoked Successfully.");
        this.addPopUp = false;
        this.reset();
        this.fillUserMenuPermissionList('');
      },
      (error) => {
        // this.alert.error("Failed", error.message);
        this.alert.error("Failed", error.message);
      }
    );
  }
  searchTextMappingList() {
    let searchText = this.frmTextSearch.get('txtSearch')?.value;
    this.fillUserMenuPermissionList(searchText);
  }
  viewMapping(selectedVal: any) {
    this.viewPopUp = true;
    this.lstUserPermissionsSingle = this.lstUserPermissionsView.filter(item=>item.roleId==selectedVal.roleId);
  }
  editMapping(selectedVal: any) {
    this.addPopUp = true;
    this.isAddOnly=false;
    this.isEditOnly=true;
    this.headerName='Edit Mapping';
    let filterType = this.lstUserType.filter(item=>item.id==selectedVal.roleId);
    this.formAddMapping.get("selectUserType")?.setValue(filterType);

    let _mainMenu = this.lstMainMenus.filter(item => selectedVal.userMenuPermission.some((x: any) => x.mainMenuId == item.id));
    this.formAddMapping.get("selectMainMenu")?.setValue(_mainMenu);

    this.fillSubMenus();
    setTimeout(() => {
      this._subMenu = this.lstSubMenus.filter(item => selectedVal.userMenuPermission.some((x: any) => x.subMenuId == item.id));
      this.formAddMapping.get("selectSubMenu")?.setValue(this._subMenu);
      this.isAddEditOnly=true;
    }, 100);

  }
  deleteMapping(selectedVal: any) {

  }
}