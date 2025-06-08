<script setup lang="ts">
import {DataTable, Column} from "primevue";
import type {UserModel} from "@/types/Models.ts";

defineProps({
  users: Array as () => UserModel[]
});
</script>

<template>
  <DataTable :value="users">
    <Column field="id" header="Id" hidden></Column>
    <Column field="firstName" header="Firstname"></Column>
    <Column field="lastName" header="Lastname"></Column>
    <Column field="email" header="Email"></Column>
    <Column field="emailConfirmed" header="EmailConfirmed"></Column>
    <Column field="roles" header="Roles"></Column>
    <Column field="createdOn" header="CreatedOn"></Column>
    <Column field="lastLogin" header="LastLogin"></Column>
    <template #footer>In total there are {{ users ? users.length : 0 }} users.</template>
  </DataTable>
</template>
