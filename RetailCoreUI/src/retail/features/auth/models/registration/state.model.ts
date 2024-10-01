import { ICity } from "./cities.model"

export interface IState{
    id : string
    countryId : string
    stateName : string
    cityList : Array<ICity>
}