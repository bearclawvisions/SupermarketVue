<script setup lang="ts">
import type {Portrait} from "@/types/Models.ts";

defineProps({
  portraits: Array<Portrait>,
});
</script>

<template>
  <div class="portrait-container">
    <div v-for="member in portraits" :key="member.id">
      <div class="portrait-photo">
        <img :src="member.photo" :alt="member.name" class="photo">
      </div>
      <p>{{ member.name }}</p>
      <p class="portrait-subtitle">{{ member.role }}</p>
      <p class="portrait-id">ID: {{ member.id }}</p>
    </div>
  </div>
</template>

<style scoped>

</style>