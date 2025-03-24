<script setup lang="ts">
import Panel from "primevue/panel";
import Button from 'primevue/button';
import Toast from 'primevue/toast';
import { Severity } from '@/enums/Severity.ts';


import { useToast } from "primevue/usetoast";
import { getEnumKeyByValue } from '@/composables/enumHelper.ts'
import { ToastHelper } from '@/composables/toastHelper.ts'
const toast = useToast();
const toastHelper = new ToastHelper(toast);

const show = () => {
  toastHelper.displayInfo('Toast via toasthelper');
  // toast.add({ severity: Severity.INFO, summary: getEnumKeyByValue(Severity, Severity.INFO), detail: 'Message Content', life: 5000 });
};

</script>

<template>
  <div class="card flex justify-center">
    <Toast />
    <Button label="Show" @click="show()" />
  </div>
  
  <div class="basic-container">
    <Panel>
      <template #header>
        <div>
          <span class="pi pi-shopping-bag"/>
          <span class="font-bold"> Supermarket</span>
        </div>
      </template>
      <p>
        The place that has all your daily needs!
      </p>
    </Panel>
  </div>
  
  <div class="basic-container">
    <Panel header="Supermarket">
      <template #header>
        <div>
          <span class="font-bold">Supermarket</span>
        </div>
      </template>
      <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore
        magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
        consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
        pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est
        laborum.
      </p>
    </Panel>
  </div>
  
</template>
