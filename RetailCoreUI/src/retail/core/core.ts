import { ENVIRONMENT_INITIALIZER, EnvironmentProviders, ErrorHandler, InjectionToken, Provider, inject } from "@angular/core";
import { HTTP_INTERCEPTORS, HttpInterceptorFn, provideHttpClient } from "@angular/common/http";
import { authInterceptor } from "./interceptors/auth.interceptor";
import { httpErrorInterceptor } from "./interceptors/http-error.interceptor";
import { ErrorHandlerService } from "./error-handler/error-handler.service";
import { DataPersistanceService } from "./services/data-persistance.service";
import { HttpService } from "./http/http.service";
import { AlertService } from "./ui-services/alert.service";
import { ConfirmationService, MessageService } from "primeng/api";
import { NgxSpinnerService } from "ngx-spinner";
import { SpinnerService } from "./ui-services/spinner.service";
import { HttpRequestCounterService } from "./helper/http-request-counter.service";
import { httpRequestCounterInterceptor } from "./interceptors/http-request-counter.interceptor";
import { AuthenticationService } from "./auth/authentication.service";
import { requestCounterReducer } from "./states/request-counter/request-counter.reducer";
import { provideState } from "@ngrx/store";
import { LoggerService } from "./services/logger.service";
import { LayoutService } from "./services/layout.service";
import { AutherizationService } from "./auth/autherization.service";
import { ConfirmDialogService } from "./ui-services/confirm-dialog.service";

// create unique injection token for the guard
export const CORE_GUARD = new InjectionToken<string>('CORE_GUARD');

export function provideCoreStates(): EnvironmentProviders[] {
    return [provideState('requestCounter', requestCounterReducer)];
}

export function provideCoreInterceptor(): HttpInterceptorFn[] {
    return [authInterceptor, httpRequestCounterInterceptor, httpErrorInterceptor];
}

export function provideCore(): Provider[] {
    return [
        { provide: CORE_GUARD, useValue: 'CORE_GUARD' },
        AuthenticationService,
        AutherizationService,
        DataPersistanceService,
        LoggerService,
        HttpService,
        MessageService, ConfirmationService, AlertService, ConfirmDialogService,
        NgxSpinnerService, SpinnerService,
        LayoutService,
        { provide: ErrorHandler, useClass: ErrorHandlerService },
        {
            provide: ENVIRONMENT_INITIALIZER,
            multi: true,
            useValue() {
                const coreGuard = inject(CORE_GUARD, {
                    skipSelf: true,
                    optional: true,
                });
                if (coreGuard) {
                    throw new TypeError(`provideCore() can be used only once per application (and never in library)`);
                }
            }
        }
    ];
}
