import { Component, ElementRef, ViewChild } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
import { DataPersistanceService } from '../../../../../../core/services/data-persistance.service';
import { AnnouncementService } from '../../services/announcement.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { ProjectScheduleService } from '../../../featureone/services/project-schedule.service';
import { Announcement } from '../../models/announcements-view.models';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { AlertService } from '../../../../../../core/ui-services/alert.service';
import { SpinnerService } from '../../../../../../core/ui-services/spinner.service';
import { Utility } from '../../../../../../core/utility/utility';
import { FileUpload } from 'primeng/fileupload';
import { Table } from 'primeng/table';

@Component({
  selector: 'retail-toolbox',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule, AutoCompleteModule],
  templateUrl: './toolbox.component.html',
  styleUrl: './toolbox.component.scss',
  providers: [AnnouncementService, ProjectScheduleService, DatePipe]
})
export class ToolboxComponent {
  visible: boolean = false;
  display: boolean = false;
  show: boolean = false;
  view: boolean = false;
  views: boolean = false;
  add: boolean = false;
  edit: boolean = false;
  deletepop: boolean = false;
  delegates: boolean = false;
  isPreAddFormSubmitted: boolean = false;
  isAddFormSubmitted: boolean = false;
  isEditFormSubmitted: boolean = false;
  isMsgEditFormSubmitted: boolean = true;
  isAddFormDocUpload: boolean = false;
  isDocUploaded: boolean = true;
  isValidDate: boolean = true;
  loading: boolean = true;
  selecctAccessTo:string='';

  prdVisible: boolean = false;
  subPrdVisible: boolean = false;
  brandVisible: boolean = false;

  announcementId: string = '';
  docDescription: string = '';

  selectIBrandLabel: string = '';
  selectIProductTypeLabel: string = '';
  selectISubProductTypeLabel: string = '';
  mainHeaderLabel: string = '';

  lstAnnouncementListView: Array<any> = [];
  lstBrand: Array<any> = [];
  lstProductType: Array<any> = [];
  lstSubProductType: Array<any> = [];
  lstMainHeder: Array<any> = [];
  lstAccessTo: Array<any> = [];
  lstOwnersTo: Array<any> = [];

  viewAnnouncememt: any = {};
  lstLineitemDocs: Array<any> = [];

  files: any = [];
  totalSize: number = 0;
  totalSizePercent: number = 0;

  searchText: string = "";
  minDate: Date;

  constructor(
    private dataPersistenceService: DataPersistanceService
    , private announcementService: AnnouncementService
    , private projectScheduleService: ProjectScheduleService
    , private messageService: MessageService
    , private config: PrimeNGConfig
    , private alert: AlertService
    , private spinner: SpinnerService
    , private formBuilder: FormBuilder
    , private elementref: ElementRef
    , private datePipe: DatePipe
  ) {
    this.minDate = new Date();
  }

  formAddNewAnnouncememt: FormGroup = new FormGroup({
    selectIBrand: new FormControl(''),
    selectIProductType: new FormControl(''),
    selectISubProductType: new FormControl(''),
    selectMainHeader: new FormControl(''),
    txtTitle: new FormControl(''),
    txtMessage: new FormControl(''),
    selectAccessTo: new FormControl(''),
    selectOwners: new FormControl(''),
    txtStartDate: new FormControl(''),
    txtEndDate: new FormControl(''),
  });
  formEditNewAnnouncememt: FormGroup = new FormGroup({
    hdnAnnouncementId: new FormControl(''),
    hdnbrandId: new FormControl(''),
    hdnproductFamilyID: new FormControl(''),
    hdnsubProductTypeId: new FormControl(''),
    txtTitle: new FormControl(''),
    txtMessage: new FormControl(''),
    selectAccessTo: new FormControl(''),
    selectOwners: new FormControl(''),
    txtStartDate: new FormControl(''),
    txtEndDate: new FormControl(''),
  });
  uploadDocForm: FormGroup = new FormGroup({
    hdnDocUploadAnnouncementId: new FormControl(''),
    uploadDocumentDescription: new FormControl(''),
  });
  formDeleteNewAnnouncememt: FormGroup = new FormGroup({
    hdnAnnouncementId: new FormControl(''),
  });
  listDocForm: FormGroup = new FormGroup({
    lineItemViewDoc: new FormControl(''),
  });
  frmTextSearch: FormGroup = new FormGroup({
    txtSearch: new FormControl(''),
  });

  ngOnInit() {
    this.initializeAddNewAnnouncememtForm();
    this.initializeUploadDocForm();
    this.initializeEditAnnouncememtForm();
    this.fillMainHeaders();
    this.fillAnnouncementList(this.searchText);
    this.loading = false;
    this.fillBrands();
    this.fillProductFamily();
    this.fillUserTypes();
  }
  private initializeAddNewAnnouncememtForm() {
    this.formAddNewAnnouncememt = this.formBuilder.group({
      selectMainHeader: ['', [Validators.required]],
      selectIProductType: ['', [Validators.required]],
      selectISubProductType: ['', [Validators.required]],
      selectIBrand: ['', [Validators.required]],
      txtTitle: [
        '',
        {
          validators: [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(100),
            Validators.pattern('^[^\\s]+(\\s+[^\\s]+)*$')
          ],
          updateOn: 'blur',
        },
      ],
      txtMessage: ['', [Validators.required]],
      selectAccessTo: ['', [Validators.required]],
      selectOwners: ['', [Validators.required]],
      txtStartDate: ['', [Validators.required]],
      txtEndDate: ['', [Validators.required]],
    });
  }
  private initializeUploadDocForm() {
    this.uploadDocForm = this.formBuilder.group({
      hdnDocUploadAnnouncementId: ['', [Validators.required]],
      uploadDocumentDescription: ['', [Validators.required]],
    });
  }
  private initializeEditAnnouncememtForm() {
    this.formEditNewAnnouncememt = this.formBuilder.group({
      hdnAnnouncementId: ['', [Validators.required]],
      hdnproductFamilyID: ['', [Validators.required]],
      hdnsubProductTypeId: ['', [Validators.required]],
      hdnbrandId: ['', [Validators.required]],
      txtTitle: [
        '',
        {
          validators: [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(100),
            Validators.pattern('^[^\\s]+(\\s+[^\\s]+)*$')
          ],
          updateOn: 'blur',
        },
      ],
      txtMessage: ['', [Validators.required]],
      selectAccessTo: ['', [Validators.required]],
      selectOwners: ['', [Validators.required]],
      txtStartDate: ['', [Validators.required]],
      txtEndDate: ['', [Validators.required]],
    });
  }
  fillAnnouncementList(seachText: string) {
    let userId = this.dataPersistenceService.userGuid;

    this.announcementService.getAnnouncementList(userId, seachText).subscribe((models) => {
      if (models == null) { this.lstAnnouncementListView = []; } else {
        this.lstAnnouncementListView = models.map((model) => {
          return {
            id: model.id,
            sNo: model.sNo,
            subProductTypeId: model.subProductTypeId,
            subProductTypeName: model.subProductTypeName,
            productFamilyID: model.productFamilyID,
            productFamilyName: model.productFamilyName,
            brandId: model.brandId,
            brandName: model.brandName,
            mainHeaderId: model.mainHeaderId,
            headerText: model.headerText,
            title: model.title,
            message: model.message,
            startDate: this.datePipe.transform(model.startDate, 'yyyy-MM-dd'),
            endDate: this.datePipe.transform(model.endDate, 'yyyy-MM-dd'),
            isActive: model.isActive,
            createdBy: model.createdBy,
            createdDate: model.createdDate,
            createdByUserName: model.createdByUserName,
            modifiedBy: model.modifiedBy,
            modifiedDate: model.modifiedDate,
            modifiedByUserName: model.modifiedByUserName,
            announcementDocuments: model.announcementDocuments,
            announcementAssignTos: model.announcementAssignTos,
            announcementOwners: model.announcementOwners,
            assignTo: model.assignTo,
            owners: model.owners
          };
        });
      }
    });
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
  fillProductFamily() {
    this.projectScheduleService.getProductFamily().subscribe((prodFamily) => {
      this.lstProductType = prodFamily.map((prodF) => {
        return {
          id: prodF.id, name: prodF.productName
          , subProductTypeList: prodF.subProductTypeList
        };
      });
    });
  }
  fillSubProducTypes(selectedProdF: any) {
    debugger;
    this.formAddNewAnnouncememt.get("selectISubProductType")?.setValue('');
    if (selectedProdF != "") {
      this.lstSubProductType = this.lstProductType.filter(item => {
        return item.id.includes(selectedProdF.id);
      })[0].subProductTypeList.map((subP: any) => {
        return {
          name: subP.subProductTypeName, id: subP.id
        };
      });
    }
  }
  fillUserTypes() {
    this.announcementService.getUsertype().subscribe((models) => {
      this.lstAccessTo = models.map((model) => {
        return {
          id: model.id
          , name: model.userTypeName
        };
      });
    });
  }
  fillMainHeaders() {
    this.announcementService.getMainHeaders().subscribe((models) => {
      this.lstMainHeder = models.map((model) => {
        return {
          id: model.id
          , name: model.headerText
        };
      });
    });
  }
  fillAnnouncementDocs(id: string) {
    this.announcementService.getAnnouncementDocuments(id).subscribe((models) => {

      if(models==null){this.lstLineitemDocs=[];}else
{
      this.lstLineitemDocs = models.map((model) => {
        return {
          id: model.id, docName: model.docName
          , description: model.description, uploadedByName: model.uploadedByName
          , createdDate: model.createdDate
        };
      });
    }
    });
    
  }
  advance() {
    this.visible = true;
  }
  restore() {
    this.display = true;
  }
  onUpload() {
    this.show = true;
  }
  history(objAnnouncement: any) {
    this.view = true;
    this.viewAnnouncememt = objAnnouncement;
    this.listDocForm.get("lineItemViewDoc")?.setValue(objAnnouncement.id);
  }
  details() {
    this.views = true;
  }
  delegate() {
    this.delegates = true;
  }
  edit_details(objAnnouncement: any) {
    this.initializeEditAnnouncememtForm();
    this.isMsgEditFormSubmitted=true;
    this.display = true;
    this.viewAnnouncememt = objAnnouncement;
    this.listDocForm.get("lineItemViewDoc")?.setValue(objAnnouncement.id);
    this.formEditNewAnnouncememt.get("hdnAnnouncementId")?.setValue(objAnnouncement.id);
    this.formEditNewAnnouncememt.get("hdnbrandId")?.setValue(objAnnouncement.brandId);
    this.formEditNewAnnouncememt.get("hdnproductFamilyID")?.setValue(objAnnouncement.productFamilyID);
    this.formEditNewAnnouncememt.get("hdnsubProductTypeId")?.setValue(objAnnouncement.subProductTypeId);

    this.uploadDocForm.get("hdnDocUploadAnnouncementId")?.setValue(objAnnouncement.id);

    this.display = false;
    this.edit = true;

    this.selectIBrandLabel = objAnnouncement.brandName;
    this.selectIProductTypeLabel = objAnnouncement.productFamilyName;
    this.selectISubProductTypeLabel = objAnnouncement.subProductTypeName;
    this.mainHeaderLabel = objAnnouncement.headerText;


    this.lstOwnersTo = this.lstAccessTo;

    this.formEditNewAnnouncememt.get("selectMainHeader")?.setValue(objAnnouncement.mainHeaderId);
    this.formEditNewAnnouncememt.get("txtTitle")?.setValue(objAnnouncement.title);

    // this.formEditNewAnnouncememt.patchValue({ txtMessage: objAnnouncement.message });
    // this.editMessage = "Hello editor";
    // this.formAddNewAnnouncememt.get("txtMessage")?.setValue("Hello editor");

    setTimeout(() => {
      this.formEditNewAnnouncememt.get("txtMessage")?.setValue(objAnnouncement.message);
    }, 300);

    const formattedStartDate = new Date(objAnnouncement.startDate);
    this.formEditNewAnnouncememt.controls["txtStartDate"].setValue(formattedStartDate);
    const formattedEndDate = new Date(objAnnouncement.endDate);
    this.formEditNewAnnouncememt.get("txtEndDate")?.setValue(formattedEndDate);
    this.lstLineitemDocs = objAnnouncement.announcementDocuments;

    let selectedAccessTo = this.lstAccessTo.filter(item => objAnnouncement.announcementAssignTos.some((x: any) => x.userTypeId == item.id));
    this.formEditNewAnnouncememt.get("selectAccessTo")?.setValue(selectedAccessTo);

    let selectedOwners = this.lstAccessTo.filter(item => objAnnouncement.announcementOwners.some((x: any) => x.userTypeId == item.id));
    this.formEditNewAnnouncememt.get("selectOwners")?.setValue(selectedOwners);


  }
  cancel() {
    this.display = false;
    this.clearControl();
  }
  cancelAnnouncememt() {
    this.display = false;
    this.add = false;
    this.clearControl();
  }
  cancelEditAnnouncememt() {
    this.edit = false;
    this.clearControl();
  }

  // delete
  deletePop(id: string) {
    this.deletepop = true;
    this.formDeleteNewAnnouncememt.get("hdnAnnouncementId")?.setValue(id);
  }
  closeDeletePopup() {
    this.deletepop = false;
  }
  nextAddAnnouncememt() {
    this.isPreAddFormSubmitted = true;
    let mainHeader = this.formAddNewAnnouncememt.get('selectMainHeader')?.value;
    let brand = this.formAddNewAnnouncememt.get('selectIBrand')?.value;
    let productType = this.formAddNewAnnouncememt.get('selectIProductType')?.value;
    let subProductType = this.formAddNewAnnouncememt.get('selectISubProductType')?.value;

    if (mainHeader == null || mainHeader == "") {
      return;
    }
    if (mainHeader.id != "876412F2-6BCB-43F8-AEC6-3EC2A746EB65".toLowerCase()) {
      if (productType == null || productType == "") {
        return;
      }
      if (subProductType == null || subProductType == "") {
        return;
      }
      if (brand == null || brand == "") {
        return;
      }
    }
    this.add = true;
    this.selectIBrandLabel = brand.name;
    this.mainHeaderLabel = mainHeader.name;
    this.selectIProductTypeLabel = productType.name;
    this.selectISubProductTypeLabel = subProductType.name;

    this.lstOwnersTo = this.lstAccessTo;

  }
  addNewAnnouncememt() {
    debugger;
    this.isAddFormSubmitted = true;
    let _brandId = this.formAddNewAnnouncememt.get('selectIBrand')?.value.id || '';
    let _productTypeId = this.formAddNewAnnouncememt.get('selectIProductType')?.value.id || '';
    let _subProductTypeId = this.formAddNewAnnouncememt.get('selectISubProductType')?.value.id || '';
    let _mainHeaderId = this.formAddNewAnnouncememt.get('selectMainHeader')?.value.id || '';
    let _title = this.formAddNewAnnouncememt.get('txtTitle')?.value || '';
    let _message = this.formAddNewAnnouncememt.get('txtMessage')?.value || '';
    let _accessToIds = this.formAddNewAnnouncememt.get('selectAccessTo')?.value.id || '';
    let seelctedOwners = this.formAddNewAnnouncememt.get('selectOwners')?.value || '';
    let seelctedAssignTo = this.formAddNewAnnouncememt.get('selectAccessTo')?.value || '';
    if (_title == null || _title == "") {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtTitle"]'
      );
      invalidControl.focus();
      return;
    }
    if(_title.length<4)
      {
        const invalidControl = this.elementref.nativeElement.querySelector(
          '[formControlName="txtTitle"]'
        );
        invalidControl.focus();
  return;
      }
    if(_title.length>100)
    {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtTitle"]'
      );
      invalidControl.focus();
return;
    }
    if (_message == null || _message == "" || _message == "<p></p>") {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtMessage"]'
      );
      invalidControl.focus();
      return;
    }
    if (seelctedAssignTo == null || seelctedAssignTo == "") {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="selectAccessTo"]'
      );
      invalidControl.focus();
      return;
    }
    if (seelctedOwners == null || seelctedOwners == "") {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="selectOwners"]'
      );
      invalidControl.focus();
      return;
    }

    let _ownersIds: Array<string> = [];
    if (seelctedOwners.length > 0) {
      seelctedOwners.forEach((user: { id: string }) => {
        _ownersIds.push(user.id);
      });
    }

    let _assignToIds: Array<string> = [];

    if (seelctedAssignTo.length > 0) {
      seelctedAssignTo.forEach((user: { id: string }) => {
        _assignToIds.push(user.id);
      });
    }

    let _startDate = '';
    let _endDate = '';
    if (this.formAddNewAnnouncememt.get('txtStartDate')?.value != '') {
      let startDate: Date = new Date(this.formAddNewAnnouncememt.get('txtStartDate')?.value);
      let formattedDate: string = startDate.toISOString();
      _startDate = formattedDate;
    } else {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtStartDate"]'
      );
      invalidControl.focus();
      return;
    }

    if (this.formAddNewAnnouncememt.get('txtEndDate')?.value != '') {
      let endDate: Date = new Date(this.formAddNewAnnouncememt.get('txtEndDate')?.value);
      let formattedDate: string = endDate.toISOString();
      _endDate = formattedDate;
    } else {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtEndDate"]'
      );
      invalidControl.focus();
      return;
    }
    if (_startDate != '' && _endDate != '') {
      if (_startDate > _endDate) {
        this.isValidDate = false;
        const invalidControl = this.elementref.nativeElement.querySelector(
          '[formControlName="txtEndDate"]'
        );
        invalidControl.focus();
        return;
      } else {
        this.isValidDate = true;
      }
    }

    let description = this.docDescription;

    let announcement: Announcement = new Announcement();
    (announcement.brandId = _brandId),
      (announcement.subProductTypeId = _subProductTypeId),
      (announcement.mainHeaderId = _mainHeaderId),
      (announcement.title = _title),
      (announcement.message = _message),
      (announcement.startDate = _startDate),
      (announcement.endDate = _endDate),
      (announcement.createdBy = this.dataPersistenceService.userGuid),
      (announcement.description = description);

    this.announcementService.createAnnouncement(announcement, _ownersIds, _assignToIds, this.files)
      .subscribe((response) => {
        this.alert.success('Success',"Announcement created successfully.")
        this.display = false;
        this.add = false;
        this.fillAnnouncementList(this.searchText);
        this.clearControl();
        return response;
      },
      (error) => {
        if(error.statusCode==300){
          this.alert.warn('Warning',error.message);
        }
        else{this.alert.error('Failed',error.message)
          Utility.focusOnInvalidFormControl(this.formAddNewAnnouncememt,this.elementref);
        }
      });
    
  }
  deleteAnnouncememt() {
    let selectedId: string = '';
    selectedId = this.formDeleteNewAnnouncememt.get('hdnAnnouncementId')?.value;
    if (selectedId == "" || selectedId == null || selectedId == undefined) {
      this.alert.warn('Invalid Inputs', 'There is not row selected.');
      return;
    }
    this.announcementService.deleteAnnouncement(selectedId)
      .subscribe((response) => {
        this.alert.success('Success','Announcement deleted successfully.')
        this.deletepop = false;
        return response;
      });
    window.location.reload();
  }
  onTemplatedUpload() {
    this.messageService.add({ severity: 'info', summary: 'Success', detail: 'File Uploaded', life: 3000 });
  }
  onSelectedFiles(event: any) {
    this.files = event.currentFiles;
    this.files.forEach((file: any) => {
      this.totalSize += parseInt(this.formatSize(file.size));
    });
    this.totalSizePercent = this.totalSize / 10;
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
  choose(event: any, callback: any) {
    callback();
  }
  onRemoveTemplatingFile(event: any, file: any, removeFileCallback: any, index: any) {
    removeFileCallback(event, index);
    this.totalSize -= parseInt(this.formatSize(file.size));
    this.totalSizePercent = this.totalSize / 10;
  }
  uploadDocuments() {
    debugger;
    this.isAddFormDocUpload = true;

    let announcementId = this.uploadDocForm.get('hdnDocUploadAnnouncementId')?.value;

    if ((announcementId == '' || announcementId == null)
      && this.files.length > 0
    ) {
      this.isDocUploaded=true;
      if(this.uploadDocForm.get('uploadDocumentDescription')?.value.trim() =='')
      {
       this.alert.warn("Invalid Inputs","Please enter valid description.")
       const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="uploadDocumentDescription"]'
      );
      invalidControl.focus();
        return;
      }
      this.show = false;
      return;
    }

    if(this.uploadDocForm.get('uploadDocumentDescription')?.value.trim() =='')
      {
       this.alert.warn("Invalid Inputs","Please enter valid description.")
       const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="uploadDocumentDescription"]'
      );
      invalidControl.focus();
        return;
      }

    this.docDescription = this.uploadDocForm.get('uploadDocumentDescription')?.value;
    let userGuid = this.dataPersistenceService.userGuid;
    if (this.files.length <= 0) {
      this.isDocUploaded = false;
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="uploadDocumentDescription"]'
      );
      invalidControl.focus();
      return;
    }else{this.isDocUploaded = true;}

    if(this.uploadDocForm.valid){
    this.announcementService.uploadAnnouncememtDocs(announcementId, this.docDescription, userGuid, this.files).subscribe(
      (response) => {
        this.alert.success('Success','Document uploaded successfully.')
        this.fillAnnouncementDocs(announcementId);

        //this.uploadDocForm.get("hdnDocUploadAnnouncementId")?.setValue('');
        this.uploadDocForm.get("uploadDocumentDescription")?.setValue('');
        this.files = [];
        this.totalSize = 0;
        this.totalSizePercent = 0;
      },
      (error) => {
        Utility.focusOnInvalidFormControl(this.uploadDocForm,this.elementref);
        console.error('Upload failed', error);
      }
    );

    this.show = false;
  }
  }
  cancelUploadDoc() {
    this.show = false;
    this.uploadDocForm.get("uploadDocumentDescription")?.setValue('');

    this.files = [];
    this.totalSize = 0;
    this.totalSizePercent = 0;

    this.uploadDocForm = this.formBuilder.group({
      uploadDocumentDescription: ['', [Validators.required]],
    });
  }
  selectAllDocs(){
    this.lstLineitemDocs.forEach(element => {
      element.isSelected=true;
    });
    let id = this.listDocForm.get("lineItemViewDoc")?.value||'';
  }
  headerChange(element: any) {
    if (element != "") {
      if (element.id.toUpperCase() == "876412F2-6BCB-43F8-AEC6-3EC2A746EB65") {
        this.prdVisible = true;
        this.subPrdVisible = true;
        this.brandVisible = true;
      }
      else {
        this.prdVisible = false;
        this.subPrdVisible = false;
        this.brandVisible = false;
      }
    } else {
      this.prdVisible = false;
      this.subPrdVisible = false;
      this.brandVisible = false;
    }
  }
  clearControl() {
    this.formAddNewAnnouncememt.get("selectIBrand")?.setValue('');
    this.formAddNewAnnouncememt.get("selectIProductType")?.setValue('');
    this.formAddNewAnnouncememt.get("selectISubProductType")?.setValue('');
    this.formAddNewAnnouncememt.get("selectMainHeader")?.setValue('');
    this.formAddNewAnnouncememt.get("txtTitle")?.setValue('');
    this.formAddNewAnnouncememt.get("txtMessage")?.setValue('');
    this.formAddNewAnnouncememt.get("selectAccessTo")?.setValue('');
    this.formAddNewAnnouncememt.get("selectOwners")?.setValue('');
    this.formAddNewAnnouncememt.get("txtStartDate")?.setValue('');
    this.formAddNewAnnouncememt.get("txtEndDate")?.setValue('');

    this.formEditNewAnnouncememt.get("hdnAnnouncementId")?.setValue('');
    this.formEditNewAnnouncememt.get("hdnbrandId")?.setValue('');
    this.formEditNewAnnouncememt.get("hdnproductFamilyID")?.setValue('');
    this.formEditNewAnnouncememt.get("hdnsubProductTypeId")?.setValue('');
    this.formEditNewAnnouncememt.get("hdnMainHeader")?.setValue('');
    this.formEditNewAnnouncememt.get("txtTitle")?.setValue('');
    this.formEditNewAnnouncememt.get("txtMessage")?.setValue('');
    this.formEditNewAnnouncememt.get("selectAccessTo")?.setValue('');
    this.formEditNewAnnouncememt.get("selectOwners")?.setValue('');
    this.formEditNewAnnouncememt.get("txtStartDate")?.setValue('');
    this.formEditNewAnnouncememt.get("txtEndDate")?.setValue('');

    this.uploadDocForm.get("hdnDocUploadAnnouncementId")?.setValue('');
    this.uploadDocForm.get("uploadDocumentDescription")?.setValue('');

    this.formDeleteNewAnnouncememt.get("hdnAnnouncementId")?.setValue('');
    this.files = [];
    this.totalSize = 0;
    this.totalSizePercent = 0;

    this.isPreAddFormSubmitted = false;
    this.isAddFormSubmitted = false;
    this.isEditFormSubmitted = false;
    this.isAddFormDocUpload = false;
    this.isDocUploaded = false;
    this.isValidDate = true;

    this.prdVisible = false;
    this.subPrdVisible = false;
    this.brandVisible = false;

    this.initializeAddNewAnnouncememtForm();
  }
  documentList: boolean = false;

  onEditViewUpload() {
    this.documentList = true;
    this.initializeUploadDocForm();
    let id = this.formEditNewAnnouncememt.get('hdnAnnouncementId')?.value;
    this.listDocForm.get("lineItemViewDoc")?.setValue(id);
  }
  deleteDocuments() {
    let id = this.listDocForm.get('lineItemViewDoc')?.value;

    const selectedRows = this.lstLineitemDocs.filter(item => item.isSelected);
    if (selectedRows.length <= 0) {
      return;
    }

    this.spinner.show();
    let documentIds: Array<string> = [];
    if (selectedRows.length > 0) {
      selectedRows.forEach((doc: { id: string }) => {
        documentIds.push(doc.id);
      });
    }
    if (this.listDocForm.valid) {
      this.announcementService
        .deleteAnnouncememtDocs(documentIds)
        .subscribe((scheduleCreated) => {
          this.spinner.hide();
          this.alert.success('Success', 'Documents deleted successfully.');

          this.fillAnnouncementDocs(id);
        });
    } else {
      this.spinner.hide();
      this.alert.warn('Invalid Inputs', 'Unable to delete documents');
    }
    this.spinner.hide();

    // this.documentList = false;
  }
  openDocUploadListPopUp() {
    this.show = true;
    let id = this.listDocForm.get('lineItemViewDoc')?.value;
    this.uploadDocForm.get("hdnDocUploadAnnouncementId")?.setValue(id);
  }
  setSelectLineItem(selectedItem: any) {
    selectedItem.isSelected = !selectedItem.isSelected;
  }
  editAnnouncememt() {
    this.isEditFormSubmitted = true;
    let _announcementId = this.formEditNewAnnouncememt.get('hdnAnnouncementId')?.value;
    let _title = this.formEditNewAnnouncememt.get('txtTitle')?.value || '';
    let _message = this.formEditNewAnnouncememt.get('txtMessage')?.value || '';
    let seelctedOwners = this.formEditNewAnnouncememt.get('selectOwners')?.value || '';
    let seelctedAssignTo = this.formEditNewAnnouncememt.get('selectAccessTo')?.value || '';

    if (_title == null || _title == "") {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtTitle"]'
      );
      invalidControl.focus();
      return;
    }
    if(_message == "<p></p>")
    {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtMessage"]'
      );
      invalidControl.focus();
      _message = "";
    }
    if (_message == null || _message == "" ) {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtMessage"]'
      );
      invalidControl.focus();
      this.isMsgEditFormSubmitted = false;
      return;
    }
    if (seelctedAssignTo == null || seelctedAssignTo == "") {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="selectAccessTo"]'
      );
      invalidControl.focus();
      return;
    }
    if (seelctedOwners == null || seelctedOwners == "") {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="selectOwners"]'
      );
      invalidControl.focus();
      return;
    }

    let _ownersIds: Array<string> = [];
    if (seelctedOwners.length > 0) {
      seelctedOwners.forEach((user: { id: string }) => {
        _ownersIds.push(user.id);
      });
    }

    let _assignToIds: Array<string> = [];

    if (seelctedAssignTo.length > 0) {
      seelctedAssignTo.forEach((user: { id: string }) => {
        _assignToIds.push(user.id);
      });
    }

    let _startDate = '';
    let _endDate = '';
    if (this.formEditNewAnnouncememt.get('txtStartDate')?.value != '') {
      let startDate: Date = new Date(this.formEditNewAnnouncememt.get('txtStartDate')?.value);
      let formattedDate: string = startDate.toISOString();
      _startDate = formattedDate;
    } else {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtStartDate"]'
      );
      invalidControl.focus();
      return;
    }

    if (this.formEditNewAnnouncememt.get('txtEndDate')?.value != '') {
      let endDate: Date = new Date(this.formEditNewAnnouncememt.get('txtEndDate')?.value);
      let formattedDate: string = endDate.toISOString();
      _endDate = formattedDate;
    } else {
      const invalidControl = this.elementref.nativeElement.querySelector(
        '[formControlName="txtEndDate"]'
      );
      invalidControl.focus();
      return;
    }

    if (_startDate != '' && _endDate != '') {
      if (_startDate > _endDate) {
        this.isValidDate = false;
        return;
      } else {
        const invalidControl = this.elementref.nativeElement.querySelector(
          '[formControlName="txtEndDate"]'
        );
        invalidControl.focus();
        this.isValidDate = true;
      }
    }

    let announcement: Announcement = new Announcement();
    (announcement.id = _announcementId),
      (announcement.title = _title),
      (announcement.message = _message),
      (announcement.startDate = _startDate),
      (announcement.endDate = _endDate),
      (announcement.createdBy = this.dataPersistenceService.userGuid);
    // (announcement.assignTo= _assignToIds),
    // (announcement.ownersIds= _ownersIds);

    debugger;
    if(this.formEditNewAnnouncememt.valid){
    this.announcementService.editAnnouncement(announcement, _ownersIds, _assignToIds)
      .subscribe((response) => {
        this.alert.success('Success','Announcement updated successfully.')
        this.edit = false;
        this.fillAnnouncementList(this.searchText);
        this.clearControl();
        return response;
      });
    }else{
      Utility.focusOnInvalidFormControl(this.formEditNewAnnouncememt, this.elementref);
      this.alert.warn('Invalid Inputs','Please enter valid inputs.')
    }
  }
  downloadDocuments(fileName: string) {
    let id = this.listDocForm.get('lineItemViewDoc')?.value;
    this.announcementService.downloadDocuments(id, fileName).subscribe(
      (response) => {
        this.alert.success("Success", "File downloaded successfully");
      },
      (error) => {
        console.error('Downloaded failed', error);
      }
    );
  }
  searchTextAnnouncementList() {
    let searchText = this.frmTextSearch.get('txtSearch')?.value;
    this.fillAnnouncementList(searchText);
  }
  clear(table: Table) {
    table.clear();
    this.searchText = ''
}

}