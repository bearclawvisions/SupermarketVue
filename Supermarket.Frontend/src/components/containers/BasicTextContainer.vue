<script setup lang="ts">
import Panel from 'primevue/panel';
</script>

<template>
  <Panel class="basic-container">
    <template #header>
      <div class="container-title">
        <template v-if="$slots.icon">
          <slot name="icon"/>&nbsp;
        </template>
        <slot name="title"/>
      </div>
    </template>
    <template #default>
      <slot name="body"/>
    </template>
  </Panel>
</template>

<style scoped>

</style>