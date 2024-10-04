import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { HomeComponent } from './home.component';
import { ConfiguratorComponent } from './components/configurator/configurator.component';
import { authGuard } from '../../core/guards/auth.guard';
import { HomeResolverService } from './resolvers/home-resolver.service';
import { ManageUsersComponent } from './pages/manage-users/manage-users.component';
import { ManageRolesComponent } from './pages/manage-roles/manage-roles.component';
import { ManageRoleLevelsComponent } from './pages/manage-role-levels/manage-role-levels.component';
import { ManageProductsComponent } from './pages/manage-products/manage-products.component';
import { ManageProductCatgoriesComponent } from './pages/manage-product-catgories/manage-product-catgories.component';
import { ManageOrdersComponent } from './pages/manage-orders/manage-orders.component';

const Home_Routes: Routes = [
    {
        path: '', component: HomeComponent, canActivate: []
        , resolve: { Permissions: HomeResolverService },
        children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', component: DashboardComponent },
            { path: 'user-profile', component: UserProfileComponent },
            { path: 'manage-users', component: ManageUsersComponent },
            { path: 'manage-roles', component: ManageRolesComponent },
            { path: 'manage-role-level', component: ManageRoleLevelsComponent },
            { path: 'manage-products', component: ManageProductsComponent },
            { path: 'manage-product-categories', component: ManageProductCatgoriesComponent },
            { path: 'manage-orders', component: ManageOrdersComponent }

        ]
    }
];

export { Home_Routes };