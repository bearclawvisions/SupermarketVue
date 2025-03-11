<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import { Menubar } from 'primevue'
import { ref, watch } from 'vue'
import { useRouter } from 'vue-router'
import { useAccountStore } from '@/stores/AccountStore.ts'

const router = useRouter()

const items = ref([
  {
    label: 'Home',
    icon: 'pi pi-home',
    command: () => {
      router.push('/')
    }
  },
  {
    label: 'Sub-items',
    icon: 'pi pi-palette',
    items: [
      {
        label: 'About',
        route: '/about'
      }
      // {
      //   label: 'Unstyled',
      //   route: '/theming/unstyled'
      // }
    ]
  }
  // {
  //   label: 'External',
  //   icon: 'pi pi-home',
  //   items: [
  //     {
  //       label: 'Vue.js',
  //       url: 'https://vuejs.org/'
  //     },
  //     {
  //       label: 'Vite.js',
  //       url: 'https://vitejs.dev/'
  //     }
  //   ]
  // }
])

const { isLoggedIn } = useAccountStore()
// watch(() => isLoggedIn, () => {
//   (newValue: boolean) => {
//     console.log(newValue)
//   }
// })

</script>

<template>
  <div class="card">
    <Menubar :model="items">
      <template #start>
        <span>placeholder</span>
      </template>

      <template #item="{ item, props, hasSubmenu }">
        <RouterLink v-if="item.route" v-slot="{ href, navigate }" :to="item.route" custom>
          <a :href="href" v-bind="props.action" @click="navigate">
            <span :class="item.icon" />
            <span>{{ item.label }}</span>
          </a>
        </RouterLink>
        <a v-else :href="item.url" :target="item.target" v-bind="props.action">
          <span :class="item.icon" />
          <span>{{ item.label }}</span>
          <span v-if="hasSubmenu" class="pi pi-fw pi-angle-down" />
        </a>
      </template>

      <template #end>
        <div v-if="isLoggedIn">
          <span>placeholder - account</span>
        </div>
        <div v-else>
          <span>Log in</span>
        </div>
      </template>
    </Menubar>
  </div>

  <!--  <nav>-->
  <!--    <RouterLink to="/">Home</RouterLink>-->
  <!--    <RouterLink to="/about">About</RouterLink>-->
  <!--  </nav>-->

  <RouterView />
</template>
