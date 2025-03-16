<script setup lang="ts">
import { computed } from 'vue';
import InputText from 'primevue/inputtext';
import Password from 'primevue/password';
import DatePicker from 'primevue/datepicker';
import Checkbox from 'primevue/checkbox';
import FloatLabel from 'primevue/floatlabel';

const props = defineProps<{
  field: {
    name: string;
    label: string;
    type: string;
    required: boolean;
  };
  modelValue: any;
  error?: string;
}>();

const emit = defineEmits<{
  (e: 'update:modelValue', value: any): void;
}>();

// Computed for two-way binding
const model = computed({
  get: () => props.modelValue,
  set: (val) => emit('update:modelValue', val),
});
</script>

<template>
  <div class="mb-4">
    <FloatLabel>
      <InputText v-if="field.type === 'text'" v-model="model" :id="field.name" autocomplete="off" fluid />
      <Password v-else-if="field.type === 'password'" v-model="model" :id="field.name" :feedback="false" toggle-mask fluid />
      <DatePicker v-else-if="field.type === 'date'" v-model="model" :inputId="field.name" format="yyyy-MM-dd" fluid />
      <Checkbox v-else-if="field.type === 'checkbox'" v-model="model" :inputId="field.name" binary fluid />
      <label :for="field.name">{{ field.label }}</label>
    </FloatLabel>

    <!-- Error message -->
    <small v-if="error" class="p-error">{{ error }}</small>
  </div>
</template>

<style scoped>
.mb-4 {
  margin-bottom: 1rem;
}
</style>
