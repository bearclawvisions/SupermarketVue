<script setup lang="ts" generic="T">
import {Column, DataTable, Skeleton} from "primevue";
import type {ColumnConfig} from "@/types/Models.ts";
import {ref} from "vue";

defineProps<{
  data: T[];
  columns: Array<ColumnConfig<T>>;
  isLoading?: boolean;
}>();

const selected = ref<T[]>([]);
</script>

<template>
  <DataTable
      v-model:selection="selected"
      selection-mode="single"
      data-key="id"
      :meta-key-selection="false"
      :value="data" class="datatable"
      striped-rows
  >
    <Column
        v-for="column in columns"
        :key="String(column.field)"
        :field="String(column.field)"
        :header="column.header"
        :hidden="column.hidden"
        :sortable="true"
    >
      <template #body="{ data }: { data: T }">
        <Skeleton v-if="isLoading" height="1.2rem"/>
        <span v-else>{{ data[column.field] }}</span>
      </template>
    </Column>
    <template #footer>
      <Skeleton v-if="isLoading" height="1rem" width="8rem"/>
      <span v-else>Found {{ data ? data.length : 0 }} results.</span>
    </template>
  </DataTable>
</template>
