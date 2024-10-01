export interface IMenu {
    id: string
    name: string
    description: string
    menu_Key: string
    parentId: string
    active: boolean
    child: ISubMenu
    routePath:string
    menuOrder: string
    menuIcon:string
    isActive: boolean
}
export interface ISubMenu {
    id: string
    name: string
    description: string
    menu_Key: string
    parentId: string
    active: boolean
}