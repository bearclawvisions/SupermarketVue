<script setup lang="ts">
import { RouterView } from 'vue-router'
import Footer from '@/components/shell/Footer.vue';
import Navigation from '@/components/shell/Navigation.vue'
import { Toast } from 'primevue';
</script>

<template>
  <Navigation />
  <Toast />
  <RouterView />
  
  <Footer />
</template>
