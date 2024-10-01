import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { HomeComponent } from './home.component';
import { ConfiguratorComponent } from './components/configurator/configurator.component';
import { authGuard } from '../../core/guards/auth.guard';
import { HomeResolverService } from './resolvers/home-resolver.service';

const Home_Routes: Routes = [
    {
        path: '', component: HomeComponent, canActivate: []
        , resolve: { Permissions: HomeResolverService },
        children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', component: DashboardComponent },
            { path: 'user-profile', component: UserProfileComponent },
            { path: 'test-configurator', component: ConfiguratorComponent },
            { path: 'featureone', loadChildren: () => import('./home-features/featureone/featureone-routing').then(feature => feature.Featureone_Routes) },
            { path: 'toolbox-mgt', loadChildren: () => import('./home-features/toolbox-mgt/toolbox-mgt-routing').then(feature => feature.ToolboxMgtComponent_Routes) },
            { path: 'administration', loadChildren: () => import('./home-features/administration/administration-routing').then(feature => feature.Administration_Routes) },
        ]
    }
];

export { Home_Routes };