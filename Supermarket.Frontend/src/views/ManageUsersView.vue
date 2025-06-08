<script setup lang="ts">
import {onMounted, ref} from "vue";
import type {UserModel} from "@/types/Models.ts";
import axios from "@/api/axios.ts";
import {ManageEndpoints} from "@/enums/ManageEndpoints.ts";
import {UserRoles} from "@/enums/UserRoles.ts";
import {getEnumKeyByValue} from "@/composables/enumHelper.ts";

const userList = ref<UserModel[]>();

onMounted(async () => {
  await axios.get(ManageEndpoints.GetAllUsers)
    .then(response => {
      userList.value = response.data;
    })
    .catch(error => {
      console.log(error);
    })
});
</script>

<template>
  <div v-for="user in userList" :id="user.id">
    <div>{{ user.firstName }} {{ user.lastName }}</div>
    <div v-for="role in user.roles">
      <div>{{ getEnumKeyByValue(UserRoles, role) }}</div>
    </div>
  </div>
</template>

<style scoped>

</style>