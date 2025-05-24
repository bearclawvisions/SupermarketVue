import { ref } from 'vue'
import { defineStore } from 'pinia'
import axios from '@/api/axios.ts'
import type { ErrorResponse, StringResponse } from '@/types/Responses.ts'
import {Endpoints} from "@/enums/Endpoints.ts";
import {Stores} from "@/enums/Stores.ts";
import router from "@/router";
import {Routes} from "@/enums/Routes.ts";

export const useAccountStore = defineStore(Stores.Account, () => {
  const isLoggedIn = ref(false);

  function logIn(): void {
    isLoggedIn.value = true;
  }

  async function logOut(): Promise<void> {
    await axios.post(Endpoints.Logout)
      .then((response: StringResponse) => {
        isLoggedIn.value = false;
        router.push(Routes.Home);
      })
      .catch((error: ErrorResponse) => {
        console.error(error.response.data.message);
      })
  }

  async function checkIfLoggedIn(): Promise<void> {
    await axios.get(Endpoints.AuthenticateUser)
      .then((response: StringResponse) => {
        if (response.data === 'Authenticated') logIn();
        if (response.data === 'Not authenticated') return;
      })
      .catch((error: ErrorResponse) => {
        console.error(error.response.data.message);
      })
  }

  return {
    isLoggedIn,
    logIn,
    logOut,
    checkIfLoggedIn
  }
});
