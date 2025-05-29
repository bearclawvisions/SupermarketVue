<script setup lang="ts">
import BlueCard from "@/components/card/BlueCard.vue";
import type {BlueCardInfo} from "@/types/Models.ts";

defineProps({
  cardInfo: Array<BlueCardInfo>,
});
</script>

<template>
  <div class="grid md:grid-cols-2 gap-6">
    <BlueCard v-for="info in cardInfo">
      <template #title>{{info.title}}</template>
      <template #body>{{info.body}}</template>
    </BlueCard>
  </div>
</template>

<style scoped>

</style>