import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UI_Modules } from '../../../../../../shared/modules/ui-modules.export';
import { angularModules } from '../../../../../../shared/modules/angular-modules.export';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Product } from '../../models/product.models';
import { DataPersistanceService } from '../../../../../../core/services/data-persistance.service';
import { ProjectScheduleService } from '../../../featureone/services/project-schedule.service';
import { SupportTicketService } from '../../../featureone/services/support-ticket.service';
import { SupportTicket,viewSupportTicket} from '../../models/support-ticket.models';
import { AlertService } from '../../../../../../core/ui-services/alert.service';

@Component({
  selector: 'retail-project-support-request',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './project-support-request.component.html',
  styleUrl: './project-support-request.component.scss',
  providers: [ProjectScheduleService, SupportTicketService]
})
export class ProjectSupportRequestComponent {
  visible: boolean = false;
  display: boolean = false;
  show:boolean = false; 
  view:boolean = false;
  views:boolean = false;
  updates:boolean = false;
  delegates:boolean = false;
  isEmailNotification = false;
  lstStatus: Array<any> = [];
  userName: string = '';
  lstProduct: Array<any> = [];
  lstProject: Array<any> = [];
  lstIssueType: Array<any> = [];
  lstIssueArea: Array<any> = [];
  lstTicketPriority: Array<any> = [];
  ticketCreateDate:any;
  lstSupportTicketListView: Array<any> = [];
  activeTab:string='';
  addEditPopUpTitle=''; 
  viewSupportTicket:any = {issueType:'', issueArea:'', attachment:'', issueDetails:''};
  selectedTicketId:string='';
  userType:string="1"; //1.internal or 2.external

  products: Product[] = [
    {
      sname: 'Schedule_N1',
      model: 'Horizon (OAK/N Rev5)',
      unit: '',
      desc: 'Horizon Outdoor Air Unit (K/N)',
      tag: ''
    }
  ];
  selectedProducts!: Product;
  
  constructor(private dataPersistenceService: DataPersistanceService,
    private projectScheduleService: ProjectScheduleService, 
    private supportTicketService: SupportTicketService,
    private alert: AlertService) 
    { }
  
    formAddNewSupportTicket: FormGroup = new FormGroup({
      selectIssueType: new FormControl(''),
      selectIssueArea: new FormControl(''),
      selectIProjectName: new FormControl(''),
      selectIProductName: new FormControl(''),
      txtareaIssueDetails: new FormControl(''),
      txtModelNumber: new FormControl(''),
      selectITicketPriority: new FormControl(''),      
      boolEmailNotification: new FormControl(''),
    });

    fillStatus() {
    this.lstStatus = [
      { code: 1, name: "InActive" },
      { code: 2, name: "Active" },
      { code: 3, name: "Show All" }
    ]
  }
  ngOnInit() {
    this.fillStatus();
    this.getUserName();
    this.setUserType();
    this.fillCPQProducts();
    this.fillProjects();
    this.fillIssueTypes();
    this.fillIssueAreas();
    this.fillTicketPrioritie();
    this.setTicketCreateDate();
    this.activeTab = 'my';
    this.fillSupportticketList("", this.activeTab);
  }
  advance() {
    this.visible = true;
  }
  restore(ticketId:string) {    
   if(ticketId==''){
    //add ticket"
    //Clear the control's value
    this.selectedTicketId='';
    this.addEditPopUpTitle="Add New ";
    this.ticketCreateDate = new Date().toLocaleDateString("en-US"); 
     }
   else{
    //edit ticket
    this.selectedTicketId = ticketId;
    this.addEditPopUpTitle="Update ";
    var sTicket = this.lstSupportTicketListView.filter(x=>x.id==ticketId)[0];
    this.FillValueOnTicketEdit(sTicket);
     }
   this.display = true;   
  }
  onUpload() {
    this.show = true;
  }
  history(ticketId:string) {
    this.view = true;
  }
  details(ticketId:string) {
     var sTikcet = this.lstSupportTicketListView.filter(x=>x.id==ticketId)[0];
     this.viewSupportTicket.issueType = sTikcet.issueType;
     this.viewSupportTicket.issueArea =  sTikcet.issueArea;
     this.viewSupportTicket.issueDetails =  sTikcet.issueDetails;  
    this.views = true;    
  }
  delegate(ticketId:string) {
    this.delegates = true;
  }
  update(ticketId:string) {
    this.updates = true;
  }
  getUserName() {
    this.userName = this.dataPersistenceService.userName;
  }
  setUserType(){
    //this.userType="";
  }
  fillCPQProducts() {
    this.projectScheduleService.getAllCPQProducts().subscribe((cpqProdList) => {
      this.lstProduct = cpqProdList.map((cpqProd) => {
        return {
          id: cpqProd.id, name: cpqProd.productName          
        };
      });
    });
  }
  fillProjects() {
    this.projectScheduleService.getProjectInfo().subscribe((projectLts) => {
      this.lstProject = projectLts.map((proj) => {
        return {
          id: proj.id, name: proj.projectName          
        };
      });
    });
  }
  fillIssueTypes() {
    this.supportTicketService.getIssueTypes().subscribe((issueTypLts) => {
      this.lstIssueType = issueTypLts.map((issueType) => {
        return {
          id: issueType.id, name: issueType.name          
        };
      });
    });
  }
  fillIssueAreas() {
    this.supportTicketService.getIssueAreas().subscribe((issueAreaLts) => {
      this.lstIssueArea = issueAreaLts.map((issueArea) => {
        return {
          id: issueArea.id, name: issueArea.name          
        };
      });
    });
  }
  fillTicketPrioritie() {
    this.supportTicketService.getTicketPriorities().subscribe((ticketPriorityLts) => {
      this.lstTicketPriority = ticketPriorityLts.map((tktPriority) => {
        return {
          id: tktPriority.id, name: tktPriority.name          
        };
      });
    });
  }
  setTicketCreateDate(){
    this.ticketCreateDate = new Date().toLocaleDateString("en-US");
  }
  addNewSupportTicket()
  {
    let _issueTypeId = this.formAddNewSupportTicket.get('selectIssueType')?.value.id || '';
    let _issueAreaId = this.formAddNewSupportTicket.get('selectIssueArea')?.value.id || '';
    let _projectId = this.formAddNewSupportTicket.get('selectIProjectName')?.value.id || '';
    let _productId = this.formAddNewSupportTicket.get('selectIProductName')?.value.id || '';
    let _issueDetails = this.formAddNewSupportTicket.get('txtareaIssueDetails')?.value || '';
    let _modelNumber = this.formAddNewSupportTicket.get('txtModelNumber')?.value || '';
    let _ticketPriority = this.formAddNewSupportTicket.get('selectITicketPriority')?.value.id || '';
    let _emailNotification = this.isEmailNotification;
    
    let supportticket: SupportTicket = new SupportTicket();
      (supportticket.Id = this.selectedTicketId),
      (supportticket.IssueTypeId = _issueTypeId),
      (supportticket.IssueAreaId = _issueAreaId),
      (supportticket.ProjectId = _projectId),
      (supportticket.ProductId = _productId),
      (supportticket.IssueDetails = _issueDetails),
      (supportticket.ModelNumber = _modelNumber),
      (supportticket.PriorityId = _ticketPriority),
      (supportticket.EmailNotification = _emailNotification),
      (supportticket.CreatedBy = this.dataPersistenceService.userGuid);      

    this.supportTicketService.createSupportTicket(supportticket)
      .subscribe((response) => {
        this.alert.success('Success',response.message)
        
        return response;
      },
      (error) => {
        if(error.statusCode==300){
          this.alert.warn('Warning',error.message);
        }
        else{this.alert.error('Failed',error.message)}
      });

  }
  cancelAnnouncememt(){
  }
  fillSupportticketList(seachText: string, filterType:string) {
    let userId = this.dataPersistenceService.userGuid;

    this.supportTicketService.getSupportTicketList(userId, seachText, filterType).subscribe((models) => {
      if (models == null) { this.lstSupportTicketListView = []; } else {
        this.lstSupportTicketListView = models.map((model) => {
          return {
            id: model.id,
            issueID: model.issueID,
            issueTypeId: model.issueTypeId,
            issueType: model.issueType,
            issueAreaId: model.issueAreaId,
            issueArea: model.issueArea,
            projectId: model.projectId,
            projectName: model.projectName,
            productId: model.productId,
            productName: model.productName,
            modelNumber: model.modelNumber,
            customerName: model.customerName,
            priorityId: model.priorityId,
            priorityName: model.priorityName,
            issueDetails: model.issueDetails,
            emailNotification: model.emailNotification,
            userName: model.userName,
            raisedOn: model.raisedOn,
            raisedBy: model.raisedBy,
            assignedTo: model.assignedTo,
            status: model.status,
            resolution: model.resolution,
            isEditable: model.isEditable,
            isAction: model.isAction            
          };
        });
      }
    });
  }
  MySupportTicket(thisObj:object){
    this.activeTab = "my";
   this.fillSupportticketList('',this.activeTab);
  }
  MyAssignedTicket(thisObj:object){
    this.activeTab = "assigned";
    this.fillSupportticketList('', this.activeTab);
  }
  ShowAllTicket(thisObj:object){
    this.activeTab = "all";
    this.fillSupportticketList('', this.activeTab);
  }
  FillValueOnTicketEdit(sTicket:any){     
    let selectedIssueType =  this.lstIssueType.filter(c=>c.id.toLowerCase()===sTicket.issueTypeId.toLowerCase())[0];
    let selectedIssueArea =  this.lstIssueArea.filter(c=>c.id.toLowerCase()===sTicket.issueAreaId.toLowerCase())[0];
    let selectedProject =  this.lstProject.filter(c=>c.id.toLowerCase()===sTicket.projectId.toLowerCase())[0];
    let selectedProduct =  this.lstProduct.filter(c=>c.id.toLowerCase()===sTicket.productId.toLowerCase())[0];
    let selectedPriority =  this.lstTicketPriority.filter(c=>c.id.toLowerCase()===sTicket.priorityId.toLowerCase())[0];
    
    this.ticketCreateDate = sTicket.raisedOn;
    this.formAddNewSupportTicket.get('txtareaIssueDetails')?.setValue(sTicket.issueDetails);
    this.formAddNewSupportTicket.get('txtModelNumber')?.setValue(sTicket.modelNumber);
    this.isEmailNotification = sTicket.emailNotification;
    this.formAddNewSupportTicket.get('selectIssueType')?.setValue(selectedIssueType);
    this.formAddNewSupportTicket.get('selectIssueArea')?.setValue(selectedIssueArea);
    this.formAddNewSupportTicket.get('selectIProjectName')?.setValue(selectedProject);
    this.formAddNewSupportTicket.get('selectIProductName')?.setValue(selectedProduct);
    this.formAddNewSupportTicket.get('selectITicketPriority')?.setValue(selectedPriority);
  }
}
