<script setup lang="ts">

</script>

<template>
  <div class="paragraph-content">
    <div class="paragraph-heading">
      <template v-if="$slots.title">
        <slot name="title"/>&nbsp;
      </template>
    </div>
    <slot name="body"/>
  </div>
</template>
