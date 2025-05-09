﻿<script setup lang="ts">
import InputText from 'primevue/inputtext';
import Password from 'primevue/password';
import Checkbox from 'primevue/checkbox';
import FloatLabel from 'primevue/floatlabel';
import Panel from 'primevue/panel';
import { Message } from 'primevue';
import Button from 'primevue/button';
import { Form } from '@primevue/forms';
import { inject, ref } from 'vue'
import axios from '@/api/axios.ts';
import type { ToastHelper } from '@/composables/toastHelper.ts'
import type { ErrorResponse, StringResponse } from '@/types/Responses.ts'
import type { RegisterModel } from '@/types/Models.ts'

const toastHelper = inject('toastHelper') as ToastHelper;

const registerFormValues = ref<RegisterModel>({
  firstName: '',
  lastName: '',
  email: '',
  password: '',
  confirmPassword: '',
  terms: false,
});

const hasRegistered = ref<boolean>(false);

const registerResolver = ({ values }: {values: any}) => {
  const errors: Record<string, { message: string }[]> = {};
  if (!values.firstName) errors.firstName = [{ message: 'First Name is required.' }];
  if (!values.lastName) errors.lastName = [{ message: 'Last Name is required.' }];

  const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
  if (!values.email) {
    errors.email = [{ message: 'Email is required.' }];
  } else if (!emailRegex.test(values.email)) {
    errors.email = [{ message: 'Please enter a valid email address.' }];
  }

  if (!values.password) {
    errors.password = [{ message: 'Please enter a password.' }];
  } else {
    if (values.password.length < 8) {
      if (!errors.password) errors.password = [];
      errors.password.push({ message: 'Password must be at least 8 characters long.' });
    }
    if (!/[a-z]/.test(values.password)) {
      if (!errors.password) errors.password = [];
      errors.password.push({ message: 'Password must contain at least one lowercase letter.' });
    }
    if (!/[A-Z]/.test(values.password)) {
      if (!errors.password) errors.password = [];
      errors.password.push({ message: 'Password must contain at least one uppercase letter.' });
    }
    if (!/[!@#$%^&*(),.?":{}|<>]/.test(values.password)) {
      if (!errors.password) errors.password = [];
      errors.password.push({ message: 'Password must contain at least one special character.' });
    }
  }
  
  if (!values.confirmPassword) errors.confirmPassword = [{ message: 'Please confirm your password.' }];
  if (values.password !== values.confirmPassword) {
    errors.confirmPassword = [{ message: 'Passwords do not match.' }];
  }
  
  if (!values.terms) errors.terms = [{ message: 'Please accept the terms and conditions.' }];
  
  return { values, errors };
};

const onRegisterFormSubmit = async ({ valid, values }: { valid: boolean, values: any }) => {
  if (valid) {
    await axios.post('/api/AppUser/Register', values as RegisterModel)
      .then((result: StringResponse) => {
        hasRegistered.value = true;
        toastHelper.displayInfo(result.data);
      })
      .catch((error: ErrorResponse) => {
        toastHelper.displayError(error.response.data.message);
      });
  }
}
</script>

<template>
  <div class="basic-container">
    <template v-if="!hasRegistered">
      <Panel>
        <template #header>
          <div>
            <span class="font-bold">Register for a new account</span>
          </div>
        </template>

        <Form v-slot="$form" :resolver="registerResolver" :registerFormValues @submit="onRegisterFormSubmit">

          <div class="basic-form-item">
            <FloatLabel variant="on">
              <InputText name="firstName" type="text" id="firstName" autocomplete="off" fluid />
              <label for="firstName">First Name</label>
            </FloatLabel>
            <Message v-if="$form.firstName?.invalid" severity="error" size="small" variant="simple">
              {{ $form.firstName.error.message }}
            </Message>
          </div>

          <div class="basic-form-item">
            <FloatLabel variant="on">
              <InputText name="lastName" type="text" id="lastName" autocomplete="off" fluid />
              <label for="lastName">Last Name</label>
            </FloatLabel>
            <Message v-if="$form.lastName?.invalid" severity="error" size="small" variant="simple">
              {{ $form.lastName.error.message }}
            </Message>
          </div>

          <div class="basic-form-item">
            <FloatLabel variant="on">
              <InputText name="email" type="email" id="email" autocomplete="off" fluid />
              <label for="email">Email</label>
            </FloatLabel>
            <Message v-if="$form.email?.invalid" severity="error" size="small" variant="simple">
              {{ $form.email.error.message }}
            </Message>
          </div>

          <div class="basic-form-item">
            <FloatLabel variant="on">
              <Password name="password" id="password" :feedback="false" toggle-mask fluid />
              <label for="password">Password</label>
            </FloatLabel>
            <template v-if="$form.password?.invalid">
              <Message v-for="error in ($form.password.errors)" severity="error" size="small" variant="simple">
                {{ error.message }}
              </Message>
            </template>
          </div>

          <div class="basic-form-item">
            <FloatLabel variant="on">
              <Password name="confirmPassword" id="confirmPassword" :feedback="false" toggle-mask fluid />
              <label for="confirmPassword">Confirm Password</label>
            </FloatLabel>
            <Message v-if="$form.confirmPassword?.invalid" severity="error" size="small" variant="simple">
              {{ $form.confirmPassword.error.message }}
            </Message>
          </div>

          <div class="basic-form-item">
            <Checkbox name="terms" id="terms" binary fluid />
            <label for="terms"> Terms and conditions</label>
            <Message v-if="$form.terms?.invalid" severity="error" size="small" variant="simple">
              {{ $form.terms.error.message }}
            </Message>
          </div>

          <Button type="submit" label="Register" />
        </Form>
      </Panel>
    </template>
    
    <template v-else>
      <Panel>
        <template #header>
          <div>
            <span class="font-bold">Registration success!</span>
          </div>
        </template>

        <div>
          You can now login with the email used in the registration.
        </div>

      </Panel>
    </template>
  </div>
</template>
