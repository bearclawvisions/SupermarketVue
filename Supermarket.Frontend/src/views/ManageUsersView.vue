<script setup lang="ts">
import {onMounted, ref} from "vue";
import type {UserModel} from "@/types/Models.ts";
import axios from "@/api/axios.ts";
import {ManageEndpoints} from "@/enums/ManageEndpoints.ts";
import {UserRoles} from "@/enums/UserRoles.ts";
import {getEnumKeyByValue} from "@/composables/enumHelper.ts";
import FullScreenContainer from "@/components/containers/FullScreenContainer.vue";
import UserTableComponent from "@/components/tables/UserTableComponent.vue";

const userList = ref<UserModel[]>();

const fetchUsersWithRoleMapping = async (): Promise<void> => {
  try {
    const response = await axios.get<UserModel[]>(ManageEndpoints.GetAllUsers);
    userList.value = response.data.map(user => ({
      ...user,
      role: getEnumKeyByValue(UserRoles, user.role)
    })) as UserModel[];
  } catch (error) {
    console.log(error);
  }
};

onMounted(async () => {
  await fetchUsersWithRoleMapping();
});
</script>

<template>
  <FullScreenContainer>
    <template #title>Manage User</template>
    <template #body>
      <UserTableComponent :users="userList"/>
    </template>
  </FullScreenContainer>
</template>

<style scoped>

</style>