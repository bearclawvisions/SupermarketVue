<script setup lang="ts">
import { RouterView } from 'vue-router'
import Footer from '@/components/shell/Footer.vue';
import Navigation from '@/components/shell/Navigation.vue'
import Toast from 'primevue/toast';
</script>

<template>
  <Navigation />
  <Toast position="top-center" />
  <RouterView />
  
  <Footer />
</template>
