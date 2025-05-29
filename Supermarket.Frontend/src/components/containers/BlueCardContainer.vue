<script setup lang="ts">
import BlueCard from "@/components/cards/BlueCard.vue";
import type {BlueCardInfo} from "@/types/Models.ts";

defineProps({
  cardInfo: Array<BlueCardInfo>,
});
</script>

<template>
  <div class="blue-card-container">
    <BlueCard v-for="info in cardInfo">
      <template #title>{{info.title}}</template>
      <template #body>{{info.body}}</template>
    </BlueCard>
  </div>
</template>

<style scoped>

</style>