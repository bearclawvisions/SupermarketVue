<script setup lang="ts">
import Panel from 'primevue/panel';
</script>

<template>
  <Panel class="fullscreen-container">
    <template #header>
      <div class="container-title">
        <template v-if="$slots.icon">
          <slot name="icon"/>&nbsp;
        </template>
        <slot name="title"/>
        <div class="container-subtitle">
          <slot name="subtitle"/>
        </div>
      </div>
    </template>
    <template #default>
      <slot name="body"/>
    </template>
  </Panel>
</template>

<style scoped>

</style>