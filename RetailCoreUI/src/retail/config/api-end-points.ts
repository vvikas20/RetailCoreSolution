import { environment } from "../../environments/environment.development";

export class CPQ_Configs{
  static readonly KBMaxURL : string = "https://kccmfg-dev.kbmax.com";
}

export class ApiEndPoints {
  static readonly server_url: any = environment.serverUrl;

  static readonly authentication: string = ApiEndPoints.server_url + `/authentication/token`;
  static readonly verifytoken: string = ApiEndPoints.server_url + `/authentication/verify-token`;
  static readonly validate_useremail: string = ApiEndPoints.server_url + `/User/validate-user-email?userEmailId=`;
  static readonly validate_username: string = ApiEndPoints.server_url + `/User/validate-userid?userId=`;
  static readonly userRegistration: string = ApiEndPoints.server_url + `/User/user`;
  static readonly get_country: string = ApiEndPoints.server_url + `/GeoLocation/country`;
  static readonly get_city: string = ApiEndPoints.server_url + `/GeoLocation/city`;
  static readonly get_state: string = ApiEndPoints.server_url + `/GeoLocation/state`;
  static readonly get_geoLocations: string = ApiEndPoints.server_url + `/Registration/geo-location`;

  static readonly get_region: string = ApiEndPoints.server_url + `/Registration/region`;
  static readonly get_projectlist: string = ApiEndPoints.server_url + `/Project/project-list`;
  static readonly delete_documentslist: string = ApiEndPoints.server_url + `/Project/delete-documents`;
  static readonly delete_projectlist: string = ApiEndPoints.server_url + `/Project/delete-projects`;
  static readonly restore_projectlist: string = ApiEndPoints.server_url + `/Project/restore-projects`;
  static readonly adduser_project: string = ApiEndPoints.server_url + `/Project/add-additional-user`;
  static readonly get_productIntrested: string = ApiEndPoints.server_url + `/Registration/get-productintrested`;
  static readonly generateCaptcha: string = ApiEndPoints.server_url + `/Authentication/generate-captcha`;
  static readonly regenerateCaptcha: string = ApiEndPoints.server_url + `/Authentication/re-generate-captcha`;
  static readonly verifyCaptcha: string = ApiEndPoints.server_url + `/verifyCaptcha?captchavalue=`;
  static readonly leftSideMenu: string = ApiEndPoints.server_url + `/Menu/list`;
  static readonly get_permissiontypes: string = ApiEndPoints.server_url + `/Menu/permission-types`;
  static readonly get_usertype: string = ApiEndPoints.server_url + `/Menu/user-type`;
  static readonly checkUserEditPermission: string = ApiEndPoints.server_url + `/Project/check-user-edit-permission?projectId=`;


  static readonly getSchedule_productfamily: string = ApiEndPoints.server_url + `/Schedule/product-family`;
  static readonly getSchedule_AllCpqProducts: string = ApiEndPoints.server_url + `/Schedule/cpq-all-products`;
  static readonly getSchedule_kccunit: string = ApiEndPoints.server_url + `/Schedule/kcc-unit`;
  static readonly get_verticalMarket: string = ApiEndPoints.server_url + `/Project/project-vertical`;
  static readonly get_projectphase: string = ApiEndPoints.server_url + `/Project/project-phase`;
  static readonly getSearchInformation: string = ApiEndPoints.server_url + `/Project/search-user?searchCondition=`;
  static readonly get_projectpermissionlevel: string = ApiEndPoints.server_url + `/Project/project-permission-level`;
  static readonly get_AdministratorPermissionLevel: string = ApiEndPoints.server_url + `/Project/administrator-permission-level`;
  static readonly getProjectInfoList: string = ApiEndPoints.server_url + `/Project/project-list`;

  static readonly getProjectScheduleList: string = ApiEndPoints.server_url + `/Schedule/list`;
  static readonly getSchedule_kccmodel: string = ApiEndPoints.server_url + `/Schedule/kcc-model`;
  static readonly post_CreateSchedule: string = ApiEndPoints.server_url + `/Schedule/create-schedule`;
  static readonly post_UpdateScheduleStatus: string = ApiEndPoints.server_url + `/Schedule/update-schedule-status?id=`;
  static readonly post_UpdateScheduleInfo: string = ApiEndPoints.server_url + `/Schedule/update-schedule-info?id=`;
  static readonly post_CreateScheduleLineItem: string = ApiEndPoints.server_url + `/Schedule/create-schedule-lineitem`;
  static readonly get_cheduleLineItemView: string = ApiEndPoints.server_url + `/Schedule/view-list`;
  static readonly get_projectCustomerDetail: string = ApiEndPoints.server_url + `/Project/project-customer-detail?filterCompanyName=`;
  static readonly create_project: string = ApiEndPoints.server_url + `/Project/create-project`;
  static readonly update_project: string = ApiEndPoints.server_url + `/Project/update-project`;
  static readonly get_ProjectScheduleActionList: string = ApiEndPoints.server_url + `/Schedule/schedule-action-list`;
  static readonly get_ProjectScheduleQuoteTypes: string = ApiEndPoints.server_url + `/Schedule/quote-type-list`;
  static readonly post_ScheduleAction: string = ApiEndPoints.server_url + `/Schedule/schedule-action`;
  static readonly post_UpdateSubmittalStatus: string = ApiEndPoints.server_url + `/Schedule/update-submittal-status?id=`;
  static readonly post_ScheduleUploadFiles: string = ApiEndPoints.server_url + `/Schedule/upload-documents`;
  static readonly get_LineitemDocuments: string = ApiEndPoints.server_url + `/Schedule/lineitem-docs-list?id=`;
  static readonly post_DeleteLineitemDocuments: string = ApiEndPoints.server_url + `/Schedule/delete-lineitem-docs`;
  static readonly validateProjectName: string = ApiEndPoints.server_url + `/Project/validate-projectname?projectName=`;
  static readonly get_DownloadScheduleDocument: string = ApiEndPoints.server_url + `/Schedule/download-document?id=`;
  static readonly cpq_SaveConfiguredProduct : string = ApiEndPoints.server_url + `/CPQ/save-configured-product`;
  static readonly cpq_getQuoteProductFromCPQ : string = ApiEndPoints.server_url + `/CPQ/get-quote-product`;
  static readonly get_singe_project: string = ApiEndPoints.server_url + `/Project/get-single-project?projectId=`;

  static readonly reset_password: string = ApiEndPoints.server_url + `/Authentication/update-password`;
  static readonly forgot_password: string = ApiEndPoints.server_url + `/Authentication/forgot-password?emailID=`;

  static readonly generateMfaOTP: string = ApiEndPoints.server_url + `/authentication/generate-otp`;

  static readonly validateMfaOTP: string = ApiEndPoints.server_url + `/authentication/validate-otp`;

  static readonly get_AnnouncementDashboard: string = ApiEndPoints.server_url + `/Announcement/dashboard-announcement`;
  static readonly get_AnnouncementList: string = ApiEndPoints.server_url + `/Announcement/list`;
  static readonly get_brand: string = ApiEndPoints.server_url + `/Announcement/brand`;
  static readonly get_MainHeaders: string = ApiEndPoints.server_url + `/Announcement/main-header`;
  static readonly post_CreateAnnouncement: string = ApiEndPoints.server_url + `/Announcement/create-announcement`;
  static readonly post_DeleteAnnouncement: string = ApiEndPoints.server_url + `/Announcement/delete-announcement?id=`;
  static readonly post_EditAnnouncement: string = ApiEndPoints.server_url + `/Announcement/edit-announcement`;
  static readonly post_DeleteAnnouncementDocs: string = ApiEndPoints.server_url + `/Announcement/delete-documents`;
  static readonly get_AnnouncementDocuments: string = ApiEndPoints.server_url + `/Announcement/announcement-documents?id=`;
  static readonly post_UploadAnnouncementDocs: string = ApiEndPoints.server_url + `/Announcement/upload-documents`;
  static readonly get_DownloadAnnouncementDocument: string = ApiEndPoints.server_url + `/Announcement/download-document?id=`;
  //support ticket
  static readonly get_IssueTypes: string = ApiEndPoints.server_url + `/Support/issue-types`;
  static readonly get_UserByIssueType: string = ApiEndPoints.server_url + `/Support/get-user-byissue-type?issuetype=`;
  static readonly get_IssueByMappedType: string = ApiEndPoints.server_url + `/Support/getuser-by-mapped-type?issuetype=`;
  static readonly get_IssueAreas: string = ApiEndPoints.server_url + `/Support/issue-areas`;
  static readonly get_TicketPriorities: string = ApiEndPoints.server_url + `/Support/ticket-priorities`;
  static readonly post_CreateSupportTicket: string = ApiEndPoints.server_url + `/Support/create-support-ticket`;
  static readonly post_getSupportTickets: string = ApiEndPoints.server_url + `/Support/get-support-tickets`;
  static readonly post_getSupportTicket: string = ApiEndPoints.server_url + `/Support/get-support-ticket`;
  static readonly post_SaveIssueUserMapping: string = ApiEndPoints.server_url + `/Support/save-issue-usermapping`;
  // Role Menu Mapping
  static readonly get_UsersView: string = ApiEndPoints.server_url + `/User/list-view`;
  static readonly post_UserPermissionMapping: string = ApiEndPoints.server_url + `/Menu/create-user-menu-mapping`;
  static readonly post_RevokeUserPermissionMapping: string = ApiEndPoints.server_url + `/Menu/revoke-user-menu-mapping`;
  static readonly get_UserMenuPermissionList: string = ApiEndPoints.server_url + `/Menu/user-menu-permission-list`;

  //User Account Approval
  static readonly post_UpdateApproveUser: string = ApiEndPoints.server_url + `/User/approve-user?userId=`;
  static readonly post_UpdateDeclineUser: string = ApiEndPoints.server_url + `/User/decline-user?userId=`;
  static readonly post_UserEmailAccountApproval: string = ApiEndPoints.server_url + `/User/user-approval-email`;
  static readonly post_AssignProductPermissionStatus: string = ApiEndPoints.server_url + `/User/assign-product-permission`;

  //Customer Company
  static readonly put_EditCustomerCompany: string = ApiEndPoints.server_url + `/CustomerCompany/customer-company`;
  static readonly get_ParentCompanyUserAccess: string = ApiEndPoints.server_url + `/CustomerCompany/parentcompany-useraccess?companyId=`;
}