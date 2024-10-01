import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './retail.routes';
import { provideCore, provideCoreInterceptor, provideCoreStates } from './core/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideState, provideStore } from '@ngrx/store';
import { requestCounterReducer } from './core/states/request-counter/request-counter.reducer';
import { BrowserModule } from '@angular/platform-browser';

export const retailConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    BrowserModule,
    importProvidersFrom([BrowserAnimationsModule]),
    provideStore(),
    provideHttpClient(withInterceptors(provideCoreInterceptor())),
    provideCore(),
    provideCoreStates()
  ]
};
