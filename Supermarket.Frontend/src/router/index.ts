import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import RegisterView from '@/views/RegisterView.vue'
import LoginView from '@/views/LoginView.vue'
import ShopView from '@/views/ShopView.vue'
import {Routes} from "@/enums/Routes.ts";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: Routes.Home,
      name: 'home',
      component: HomeView,
    },
    {
      path: Routes.Shop,
      name: 'shop',
      component: ShopView,
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
})

export default router
