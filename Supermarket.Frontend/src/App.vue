<script setup lang="ts">
import Shell from '@/components/shell/Shell.vue';
import { onBeforeMount } from 'vue';
import axios from '@/api/axios.ts';

onBeforeMount(async () => {
  await axios.get("/api/AppUser/GetSuperMarketCookie");
});
</script>

<template>
  <div class="shell-wrapper">
    <Shell />
  </div>
</template>
