import { Routes } from '@angular/router';
import { roleGuard } from '../../../../core/guards/role.guard';
import { AdministrationComponent } from './administration.component';
import { UserAccountApprovalComponent } from './pages/user-account-approval/user-account-approval.component';
import { SettingsComponent } from './pages/settings/settings.component';
import { MenuManagementComponent } from './pages/menu-management/menu-management.component';
import { SupportTicketMappingComponent } from './pages/support-ticket-mapping/support-ticket-mapping.component';
import { DefaultUserPermissionComponent } from './pages/default-user-permission/default-user-permission.component';
import { ParentCompanyComponent } from './pages/parent-company/parent-company.component';
import { ModifyUserPermissionMappingComponent } from './pages/modify-user-permission-mapping/modify-user-permission-mapping.component';
import { ManageCustomersComponent } from './pages/manage-customers/manage-customers.component';


const Administration_Routes: Routes = [
    {
        path: '', component: AdministrationComponent, canActivateChild: [roleGuard],
        children: [
            { path: '', redirectTo: 'settings', pathMatch: 'full' },
            { path: 'settings', component: SettingsComponent },
            { path: 'manage-users', component: UserAccountApprovalComponent },
            { path: 'menu-management', component: MenuManagementComponent },
            { path: 'support-ticket-mapping', component: SupportTicketMappingComponent },
            { path: 'user-account-approval', component: UserAccountApprovalComponent },
            { path: 'default-user-permission', component: DefaultUserPermissionComponent },
            { path: 'parent-company', component: ParentCompanyComponent},
            { path: 'modify-user-mapping', component: ModifyUserPermissionMappingComponent},
            { path: 'manage-customer', component: ManageCustomersComponent},
        ]
    }
];

export { Administration_Routes };