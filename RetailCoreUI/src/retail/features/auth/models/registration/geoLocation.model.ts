import { IState } from "./state.model";

export interface IGeoLocation{
    id : string,
    countryName : string,
    stateList : Array<IState>,
    countryCode : Array<string>
}