import { ref } from 'vue'
import { defineStore } from 'pinia'

export const useAccountStore = defineStore('account', () => {
  const isLoggedIn = ref(false)

  function logIn() {
    isLoggedIn.value = true
  }

  function logOut() {
    isLoggedIn.value = false
  }

  return {
    isLoggedIn,
    logIn,
    logOut
  }
})
