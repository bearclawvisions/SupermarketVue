import {UserRoles} from "@/enums/UserRoles.ts";
import {Routes} from "@/enums/Routes.ts";
import type {MenuItemConfig} from "@/types/Models.ts";
import {PrimeIcons} from "@primevue/core/api";
import {NavLabel} from "@/enums/NavLabel.ts";

const menuItems: MenuItemConfig[] = [
    {
        id: NavLabel.Home,
        label: NavLabel.Home,
        icon: PrimeIcons.HOME,
        route: Routes.Home,
        roles: [UserRoles.None, UserRoles.Admin, UserRoles.Customer]
    },
    {
        id: NavLabel.Shop,
        label: NavLabel.Shop,
        icon: 'pi pi-shop',
        route: Routes.Shop,
        roles: [UserRoles.Admin, UserRoles.Customer]
    },
    {
        id: NavLabel.BusinessInformation,
        label: NavLabel.BusinessInformation,
        icon: PrimeIcons.BUILDING,
        roles: [UserRoles.None, UserRoles.Admin, UserRoles.Customer],
        items: [
            {
                id: NavLabel.About,
                label: NavLabel.About,
                route: Routes.About,
                roles: [UserRoles.None, UserRoles.Admin, UserRoles.Customer]
            },
            {
                id: NavLabel.Privacy,
                label: NavLabel.Privacy,
                route: Routes.Privacy,
                roles: [UserRoles.None, UserRoles.Admin, UserRoles.Customer]
            }
        ]
    },
    {
        id: NavLabel.External,
        label: NavLabel.External,
        icon: PrimeIcons.EXTERNAL_LINK,
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
        id: NavLabel.Manage,
        label: NavLabel.Manage,
        icon: PrimeIcons.PENCIL,
        roles: [UserRoles.Admin],
        items: [
            {
                id: NavLabel.ManageUsers,
                label: NavLabel.ManageUsers,
                icon: PrimeIcons.USER_EDIT,
                route: Routes.ManageUsers,
                roles: [UserRoles.Admin]
            },
            {
                id: NavLabel.ManageShop,
                label: NavLabel.ManageShop,
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
