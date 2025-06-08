<script setup lang="ts">
import {onMounted, ref} from "vue";
import type {UserModel} from "@/types/Models.ts";
import axios from "@/api/axios.ts";
import {ManageEndpoints} from "@/enums/ManageEndpoints.ts";

const userList = ref<UserModel[]>();

onMounted(async () => {
  await axios.get(ManageEndpoints.GetAllUsers)
      .then(response => {
        userList.value = response.data
      });
  
  console.log(userList.value)
})
</script>

<template>
  <div v-for="user in userList" :id="user.id">
    <div>{{user.firstName}} {{user.lastName}}</div>
  </div>
</template>

<style scoped>

</style>