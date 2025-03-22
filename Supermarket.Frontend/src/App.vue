<script setup lang="ts">
import Shell from '@/components/shell/Shell.vue'

import { ref, onMounted, provide } from 'vue'
import axios from "@/api/axios.ts"; // Import your Axios instance

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
  // const value = `${document.cookie}`;
  // console.log(value)
  // const parts = value.split(`; ${name}=`);
  // console.log(parts)
  // if (parts.length === 2)
  //   console.log(parts.pop()?.split(";").shift())
  //   csrfToken.value = parts.pop()?.split(";").shift();
}
</script>

<template>
  <div class="shell-wrapper">
    <Shell />
  </div>
</template>
