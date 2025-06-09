<script setup lang="ts">
import BasicTextContainer from "@/components/containers/BasicTextContainer.vue";
import {PrimeIcons} from '@primevue/core/api';

const icon = PrimeIcons.SHOPPING_BAG;
</script>

<template>
  <BasicTextContainer>
    <template #icon><i :class="icon"/></template>
    <template #title>Neo-Vision Food Cube</template>
    <template #body>The place that has all your daily needs!</template>
  </BasicTextContainer>

  <BasicTextContainer>
    <template #title>Supermarket</template>
    <template #body>
      Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore
      magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
      consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
      pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est
      laborum.
    </template>
  </BasicTextContainer>
</template>
