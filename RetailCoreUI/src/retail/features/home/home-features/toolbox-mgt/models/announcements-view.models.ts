import { User } from "../../../../auth/models/registration/user.model";

export interface IAnnouncement {
    id: string,
    sNo: Number,
    subProductTypeId: string,
    subProductTypeName: string,
    productFamilyID: string,
    productFamilyName: string,
    brandId: string,
    brandName: string,
    mainHeaderId: string,
    headerText: string,
    title: string,
    message: string,
    startDate: string,
    endDate: string,
    isActive: boolean,
    createdBy: string,
    createdDate: string,
    createdByUserName: string,
    modifiedBy: string,
    modifiedDate: string,
    modifiedByUserName: string,
    announcementDocuments:Array<any>,
    announcementAssignTos:Array<any>,
    announcementOwners:Array<any>,
    assignTo:string,
    owners:string
}
export class Announcement {
    id:string='';
    brandId: string = '';
    subProductTypeId: string = '';
    mainHeaderId: string = '';
    title: string = '';
    message: string = '';
    startDate: string = '';
    endDate: string = '';
    createdBy: string = '';
    description:string='';
    // assignTo:Array<any> = []
    // ownersIds:Array<any> = []
}
export interface IAnnouncementHome {
    homeAdapterList: Array<any>,
    homeCurbList: Array<any>,
    homeCurrentHorizonLeadTimeList: Array<any>,
    homeHVACList: Array<any>,
    homePriceConscienceGuidanceList: Array<any>,
    homeWelcomeNote: any
}