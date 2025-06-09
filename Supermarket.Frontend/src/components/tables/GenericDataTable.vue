<script setup lang="ts" generic="T">
import {Column, DataTable, Skeleton, Button} from "primevue";
import type {ColumnConfig} from "@/types/Models.ts";
import {computed, ref} from "vue";

const props = defineProps<{
  data: T[];
  columns: Array<ColumnConfig<T>>;
  isLoading?: boolean;
}>();

const selected = ref<T[]>([]);

// Check if any column has actions defined
const hasActions = computed(() => {
  return props.columns.some(column => column.actions && column.actions.length > 0);
});

// Get all actions from all columns (in case you want actions from multiple columns)
const getAllActions = (item: T) => {
  const allActions: Array<NonNullable<ColumnConfig<T>['actions']>[number]> = [];
  props.columns.forEach(column => {
    if (column.actions) {
      allActions.push(...column.actions);
    }
  });
  return allActions;
};

// Get visible actions for a specific item
const getVisibleActions = (item: T) => {
  const actions = getAllActions(item);
  return actions.filter(action =>
      action.visible ? action.visible(item) : true
  );
};

</script>

<template>
  <DataTable
      v-model:selection="selected"
      selection-mode="single"
      data-key="id"
      :meta-key-selection="false"
      :value="data" 
      class="datatable"
      striped-rows
  >
    
    <Column
        v-for="column in columns.filter(col => !col.actions)"
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
    
    <Column header="Actions" :sortable="false" v-if="hasActions">
      <template #body="{ data }: { data: T }">
        <div class="flex gap-2">
          <Button
              v-for="action in getVisibleActions(data)"
              :key="action.label"
              :icon="action.icon"
              :severity="action.severity"
              size="small"
              @click="action.action(data)"
              :disabled="isLoading"
              text
          />
        </div>
      </template>
    </Column>

    <template #footer>
      <Skeleton v-if="isLoading" height="1rem" width="8rem"/>
      <span v-else>Found {{ data ? data.length : 0 }} results.</span>
    </template>
    
  </DataTable>
</template>
