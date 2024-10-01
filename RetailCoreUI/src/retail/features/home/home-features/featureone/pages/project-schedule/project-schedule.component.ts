import { Component, inject, TemplateRef, ViewChild, AfterViewInit, DebugElement, NgZone, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
import { FormControl, FormGroup } from '@angular/forms';
import { ProjectScheduleService } from '../../services/project-schedule.service';
import { CommonModule } from '@angular/common';
import { Product } from '../../models/product.models';																									   
import { DeletLineItemDoc, IScheduleView, ScheduleAction } from '../../models/project-Action.models';
import { ProjectSchedule } from '../../models/project-Schedule.model';
import { DataPersistanceService } from '../../../../../../core/services/data-persistance.service';
import { LoggerService } from '../../../../../../core/services/logger.service';
import { AlertService } from '../../../../../../core/ui-services/alert.service';
import { SpinnerService } from '../../../../../../core/ui-services/spinner.service';
import { ProjectScheduleLineitem } from '../../models/project-schedule-lineitem';
import { empty } from 'rxjs';
import { ConfiguratorComponent } from '../../../../components/configurator/configurator.component';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { DropdownChangeEvent } from 'primeng/dropdown'	
import { CPQ_service } from '../../services/CPQ/CPQ.Service';												   
import { ConfirmDialogService } from '../../../../../../core/ui-services/confirm-dialog.service';
declare var kbmax: any;					   

@Component({
  selector: 'retail-project-schedule',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './project-schedule.component.html',
  styleUrl: './project-schedule.component.scss',
  providers: [ProjectScheduleService, CPQ_service]

})
export class ProjectScheduleComponent implements OnInit, AfterViewInit{
  cpqEmbedconfig: any;
  selectedProduct: any;
  selectedAddedProduct: any;						
  modelState: boolean = true;
  unitEState: boolean = false;
  unitNState: boolean = false;
  actionProjectState: boolean = false;
  actionScheduleState: boolean = false;
  actionQuoteTypeState: boolean = true;
  actionQuoteState: boolean = true;
  actionQuoteMulState: boolean = true;
  buttonLabel: string = 'Copy';
  projectId: string = '';
  activeScheduleId : string = '';
  activeProjectId : string = '';
  //cpqService : CPQ_service = new CPQ_service();

  lstProjectAction: Array<any> = [];
  lstProjectQuoteTypes: Array<any> = [];
  lstProdFamily: Array<any> = [];
  lstCPQProducts: Array<any> = [];
  lstKCCUnits: Array<any> = [];
  lstKCCModels: Array<any> = [];
  lstProjectInfo: Array<any> = [];
  lstProjectSchedule: Array<any> = [];
  lstProjectLoadSchedule: Array<any> = [];
  lstLineitemDocs: Array<any> = [];

  lstProjectScheduleListView: Array<any> = [];
  lstProjectScheduleListViewAdopter: Array<any> = [];
  lstProjectScheduleListViewNAdopter: Array<any> = [];

  scheduleActionForm: FormGroup;
  addScheduleForm: FormGroup;
  editScheduleForm: FormGroup;
  loadScheduleUpdateForm: FormGroup;
  uploadDocForm: FormGroup;
  listDocForm: FormGroup;

  scheduleAddComplete: boolean = false;
  isFormVisible: boolean = false;

  visible: boolean = false;
  display: boolean = false;
  checked: boolean = true;
  collapse: boolean = true;
  uploadDoc: boolean = false;
  documentList:boolean = false;

  configureProductDialog:boolean=false;
  reConfigureProduct:boolean=false;

  constructor(private ngZone: NgZone, private alertService: AlertService, 
    private route: ActivatedRoute,
    private router: Router, private projectScheduleService: ProjectScheduleService
    , private dataPersistance: DataPersistanceService
    , private logger: LoggerService, private alert: AlertService, private spinner: SpinnerService,private confirmDialogService:ConfirmDialogService,
    private config: PrimeNGConfig, private messageService: MessageService, private cpqService : CPQ_service
  ) {
    this.scheduleActionForm = new FormGroup({
      selectedAction: new FormControl(''),
      selectedProject: new FormControl(''),
      selectedSchedule: new FormControl(''),
      selectedQuotation: new FormControl(''),
      selectedQuotations: new FormControl(''),
      quantity: new FormControl(),
    });
    this.addScheduleForm = new FormGroup({
      txtScheduleName: new FormControl(),
      txtDescription: new FormControl(),
      txtNotes: new FormControl(),
    });
    this.editScheduleForm = new FormGroup({
      chhkIsSchduleActive: new FormControl(),
      txtEditScheduleName: new FormControl(),
      txtEditNotes: new FormControl(),
      hdnEditId: new FormControl(),
    });
    this.loadScheduleUpdateForm = new FormGroup({
      selectLoadSchedules: new FormControl('')
    });
    this.uploadDocForm = new FormGroup ({
      lineItemUploadDoc: new FormControl(),
      uploadDocumentDescription: new FormControl(),
    });
    this.listDocForm = new FormGroup ({
      lineItemViewDoc: new FormControl(),
    });
  }

  currentTemplate: TemplateRef<any> | null = null;
  currentTemplateHeader: string = 'default header';

  ngOnInit() {
    debugger;
    this.route.queryParams
    .subscribe(params => {
      console.log(params);
      this.projectId = params['projectId'];
    }
  );

    this.fillScheduleActions();
    this.fillLoadProjectSchedule();
    this.fillProductFamily();
    this.fillQuoteTypes();
    this.fillProjectInfo();
    this.fillKCCModels();
  }
ngAfterViewInit(): void {

  }					   
  fillScheduleActions() {
    this.projectScheduleService.getProjectScheduleActionList().subscribe((models) => {
      this.lstProjectAction = models.map((model) => {
        return {
          name: model.actionName, code: model.id
        };
      });
    });
  }
  fillQuoteTypes() {
    this.projectScheduleService.getQuoteTypes().subscribe((models) => {
      this.lstProjectQuoteTypes = models.map((model) => {
        return {
          name: model.quoteTypeName, code: model.id
        };
      });
    });
  }
  fillKCCModels() {
    this.projectScheduleService.getKCCModel().subscribe((models) => {
      this.lstKCCModels = models.map((model) => {
        return {
          name: model.modelNumber, code: model.id
        };
      });
    });
  }
  //fillProductFamily() {
  //  this.projectScheduleService.getProductFamily().subscribe((prodFamily) => {
  //    this.lstProdFamily = prodFamily.map((prodF) => {
  //      return {
  //        name: prodF.productFamilyName, code: prodF.id, units: prodF.kccUnitList
  //      };
  //    });
  //  });
  //}
  fillProductFamily() {
    this.projectScheduleService.getAllCPQProducts().subscribe((prodFamily) => {
      this.lstProdFamily = prodFamily.map((prodF) => {
        return {
          name: prodF.productName, code: prodF.productId, id: prodF.id
        };
      });
    });
  }

  fillProjectInfo() {
    this.projectScheduleService.getProjectInfo().subscribe((projects) => {
      this.lstProjectInfo = projects.map((project) => {
        return {
          name: project.projectName, code: project.id
        };
      });
    });
  }
  fillProjectSchedule(selectedProject: any) {
    if (selectedProject == null) {
      this.lstProjectSchedule = [];
    } else {
      this.lstProjectSchedule = this.lstProjectLoadSchedule.filter(item => {
        return item.projectId.includes(selectedProject.code);
      }).map((schedule) => {
        return {
          name: schedule.name, code: schedule.code
        };
      });
    }
  }
  fillLoadProjectSchedule() {
    this.projectScheduleService.getProjectSchedule().subscribe((schedules) => {
      this.lstProjectLoadSchedule = schedules.map((schedule) => {
        return {
          name: schedule.scheduleName, code: schedule.id, projectId: schedule.projectId,
          desc: schedule.description, notes: schedule.notes
          , createdDate: schedule.createdDate
          , createdBy: schedule.createdBy
          , modifiedDate: schedule.modifiedDate
          , modifiedBy: schedule.modifiedBy
          , isActive: schedule.isActive
          , active: false
        };
      });
      this.lstProjectLoadSchedule[0].active = true;
      this.refreshGrid();
    });
  }
  fillProjectScheduleListView(projectId: string, schedules: Array<string>) {
    this.projectScheduleService.getProjectScheduleListView(projectId, schedules).subscribe((schedules) => {
      this.lstProjectScheduleListView = schedules.map((schedule) => {
        return {
          scheduleName: schedule.scheduleName, id: schedule.id, modelNumber: schedule.modelNumber,
          description: schedule.description, eUnitName: schedule.eUnitName, nUnitName: schedule.nUnitName,
          curbType: schedule.curbType, unitModelNumber: schedule.unitModelNumber, standardPrice: schedule.standardPrice,
          expressPrice: schedule.expressPrice, expeditedPrice: schedule.expeditedPrice, extendedPrice: schedule.extendedPrice,
          tag: schedule.tag, perfVerified: schedule.perfVerified, priceVerified: schedule.priceVerified,
          submittalReq: schedule.submittalReq, unitSize: schedule.unitSize, totalPrice: schedule.totalPrice,
          quantity: schedule.quantity, quotationID: schedule.quotationID, quoteProductID: schedule.quoteProductID, orderID: schedule.orderID,
          notes: schedule.notes, createdDate: schedule.createdDate, createdBy: schedule.createdBy,
          createdByUserName: schedule.createdByUserName, modifiedDate: schedule.modifiedDate,
          modifiedBy: schedule.modifiedBy, modifiedByUserName: schedule.modifiedByUserName
        };
      });
      this.lstProjectScheduleListViewAdopter = this.lstProjectScheduleListView.filter(item => item.curbType == "Adopter");
      this.lstProjectScheduleListViewNAdopter = this.lstProjectScheduleListView.filter(item => item.curbType != "Adopter");
    });
  }
  setActive(selectedItem: any) {
    this.lstProjectLoadSchedule.forEach(item => item.active = false);
    alert(selectedItem.code);
    selectedItem.active = true;
  }
  fillLineitemDocuments(id:string) {
    this.projectScheduleService.getLineitemDocuments(id).subscribe((models) => {
      this.lstLineitemDocs = models.map((model) => {
        return {
          id: model.id, lineItemDetailId: model.lineItemDetailId,fileName:model.fileName
          ,documentDescription:model.documentDescription,uploadedBy:model.uploadedBy
          ,uploadedByName:model.uploadedByName,uploadedOn:model.uploadedOn
        };
      });
    });
  }
  projectActionChange(selectedItem: any) {
    if (selectedItem != null) {
      if (selectedItem.code.toUpperCase() == '9829FE09-3ACF-4566-AD9C-1748E583682D') {
        this.actionProjectState = false;
        this.actionScheduleState = false;
        this.actionQuoteTypeState = true;
        this.actionQuoteState = true;
        this.actionQuoteMulState = true;
        this.buttonLabel = selectedItem.name;
      } else if (selectedItem.code.toUpperCase() == 'CA47E690-D447-4F6B-AC73-DE75005B2C8F') {
        this.actionProjectState = true;
        this.actionScheduleState = true;
        this.actionQuoteTypeState = true;
        this.actionQuoteState = true;
        this.actionQuoteMulState = true;
        this.buttonLabel = selectedItem.name;
      }
      else if (selectedItem.code.toUpperCase() == '51F91109-FE9E-41AA-9F35-292C6669A433') {
        this.actionProjectState = true;
        this.actionScheduleState = true;
        this.actionQuoteTypeState = false;
        this.actionQuoteState = false;
        this.actionQuoteMulState = true;
        this.buttonLabel = 'Create ' + selectedItem.name;
      }
      else if (selectedItem.code.toUpperCase() == 'EB2E285F-09A5-4D2D-BB22-B56981DD8CA1') {
        this.actionProjectState = true;
        this.actionScheduleState = true;
        this.actionQuoteTypeState = true;
        this.actionQuoteState = true;
        this.actionQuoteMulState = false;
        this.buttonLabel = 'Create ' + selectedItem.name;
      }
    } else {
      this.actionProjectState = false;
      this.actionScheduleState = false;
      this.actionQuoteTypeState = true;
      this.actionQuoteState = true;
      this.actionQuoteMulState = true;
      this.buttonLabel = 'Copy';
    }
  }
  actionFormSubmit() {
    debugger;
    if (this.scheduleActionForm.get('selectedAction')?.value == '') {
      this.alert.warn('Warning', 'Please select action.');
      return;
    } else {
      let action = this.scheduleActionForm.get('selectedAction')?.value.code.toUpperCase();
      if (action == '9829FE09-3ACF-4566-AD9C-1748E583682D')  //copy
      {
        if (this.scheduleActionForm.get('selectedProject')?.value == '') {
          this.alert.warn('Warning', 'Please select project.');
          return;
        }
        if (this.scheduleActionForm.get('selectedSchedule')?.value == '') {
          this.alert.warn('Warning', 'Please select schedule.');
          return;
        }
      } else if (action == 'CA47E690-D447-4F6B-AC73-DE75005B2C8F') //delete
      {
        const selectedRows = this.lstProjectScheduleListView.filter(item => item.isSelected);
        if (selectedRows.length <= 0) {
          this.alert.warn('Warning', 'Please select at least one lineitem.');
          return;
        }
      } else if (action == "51F91109-FE9E-41AA-9F35-292C6669A433") {
        //display embedded pop up Quote
        this.CreateAndSubmitUserQuote();
        return;
      } else if (action == "EB2E285F-09A5-4D2D-BB22-B56981DD8CA1") {
        //display embedded pop up Order
        alert('create orders with selected quotes');
        return;
      }
    }
    let action = this.scheduleActionForm.get('selectedAction')?.value.code.toUpperCase();

    const lineItems = this.lstProjectScheduleListView.filter(item => item.isSelected);
    if (lineItems.length <= 0) {
      this.alert.warn('Warning', 'Please select at least one lineitem.');
      return;
    }

    this.spinner.show();
    const selectedRows = lineItems
      .map((schedule) => {
        return {
          id: schedule.id
        };
      });

    let scheduleAction: ScheduleAction = new ScheduleAction();
    (scheduleAction.action = action),
      (scheduleAction.fromProjectId = this.projectId),
      (scheduleAction.projectId = this.scheduleActionForm.get('selectedProject')?.value.code),
      (scheduleAction.toScheduleId = this.scheduleActionForm.get('selectedSchedule')?.value.code),
      (scheduleAction.lineItemIds = selectedRows);
    (scheduleAction.quotationIds = []),
      (scheduleAction.userId = this.dataPersistance.userGuid);

    console.log('selectedRows', selectedRows);

    if (this.scheduleActionForm.valid) {
      this.logger.log('schedule', scheduleAction);
      this.projectScheduleService
        .sheduleActionLineItem(scheduleAction)
        .subscribe((scheduleCreated) => {
          this.spinner.hide();
          // this.scheduleAddComplete = true;
          this.alert.success('Success', 'Schedule action updated successfully.');

          this.refreshSchedules();
        });
    } else {
      this.alert.warn('Invalid Inputs', 'Unable to register user');
      this.spinner.hide();
      this.alert.warn('Invalid Inputs', 'Unable to add schedule');
    }
    this.spinner.hide();
  }
  addSchedule() {
    let scheduleName = this.addScheduleForm.get('txtScheduleName')?.value;
    if (scheduleName == '' || scheduleName == undefined) {
      this.alert.warn('Warning', 'Please enter schedule name.');
      return;
    }
    let desc = this.addScheduleForm.get('txtDescription')?.value;
    if (desc == '' || desc == undefined) {
      this.alert.warn('Warning', 'Please enter decription.');
      return;
    }
    let notes = this.addScheduleForm.get('txtNotes')?.value;

    if (notes == '' || notes == undefined) {
      this.alert.warn('Warning', 'Please enter notes.');
      return;
    }

    this.spinner.show();
    let schedule: ProjectSchedule = new ProjectSchedule();
    (schedule.projectId = this.projectId),
      (schedule.scheduleName = scheduleName),
      (schedule.description = desc),
      (schedule.notes = notes),
      (schedule.createdBy = this.dataPersistance.userGuid);

    if (this.addScheduleForm.valid) {
      this.logger.log('schedule', schedule);
      this.projectScheduleService
        .createShedule(schedule)
        .subscribe((scheduleCreated) => {
          this.spinner.hide();
          this.scheduleAddComplete = true;
          this.alert.success('Valid Inputs', 'Schedule added successfully.');
          this.visible = false;

          this.refreshSchedules();
        });
    } else {
      this.alert.warn('Invalid Inputs', 'Unable to register user');
      this.spinner.hide();
      this.alert.warn('Invalid Inputs', 'Unable to add schedule');
    }
  }

  schduleActiveChange(selectedStatus: any) {
    this.spinner.show();
    let id = this.editScheduleForm.get('hdnEditId')?.value
    if (this.addScheduleForm.valid) {
      this.logger.log('schedule', selectedStatus.checked);
      this.projectScheduleService
        .updateSheduleStatus(id, selectedStatus.checked)
        .subscribe((scheduleUpdated) => {
          this.spinner.hide();
          this.scheduleAddComplete = true;
          this.alert.success('Valid Inputs', 'Schedule updated successfully.');
          this.visible = false;

          this.refreshSchedules();
        });
    } else {
      console.log('Unable to add schedule');
      this.spinner.hide();
      this.alert.warn('Invalid Inputs', 'Unable to add schedule');
    }
  }
  editSchedule() {

    let id = this.editScheduleForm.get('hdnEditId')?.value
    let scheduleName = this.editScheduleForm.get('txtEditScheduleName')?.value

    if (scheduleName == '' || scheduleName == undefined) {
      this.alert.warn('Warning', 'Please enter schedule name.');
      return;
    }

    let notes = this.editScheduleForm.get('txtEditNotes')?.value

    if (notes == '' || notes == undefined) {
      this.alert.warn('Warning', 'Please enter notes.');
      return;
    }

    this.spinner.show();

    if (this.addScheduleForm.valid) {
      this.projectScheduleService
        .updateScheduleInfo(id, scheduleName, notes)
        .subscribe((scheduleUpdated) => {
          this.spinner.hide();
          this.scheduleAddComplete = true;
          this.alert.success('Valid Inputs', 'Schedule updated successfully.');
          this.visible = false;

          this.refreshSchedules();
        });
    } else {
      console.log('Unable to add schedule');
      this.spinner.hide();
      this.alert.warn('Invalid Inputs', 'Unable to add schedule');
    }
  }
  update() {
    let selectLoadSchedules = this.loadScheduleUpdateForm.get('selectLoadSchedules')?.value;

    if (selectLoadSchedules.length <= 0) {
      this.alert.warn('Warning', 'Please select atleast one schedule.');
      return;
    }

    let schedules: Array<string> = [];
    selectLoadSchedules.forEach((schedule: { code: string }) => {
      schedules.push(schedule.code)
    });

    this.fillProjectScheduleListView(this.projectId, schedules);
  }
  updateSubmittalReq(detailsId: string, submittalReq: boolean) {
    this.spinner.show();
    this.projectScheduleService
      .updateSubmittalStatus(detailsId, submittalReq)
      .subscribe((scheduleUpdated) => {
        this.spinner.hide();
        this.scheduleAddComplete = true;
        this.alert.success('Valid Inputs', 'Submittal Req updated successfully.');
        this.visible = false;

        this.refreshGrid();
      });
  }

  displayTemplate(template: TemplateRef<any>, templateHeader: string, item: any) {
    this.visible = true;
    this.currentTemplateHeader = templateHeader;
    this.currentTemplate = template;
    this.editScheduleForm.get("hdnEditId")?.setValue(item.code)
    this.editScheduleForm.get("txtEditScheduleName")?.setValue(item.name)
    this.editScheduleForm.get("txtEditNotes")?.setValue(item.notes)
    this.checked = item.isActive;
  }

  CreateAndSubmitUserQuote() {
    alert('Create and submit Quote with selected line items');
    debugger;
    var selectedTableRows = this.lstProjectScheduleListViewNAdopter.filter(a => a.isSelected == true);
    var selectedQuoteProductIds : string = "";
    selectedTableRows.forEach(row => {
      selectedQuoteProductIds = selectedQuoteProductIds +" " + row.quoteProductID;
    });
    alert(selectedQuoteProductIds);
  }

  displayProductConfiguration(selectedProduct: any) {
    this.configureProductDialog = true;
    setTimeout(() => {
      this.loadConfigurator(selectedProduct.code, null);
    }, 1000);
  }

  hideProductConfiguration() {
    this.reConfigureProduct=false;
    this.configureProductDialog = false;
    this.tryDisposeEmbed();
  }

  editProductConfiguration(item: any) {
    this.configureProductDialog = true;
    var lineItemId = item.id;
    var quoteProductID = item.quoteProductID;
    var quoteProductConfiguration: any = 
    this.cpqService.GetConfiguredProductFromCPQ(quoteProductID)
    .subscribe((data) => {
      this.logger.log("Api respons from CPQ : " , data);
      //this.loadConfigurator(56,data);
      this.editConfigurator(data, quoteProductID);
    });    
  }

  editConfigurator(configuredProductToEdit: any, quoteProductID : any) {
    debugger;
    this.ngZone.runOutsideAngular(() => {
      this.cpqEmbedconfig = new kbmax.ConfiguratorEmbed({
        kbmaxUrl: this.cpqService.getCPQKBMaxURL(),
        elementId: "viewer",
        configuredProduct: configuredProductToEdit,
        configuredProductId : quoteProductID,
        showHeader: false,
        showConfigHeader: true,
        showDrawer: false,
        showMove: false,
        bindToFormSelector: "",
        loadStyle: "none",
        layoutsettings: "{'Show Price':false}",
        parameters: {
          "portalUserGUID":this.dataPersistance.userGuid, //Reference to user GUID creating/updating the configuration. CPQ will query this id to obtain permissions.
          "portalProjectId":this.projectId //Reference to project id that CPQ can query to obtain project information (project name, zip code)
        },
        
      });
      this.cpqEmbedconfig.onMessage.add((msg:any)=> {
        //KCC Portal Embedded Host Page - Receive message and handle page content.
        if (msg.name == "cpqCloseEmbed") {    

        } else if (msg.name == "cpqSaveProduct") {
          this.cpqEmbedconfig.getConfiguredProduct((cp: any) => {
            // this.cpqService.SaveConfiguredProduct(cp,this.projectId,this.activeScheduleId,this.dataPersistance.userGuid);
          });            
        } else if (msg.name == "cpqSaveAndSubmitProduct") {
          this.cpqEmbedconfig.getConfiguredProduct((cp: any) => {
            this.cpqService.SaveConfiguredProduct(cp,this.projectId,this.activeScheduleId,this.dataPersistance.userGuid).subscribe(x => {
              this.handleSaveConfiguredProductResponse(x);
            });
            //this.cpqService.SaveAndSubmitConfiguredProduct(cp,this.projectId,this.activeScheduleId,this.dataPersistance.userGuid);
          });
        }
      });   
    });
  }
  
  addProductToQueue() {
    this.cpqEmbedconfig.getConfiguredProduct((cp: any) => {
      this.cpqService.SaveConfiguredProduct(cp,this.projectId,this.activeScheduleId,this.dataPersistance.userGuid);
    });
  }

  loadConfigurator(configuratorId: number, configuredProduct: any) {
    debugger;
    this.ngZone.runOutsideAngular(() => {
      this.tryDisposeEmbed();
      this.cpqEmbedconfig = new kbmax.ConfiguratorEmbed({
        kbmaxUrl: this.cpqService.getCPQKBMaxURL(),
        elementId: "viewer",
        configuratorId: configuratorId, 
        configuredProduct: configuredProduct,
        showHeader: false,
        showConfigHeader: true,
        showDrawer: false,
        showMove: false,
        bindToFormSelector: "",
        loadStyle: "none",
        layoutsettings: "{'Show Price':false}",
        parameters: {
          "portalUserGUID":this.dataPersistance.userGuid, //Reference to user GUID creating/updating the configuration. CPQ will query this id to obtain permissions.
          "portalProjectId":this.projectId //Reference to project id that CPQ can query to obtain project information (project name, zip code)
        },
        
      });
      this.cpqEmbedconfig.onMessage.add((msg: any) => {
        //KCC Portal Embedded Host Page - Receive message and handle page content.
        if (msg.name == "cpqCloseEmbed") {

        } else if (msg.name == "cpqSaveProduct") {
          this.cpqEmbedconfig.getConfiguredProduct((cp: any) => {
            // this.cpqService.SaveConfiguredProduct(cp,this.projectId,this.activeScheduleId,this.dataPersistance.userGuid);
          });

        } else if (msg.name == "cpqSaveAndSubmitProduct") {
          this.cpqEmbedconfig.getConfiguredProduct((cp: any) => {
            this.cpqService.SaveConfiguredProduct(cp, this.projectId, this.activeScheduleId, this.dataPersistance.userGuid).subscribe(x => {
              this.handleSaveConfiguredProductResponse(x);
            });
            //this.cpqService.SaveAndSubmitConfiguredProduct(cp,this.projectId,this.activeScheduleId,this.dataPersistance.userGuid);
          });
        }
      });   
    });
  }

  private handleSaveConfiguredProductResponse(x: any) {
    this.alert.success('Success', x.message);
    this.confirmDialogService.confirm({
      target: undefined,
      message: 'Do you want to configure another product?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      acceptIcon: "none",
      rejectIcon: "none",
      rejectButtonStyleClass: "p-button-text",
      accept: () => {
        this.reConfigureProduct = true;
        this.tryDisposeEmbed();
      },
      reject: () => {
        this.hideProductConfiguration();
      }
    }
    );
  }

  private tryDisposeEmbed() {
    if (this.cpqEmbedconfig) {
      this.cpqEmbedconfig.dispose();
      this.cpqEmbedconfig = null;
    }
  }
  
  setSelectLineItem(selectedItem: any) {
    selectedItem.isSelected = !selectedItem.isSelected;
  }
  activeSchedule(selectedItem: any) {
    this.lstProjectLoadSchedule.forEach(item => item.active = false);
    this.activeScheduleId = selectedItem.code;
    this.activeProjectId = selectedItem.projectId;
    alert("Schedule ID : " + this.activeScheduleId + " Project ID : " + this.activeProjectId);
    selectedItem.active = true;

    this.refreshGrid();
  }
  refreshGrid() {
    const selectedRows = this.lstProjectLoadSchedule.filter(item => item.active);
    let schedules: Array<string> = [];
    selectedRows.forEach(element => {
      schedules.push(element.code);
    });
    this.fillProjectScheduleListView(this.projectId, schedules);
  }
  refreshSchedules() {
    this.fillLoadProjectSchedule();
  }

  // upload


  files: any = [];

  totalSize: number = 0;

  totalSizePercent: number = 0;

  choose(event: any, callback: any) {
    callback();
  }

  onRemoveTemplatingFile(event: any, file: any, removeFileCallback: any, index: any) {
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
    this.messageService.add({ severity: 'info', summary: 'Success', detail: 'File Uploaded', life: 3000 });
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
  openDocUploadPopUp(item: any) {
    this.uploadDoc = true;
    this.uploadDocForm.get("lineItemUploadDoc")?.setValue(item);
  }
  openDocUploadListPopUp() {
    this.uploadDoc = true;
    let id = this.listDocForm.get('lineItemViewDoc')?.value;
    this.uploadDocForm.get("lineItemUploadDoc")?.setValue(id);
  }
  cancelUploadDoc(){
    this.uploadDoc = false;
    this.uploadDocForm.get("lineItemUploadDoc")?.setValue('');
  }
  uploadDocuments() {
    debugger;
    let id = this.uploadDocForm.get('lineItemUploadDoc')?.value
    let description = this.uploadDocForm.get('uploadDocumentDescription')?.value
    let userGuid = this.dataPersistance.userGuid;

    this.projectScheduleService.uploadDocuments(id, description, userGuid, this.files).subscribe(
      (response) => {
        console.log('Upload successful', response);
        debugger;
        this.fillLineitemDocuments(id);
      },
      (error) => {
        console.error('Upload failed', error);
      }
    );
   
    this.uploadDoc = false;
    
  }
  documentlist(item: any) {
    this.documentList = true;
    this.fillLineitemDocuments(item);
    this.listDocForm.get("lineItemViewDoc")?.setValue(item);
  }
  deleteDocuments() {
    debugger;
    let id = this.listDocForm.get('lineItemViewDoc')?.value;
    
    const selectedRows = this.lstLineitemDocs.filter(item => item.isSelected);
        if (selectedRows.length <= 0) {
          this.alert.warn('Warning', 'Please select at least one lineitem.');
          return;
        }
        console.log('id',id);
        console.log('selectedRows',selectedRows);

        this.spinner.show();
        let deletLineItemDoc: DeletLineItemDoc = new DeletLineItemDoc();
        deletLineItemDoc.action="Delete";
        deletLineItemDoc.fromProjectId=this.projectId;
        deletLineItemDoc.lineItemIds = selectedRows;
        deletLineItemDoc.userId=this.dataPersistance.userGuid;

        if (this.scheduleActionForm.valid) {
          this.logger.log('schedule', deletLineItemDoc);
          this.projectScheduleService
            .deletLineItemDoc(deletLineItemDoc)
            .subscribe((scheduleCreated) => {
              this.spinner.hide();
              this.alert.success('Success', 'Documents deleted successfully.');
    
              this.fillLineitemDocuments(id);
            });
        } else {
          this.alert.warn('Invalid Inputs', 'Unable to register user');
          this.spinner.hide();
          this.alert.warn('Invalid Inputs', 'Unable to add schedule');
        }
        this.spinner.hide();

    // this.documentList = false;
  }
  downloadDocuments(fileName:string) {
    let id = this.listDocForm.get('lineItemViewDoc')?.value;
    this.projectScheduleService.downloadDocuments(id, fileName).subscribe(
      (response) => {
        console.log('Downloaded successful', response);
        this.alert.success("Success","File downloaded successfully");
      },
      (error) => {
        console.error('Downloaded failed', error);
      }
    );
  }
}

