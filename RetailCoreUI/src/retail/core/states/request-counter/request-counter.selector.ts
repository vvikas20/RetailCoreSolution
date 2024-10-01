import { createSelector } from "@ngrx/store";
import { AppState } from "../app.state";


export const selectRequestCounterStore = (state: AppState) => state.requestCounter;

export const selectRequestCounter = createSelector(
    selectRequestCounterStore,
    (state) => state.count
);