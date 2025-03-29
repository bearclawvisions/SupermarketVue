<script setup lang="ts">
import Panel from 'primevue/panel';
</script>

<template>
  <div class="footer">
    <Panel>
      <template #header>
        <div>
          <RouterLink to="/about" class="clickable-link">About</RouterLink>
          <span> - </span>
          <RouterLink to="/privacy" class="clickable-link">Privacy</RouterLink>
        </div>
      </template>
      <p>© 2025 Supermarket™. All Rights Reserved.</p>
    </Panel>
  </div>
</template>