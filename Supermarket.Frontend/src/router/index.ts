import {createRouter, createWebHistory} from 'vue-router'
import HomeView from '../views/HomeView.vue'
import RegisterView from '@/views/RegisterView.vue'
import LoginView from '@/views/LoginView.vue'
import ShopView from '@/views/ShopView.vue'
import {Routes} from "@/enums/Routes.ts";
import {useAccountStore} from "@/stores/AccountStore.ts";
import {UserRoles} from "@/enums/UserRoles.ts";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: Routes.Home,
            name: 'home',
            component: HomeView,
            meta: {
              requiresAuth: false,
            }
        },
        {
            path: Routes.Shop,
            name: 'shop',
            component: ShopView,
            meta: {
                requiresAuth: true,
            }
            // component: () => import('../views/ShopView.vue'),
        },
        {
            path: Routes.Login,
            name: 'login',
            component: LoginView,
            // component: () => import('../views/LoginView.vue'),
        },
        {
            path: Routes.Register,
            name: 'register',
            component: RegisterView,
            // component: () => import('../views/RegisterView.vue'),
        },
        {
            path: Routes.About,
            name: 'about',
            // route level code-splitting
            // this generates a separate chunk (About.[hash].js) for this route
            // which is lazy-loaded when the route is visited.
            component: () => import('../views/AboutView.vue'),
        },
        {
            path: Routes.Privacy,
            name: 'privacy',
            // route level code-splitting
            // this generates a separate chunk (About.[hash].js) for this route
            // which is lazy-loaded when the route is visited.
            component: () => import('../views/PrivacyView.vue'),
        },
    ],
});

router.beforeEach((to, from, next) => {
    if (to.meta.requiresAuth) {
        const accountStore = useAccountStore();
        const token = accountStore.role != UserRoles.None;
        if (token) {
            // User is authenticated, proceed to the route
            next();
        } else {
            // User is not authenticated, redirect to login
            next('/login');
        }
    } else {
        // Non-protected route, allow access
        next();
    }
});

export default router
