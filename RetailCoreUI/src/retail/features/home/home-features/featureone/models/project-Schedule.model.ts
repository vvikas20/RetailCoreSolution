export class ProjectSchedule {
    id: string = '';
    projectId: string = '';
    scheduleName: string = '';
    description: string = '';
    notes: string = '';
    createdBy: string = '';
}
export interface IProjectSchedule {
    id: string
    projectId: string
    scheduleName: string
    description: string
    notes: string
    isActive: boolean
    createdDate: Date
    createdBy: string
    modifiedDate: Date
    modifiedBy: string
}
export interface IProjectScheduleListView {
    id: string
    scheduleName: string
    modelNumber: string
    description: string
    eUnitName: string
    nUnitName: string
    curbType: string
    unitModelNumber: string
    standardPrice: number
    expressPrice: number
    expeditedPrice: number
    extendedPrice: number
    tag: string
    perfVerified: boolean
    priceVerified: boolean
    submittalReq: boolean
    unitSize: string
    totalPrice: number
    quantity: number
    quotationID: string,
    quoteProductID: string
    orderID: string
    notes: string
    createdDate: string
    createdBy: string
    createdByUserName: string
    modifiedDate: string
    modifiedBy: string
    modifiedByUserName: string
}
