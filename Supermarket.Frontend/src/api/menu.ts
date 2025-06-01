import {UserRoles} from "@/enums/UserRoles.ts";
import {Routes} from "@/enums/Routes.ts";
import type {MenuItemConfig} from "@/types/Models.ts";

const menuItems: MenuItemConfig[] = [
    {
        id: 'home',
        label: 'Home',
        icon: 'pi pi-home',
        route: Routes.Home,
        roles: [UserRoles.None, UserRoles.Admin, UserRoles.Customer]
    },
    {
        id: 'shop',
        label: 'Shop',
        icon: 'pi pi-shop',
        route: Routes.Shop,
        roles: [UserRoles.Admin, UserRoles.Customer]
    },
    {
        id: 'business-info',
        label: 'Business information',
        icon: 'pi pi-building',
        roles: [UserRoles.None, UserRoles.Admin, UserRoles.Customer],
        items: [
            {
                id: 'about',
                label: 'About',
                route: Routes.About,
                roles: [UserRoles.None, UserRoles.Admin, UserRoles.Customer]
            },
            {
                id: 'privacy',
                label: 'Privacy',
                route: Routes.Privacy,
                roles: [UserRoles.None, UserRoles.Admin, UserRoles.Customer]
            }
        ]
    },
    {
        id: 'external',
        label: 'External',
        icon: 'pi pi-external-link',
        roles: [UserRoles.None, UserRoles.Customer],
        items: [
            {
                id: 'vuejs',
                label: 'Vue.js',
                url: 'https://vuejs.org/',
                roles: [UserRoles.None, UserRoles.Customer]
            },
            {
                id: 'vitejs',
                label: 'Vite.js',
                url: 'https://vitejs.dev/',
                roles: [UserRoles.None, UserRoles.Customer]
            }
        ]
    },
    {
        id: 'manage',
        label: 'Manage',
        icon: 'pi pi-pencil',
        roles: [UserRoles.Admin],
        items: [
            {
                id: 'manage-users',
                label: 'Manage Users',
                icon: 'pi pi-user-edit',
                route: Routes.ManageUsers,
                roles: [UserRoles.Admin]
            },
            {
                id: 'manage-shop',
                label: 'Manage Shop',
                icon: 'pi pi-pen-to-square',
                route: Routes.ManageShop,
                roles: [UserRoles.Admin]
            }
        ]
    }
];

export function getMenuForRole(role: UserRoles) {
    function filterByRole(items: MenuItemConfig[]): any[] {
        return items
            .filter(item => item.roles.includes(role))
            .map(item => {
                const { roles, id, ...menuItem } = item;
                if (item.items) {
                    return {
                        ...menuItem,
                        items: filterByRole(item.items)
                    };
                }
                return menuItem;
            });
    }

    return filterByRole(menuItems);
}
