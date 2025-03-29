import { ref } from 'vue'
import { defineStore } from 'pinia'
import axios from '@/api/axios.ts'
import type { ErrorResponse, StringResponse } from '@/types/Responses.ts'

export const useAccountStore = defineStore('account', () => {
  const isLoggedIn = ref(false);

  function logIn(): void {
    isLoggedIn.value = true;
  }

  function logOut(): void {
    isLoggedIn.value = false;
  }

  async function checkIfLoggedIn(): Promise<void> {
    await axios.get('api/AppUser/AuthenticateUser')
      .then((response: StringResponse) => {
        logIn();
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
