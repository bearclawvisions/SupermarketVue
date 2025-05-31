<script setup lang="ts">
import Shell from '@/components/shell/Shell.vue';
import { onBeforeMount, onMounted, provide } from 'vue';
import { useToast } from "primevue/usetoast";
import { ToastHelper } from '@/composables/toastHelper.ts';
import { useAccountStore } from '@/stores/AccountStore.ts'

const accountStore = useAccountStore();
const toast = useToast();

onBeforeMount(async () => {
  await accountStore.checkIfLoggedIn();
});

onMounted(async () => {
  const toastHelper = new ToastHelper(toast);
  provide('toastHelper', toastHelper);
})

</script>

<template>
  <div class="shell-wrapper">
    <Shell />
  </div>
</template>
