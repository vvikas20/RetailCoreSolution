import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { finalize } from 'rxjs';
import { AppState } from '../states/app.state';
import { decrementRequestCount, incrementRequestCount } from '../states/request-counter/request-counter.actions';

export const httpRequestCounterInterceptor: HttpInterceptorFn = (req, next) => {

  const state = inject(Store<AppState>);

  state.dispatch(incrementRequestCount());

  return next(req).pipe(
    finalize(() => {
      state.dispatch(decrementRequestCount());
    })
  );

};
