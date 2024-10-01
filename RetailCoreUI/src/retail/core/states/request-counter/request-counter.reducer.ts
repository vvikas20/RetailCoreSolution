import { createReducer, on } from '@ngrx/store'
import { decrementRequestCount, incrementRequestCount, resetRequestCount } from './request-counter.actions'

export interface RequestCounterState {
    count: number
}

export const initialRequestCounterState: RequestCounterState = {
    count: 0
}

export const requestCounterReducer = createReducer(
    initialRequestCounterState,
    on(incrementRequestCount, (state: { count: number }) => ({ ...state, count: state.count + 1 })),
    on(decrementRequestCount, (state: { count: number }) => ({ ...state, count: state.count - 1 })),
    on(resetRequestCount, (state: { count: number }) => ({ ...state, count: 0 }))
)