import './assets/main.css';

import { createApp } from 'vue';
import { createPinia } from 'pinia';

import App from './App.vue';
import router from './router';
import PrimeVue from "primevue/config";
import Aura from '@primeuix/themes/aura';
import ToastService from 'primevue/toastservice';

const app = createApp(App);

app.use(PrimeVue, { 
  theme: { 
    preset: Aura,
    options: {
      prefix: 'p',
      darkModeSelector: 'system',
      cssLayer: false,
      
    }
  },
  // zIndex: {
  //   modal: 1100,        //dialog, drawer
  //   overlay: 1000,      //select, popover
  //   menu: 1000,         //overlay menus
  //   tooltip: 1100       //tooltip
  // }
  // csp: {
  //   nonce: '...'
  // }
});

app.use(createPinia());
app.use(router);
app.use(ToastService);

app.mount('#app');
