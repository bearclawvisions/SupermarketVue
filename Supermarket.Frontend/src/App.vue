<script setup lang="ts">
import Shell from '@/components/shell/Shell.vue';
import { onBeforeMount, onMounted, provide } from 'vue'
import axios from '@/api/axios.ts';
import { useToast } from "primevue/usetoast";
import { ToastHelper } from '@/composables/toastHelper.ts'

onBeforeMount(async () => {
  await axios.get("/api/AppUser/GetXsrfToken");
});

onMounted(async () => {
  const toast = useToast();
  const toastHelper = new ToastHelper(toast);
  provide('toastHelper', toastHelper);
})

</script>

<template>
  <div class="shell-wrapper">
    <Shell />
  </div>
</template>
