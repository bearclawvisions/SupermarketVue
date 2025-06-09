<script setup lang="ts" generic="T">
import {Column, DataTable} from "primevue";
import type {ColumnConfig} from "@/types/Models.ts";

defineProps<{
  data: T[]
  columns: Array<ColumnConfig<T>>
}>()
</script>

<template>
  <DataTable :value="data" class="datatable">
    <Column
        v-for="column in columns"
        :key="String(column.field)"
        :field="String(column.field)"
        :header="column.header"
        :hidden="column.hidden"
    >
      <template #body="{ data }: { data: T }">
        {{ data[column.field] }}
      </template>
    </Column>
    <template #footer>Found {{ data ? data.length : 0 }} results.</template>
  </DataTable>
</template>
