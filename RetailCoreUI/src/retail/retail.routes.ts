import { Routes } from '@angular/router';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { RegistrationComponent } from './features/auth/pages/registration/registration.component';

export const routes: Routes = [
    { path: '', redirectTo: 'auth', pathMatch: 'full' },
    { path: 'auth', loadChildren: () => import('./features/auth/auth-routes').then(feature => feature.Auth_Routes) },
    { path: 'home', loadChildren: () => import('./features/home/home-routing').then(feature => feature.Home_Routes) },
    { path: 'register', component: RegistrationComponent },
    { path: '**', component: PageNotFoundComponent }
];
