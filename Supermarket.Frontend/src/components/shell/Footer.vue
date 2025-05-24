<script setup lang="ts">
import Panel from 'primevue/panel';
import {Routes} from "@/enums/Routes.ts";
</script>

<template>
  <div class="footer">
    <Panel>
      <template #header>
        <div>
          <RouterLink :to="Routes.About" class="clickable-link">About</RouterLink>
          <span> - </span>
          <RouterLink :to="Routes.Privacy" class="clickable-link">Privacy</RouterLink>
        </div>
      </template>
      <p>© 2025 Supermarket™. All Rights Reserved.</p>
    </Panel>
  </div>
</template>