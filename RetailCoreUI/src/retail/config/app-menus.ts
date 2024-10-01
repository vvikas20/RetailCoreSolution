export const appMenus: Array<AppMenus> = [
    { routePath: '/home/dashboard', validationKey: 'Home' },
    { routePath: '#', validationKey: 'Dashboard' },
    { routePath: "/home/toolbox-mgt/toolbox", validationKey: 'Toolbox' },
    { routePath: "/home/featureone/my-project", validationKey: 'MyProject' },
    { routePath: "/home/administration", validationKey: 'Administrator' },
    { routePath: "#", validationKey: 'SupportTicket' },
    { routePath: "#", validationKey: 'CustomerServiceDashboard' },
    { routePath: "#", validationKey: 'MfgTools' }
];

interface AppMenus { routePath: string, validationKey: string }