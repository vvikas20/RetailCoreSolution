import { MenuItem } from "primeng/api";

export const appMenus: Array<MenuItem> = [
    {
        items: [
            {
                label: 'Dashboard',
                icon: 'pi pi-chart-bar',
                routerLink: 'dashboard'
            }
        ]
    },
    {
        label: 'Users',
        items: [
            {
                label: 'Manage Users',
                icon: 'pi pi-pencil',
                routerLink: 'manage-users'
            },
            {
                label: 'Register User',
                icon: 'pi pi-plus',
                routerLink: 'resgister-user'
            }
        ]
    },
    {
        label: 'Roles',
        items: [
            {
                label: 'Manage Roles',
                icon: 'pi pi-plus'
            },
            {
                label: 'Manage Role Levels',
                icon: 'pi pi-search'
            }
        ]
    },
    {
        label: 'Product',
        items: [
            {
                label: 'Manage Products',
                icon: 'pi pi-cog'
            },
            {
                label: 'Manage Product Categories',
                icon: 'pi pi-inbox',
            }
        ]
    },
    {
        label: 'Orders',
        items: [
            {
                label: 'Manage Orders',
                icon: 'pi pi-cog'
            }
        ]
    },
    {
        label: 'My Profile',
        items: [
            {
                label: 'Overview',
                icon: 'pi pi-cog'
            },
            {
                label: 'Messages',
                icon: 'pi pi-inbox',
                badge: '2'
            },
            {
                label: 'Permissions',
                icon: 'pi pi-inbox',
            },
            {
                label: 'Logout',
                icon: 'pi pi-sign-out'
            }
        ]
    }
];