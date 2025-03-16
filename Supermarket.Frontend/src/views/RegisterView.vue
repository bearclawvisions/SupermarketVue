<script setup lang="ts">
import InputText from 'primevue/inputtext';
import Password from 'primevue/password';
import DatePicker from 'primevue/datepicker';
import Checkbox from 'primevue/checkbox';
import FloatLabel from 'primevue/floatlabel';

import Panel from 'primevue/panel';
import Button from 'primevue/button';
import { Form } from '@primevue/forms';
import DynamicField from '@/components/account/DynamicField.vue';
import { ref, computed } from 'vue';

const registerFormSchema = [
  { name: 'firstName', label: 'First Name', type: 'text', required: true },
  { name: 'lastName', label: 'Last Name', type: 'text', required: true },
  { name: 'birthDate', label: 'Birth Date', type: 'date', required: false },
  { name: 'email', label: 'Email', type: 'text', required: true },
  { name: 'password', label: 'Password', type: 'password', required: true },
  { name: 'confirmPassword', label: 'Confirm Password', type: 'password', required: true },
  // { name: 'terms', label: 'Terms and Conditions', type: 'checkbox', required: true }
];

const formValues = ref({
  firstName: '',
  lastName: '',
  birthDate: Date.now(),
  email: '',
  password: '',
  confirmPassword: '',
  terms: false,
});

const resolver = ({ values }: any) => {
  const errors: Record<string, { message: string }[]> = {};
  if (!values.firstName) errors.firstName = [{ message: 'First Name is required.' }];
  if (!values.email) errors.email = [{ message: 'Email is required.' }];
  return { values, errors };
};

const onFormSubmit = ({ valid, values }: any) => {
  if (valid) {
    console.log('Form submitted successfully', values);
  }
};
</script>

<template>
  <div class="basic-container">
    <Panel>
      <template #header>
        <div>
          <span class="font-bold">Register for a new account</span>
        </div>
      </template>

      <Form v-slot="$form" :resolver="resolver" :formValues @submit="onFormSubmit">
        
<!--        <DynamicField-->
<!--          v-for="field in registerFormSchema"-->
<!--          :key="field.name"-->
<!--          :field="field"-->
<!--          v-model="($form.values as Record<string, any>)[field.name]"-->
<!--          :error="($form.errors as Record<string, any>)[field.name]?.[0]?.message"-->
<!--        />-->

        <div class="mb-4" v-for="field in registerFormSchema">
          <FloatLabel>
            <InputText v-model="field.name" :id="field.name" autocomplete="off" fluid />
<!--            <Password v-else-if="field.type === 'password'" v-model="model" :id="field.name" :feedback="false" toggle-mask fluid />-->
<!--            <DatePicker v-else-if="field.type === 'date'" v-model="model" :inputId="field.name" format="yyyy-MM-dd" fluid />-->
<!--            <Checkbox v-else-if="field.type === 'checkbox'" v-model="model" :inputId="field.name" binary fluid />-->
            <label :for="field.name">{{ field.label }}</label>
          </FloatLabel>

          <!-- Error message -->
<!--          <small v-if="error" class="p-error">{{ error }}</small>-->
        </div>

        <Button type="submit" label="Register" />
      </Form>
    </Panel>
  </div>
</template>
