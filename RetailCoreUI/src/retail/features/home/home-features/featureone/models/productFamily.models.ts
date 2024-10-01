import { ISubProductTypes } from "../../toolbox-mgt/models/subproduct-types.models"
import { IKCCUnit } from "./kccUnit.models"

export interface IProductFamily{
    id : string
    productID:number
    productName : string
    kccUnitList : IKCCUnit
    subProductTypeList : Array<ISubProductTypes>
}
