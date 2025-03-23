<script setup lang="ts">
import Shell from '@/components/shell/Shell.vue';
import { onBeforeMount } from 'vue';
import axios from '@/api/axios.ts';

onBeforeMount(() => {
  fetchCookie();
});

async function fetchCookie() {
  try {
    await axios.get("/api/AppUser/GetSuperMarketCookie", { withCredentials: true });
    console.log("cookie fetched");
  } catch (error) {
    console.error("Failed to fetch CSRF token:", error);
  }
}
</script>

<template>
  <div class="shell-wrapper">
    <Shell />
  </div>
</template>
