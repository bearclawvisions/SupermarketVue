<script setup lang="ts">
import Panel from 'primevue/panel'
import { Form } from '@primevue/forms'
import FloatLabel from 'primevue/floatlabel'
import InputText from 'primevue/inputtext'
import { Message } from 'primevue'
import { inject, ref } from 'vue'
import type { LoginModel, RegisterModel } from '@/types/Models.ts'
import axios from '@/api/axios.ts'
import type { ErrorResponse, StringResponse } from '@/types/Responses.ts'
import type { ToastHelper } from '@/composables/toastHelper.ts'
import Password from 'primevue/password'
import Button from 'primevue/button'
import { useAccountStore } from '@/stores/AccountStore'

const toastHelper = inject('toastHelper') as ToastHelper
const { logIn } = useAccountStore();

const loginFormValues = ref<LoginModel>({
  email: '',
  password: ''
})

const registerResolver = ({ values }: { values: any }) => {
  const errors: Record<string, { message: string }[]> = {}

  const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/
  if (!values.email) errors.email = [{ message: 'Username is required.' }]
  if (!emailRegex.test(values.email)) errors.email = [{ message: 'Please enter a valid email address.' }]
  if (!values.password) errors.password = [{ message: 'Please enter a password.' }]

  return { values, errors }
}

const onLoginFormSubmit = async ({ valid, values }: { valid: boolean, values: any }) => {
  if (valid) {
    await axios.post('/api/AppUser/Login', values as RegisterModel)
      .then((result: StringResponse) => {
        logIn();
        toastHelper.displayInfo(result.data);
      })
      .catch((error: ErrorResponse) => {
        toastHelper.displayError(error.response.data.message);
      })
  }
}
</script>

<template>
  <div class="basic-container">
    <Panel>
      <template #header>
        <div>
          <span class="font-bold">Login</span>
        </div>
      </template>

      <template #default>
        <Form v-slot="$form" :resolver="registerResolver" :loginFormValues @submit="onLoginFormSubmit">
          <div class="basic-form-item">
            <FloatLabel variant="on">
              <InputText name="email" type="text" id="email" autocomplete="off" fluid />
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
            <Message v-if="$form.password?.invalid" severity="error" size="small" variant="simple">
              {{ $form.password.error.message }}
            </Message>
          </div>

          <Button type="submit" label="Login" />
        </Form>
      </template>

      <template #footer>
        <p>Or
          <RouterLink to="/register" class="clickable-link"> register</RouterLink>
          for a new account.
        </p>
      </template>
    </Panel>
  </div>
</template>
