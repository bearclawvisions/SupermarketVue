import {ref} from 'vue';
import {defineStore} from 'pinia';
import axios from '@/api/axios.ts';
import type {ErrorResponse, IntResponse, ListResponse, StringResponse} from '@/types/Responses.ts';
import {AppUserEndpoints} from "@/enums/AppUserEndpoints.ts";
import {Stores} from "@/enums/Stores.ts";
import router from "@/router";
import {Routes} from "@/enums/Routes.ts";
import {UserRoles} from "@/enums/UserRoles.ts";
import {getMenuForRole} from "@/api/menu.ts";

export const useAccountStore = defineStore(Stores.Account, () => {
  const isLoggedIn = ref(false);
  const userId = ref<string>('00000000-0000-0000-0000-000000000000');
  const role = ref<UserRoles>(UserRoles.None);

  function logIn(backendRole: UserRoles): void {
    isLoggedIn.value = true;
    role.value = backendRole;
  }

  async function logOut(): Promise<void> {
    await axios.post(AppUserEndpoints.Logout)
      .then((response: StringResponse) => {
        isLoggedIn.value = false;
        role.value = UserRoles.None;
        router.push(Routes.Home);
      })
      .catch((error: ErrorResponse) => {
        console.error(error.response.data.message);
      })
  }

  async function checkIfLoggedIn(): Promise<void> {
    await axios.get(AppUserEndpoints.AuthenticateUser)
      .then((response: IntResponse<UserRoles>) => {
        if (response.data === UserRoles.None)
          return;
        else
          logIn(response.data);
      })
      .catch((error: ErrorResponse) => {
        console.error(error.response.data.message);
      })
  }
  
  function menuItems(): any[] {
    return getMenuForRole(role.value);
  }

  return {
    isLoggedIn,
    role,
    logIn,
    logOut,
    checkIfLoggedIn,
    menuItems,
  }
});
