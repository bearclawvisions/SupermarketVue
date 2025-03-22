<script setup lang="ts">
import Shell from '@/components/shell/Shell.vue'

import { ref, onMounted, provide } from 'vue'

const csrfToken = ref<string | undefined>("");

provide('csrfToken', csrfToken)

onMounted(async () => {
  getCookie("X-XSRF-TOKEN");
});

// Function to get cookie by name
function getCookie(name: string) {
  const match = document.cookie.match(new RegExp('(^| )' + name + '=([^;]+)'));
  console.log(match)
  if (match) {
    csrfToken.value = match[2]; // The second part is the value of the cookie
  }
}
</script>

<template>
  <div class="shell-wrapper">
    <Shell />
  </div>
</template>
