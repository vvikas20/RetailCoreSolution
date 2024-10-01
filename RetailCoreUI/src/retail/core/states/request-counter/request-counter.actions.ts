import { createAction } from '@ngrx/store';


export const incrementRequestCount = createAction('[Request Counter] Increment');
export const decrementRequestCount = createAction('[Request Counter] Decrement');
export const resetRequestCount = createAction('[Request Counter] Reset');
