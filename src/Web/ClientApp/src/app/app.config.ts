import { HTTP_INTERCEPTORS, provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';
import { APP_ID, ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideClientHydration, BrowserModule } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { AuthorizeInterceptor } from '@app/core/auth/authorize.interceptor';
import { routes } from './app.routes';

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}

export const appConfig: ApplicationConfig = {
    providers: [
        provideRouter(routes, withComponentInputBinding()),
        provideClientHydration(),
        provideHttpClient(withFetch(), withInterceptorsFromDi()),
        provideAnimations(),
        { provide: APP_ID, useValue: 'ng-cli-universal' },
        { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
        { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
        importProvidersFrom(BrowserModule)
    ]
}
