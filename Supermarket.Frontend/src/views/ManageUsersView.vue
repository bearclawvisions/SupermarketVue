<script setup lang="ts">
import {onMounted, ref} from "vue";
import type {UserModel} from "@/types/Models.ts";
import axios from "@/api/axios.ts";
import {ManageEndpoints} from "@/enums/ManageEndpoints.ts";
import {UserRoles} from "@/enums/UserRoles.ts";
import {getEnumKeyByValue} from "@/composables/enumHelper.ts";
import FullScreenContainer from "@/components/containers/FullScreenContainer.vue";
import GenericDataTable from "@/components/tables/GenericDataTable.vue";
import {defineColumns} from "@/composables/typeHelper.ts";

const userList = ref<UserModel[]>([]);
const isLoading = ref(true);

const columnConfig = defineColumns<UserModel>(
    {field: 'id', header: 'Id', hidden: true},
    {field: 'firstName', header: 'First Name'},
    {field: 'lastName', header: 'Last Name'},
    {field: 'email', header: 'Email'},
    {field: 'role', header: 'Role'},
    {field: 'emailConfirmed', header: 'Email Confirmed', hidden: true},
    {field: 'createdOn', header: 'Created On', hidden: true},
    {field: 'lastLogin', header: 'Last Login'},
    {
      field: 'id', header: 'Actions', actions: [
        {
          label: 'Edit User',
          icon: 'pi pi-pencil',
          severity: 'info',
          action: (user: UserModel) => {
            console.log('Editing user:', user);
            // Navigate to edit page or open modal
            // router.push(`/users/${user.id}/edit`);
          }
        },
        // {
        //   label: 'Toggle Status',
        //   icon: 'pi pi-power-off',
        //   severity: 'warn',
        //   action: (user: UserModel) => {
        //     console.log('Toggling status for:', user);
        //     // Toggle user status
        //     user.status = user.status === 'active' ? 'inactive' : 'active';
        //   },
        //   // visible: (user: UserModel) => user.id === 1 // hide based on state id
        // },
        {
          label: 'View Details',
          icon: 'pi pi-eye',
          severity: 'secondary',
          action: (user: UserModel) => {
            console.log('Viewing details for:', user);
            // Navigate to details page
            // router.push(`/users/${user.id}`);
          }
        },
        {
          label: 'Delete User',
          icon: 'pi pi-trash',
          severity: 'danger',
          action: (user: UserModel) => {
            console.log('Deleting user:', user);
            // Show confirmation dialog
            if (confirm(`Are you sure you want to delete ${user.firstName}?`)) {
              // Perform delete action
            }
          },
          // Only show delete for non-admin users
          visible: (user: UserModel) => user.role !== 'Admin'
        },
      ]
    }
);

const createSkeletonData = (): UserModel[] => {
  return Array.from({length: 5}, (_, index) => ({
    id: `skeleton-${index}`,
    firstName: '',
    lastName: '',
    email: '',
    role: '',
    emailConfirmed: true,
    createdOn: new Date(),
    lastLogin: new Date()
  })) as UserModel[];
};

const fetchUsersWithRoleMapping = async (): Promise<void> => {
  try {
    isLoading.value = true;
    const response = await axios.get<UserModel[]>(ManageEndpoints.GetAllUsers);
    userList.value = response.data.map(user => ({
      ...user,
      role: getEnumKeyByValue(UserRoles, user.role)
    })) as UserModel[];
  } catch (error) {
    console.log(error);
  } finally {
    isLoading.value = false;
  }
};

onMounted(async () => {
  await fetchUsersWithRoleMapping();
});
</script>

<template>
  <FullScreenContainer>
    <template #title>Manage Users</template>
    <template #body>
      <GenericDataTable
          :data="isLoading ? createSkeletonData() : userList"
          :columns="columnConfig"
          :is-loading="isLoading"
      />
    </template>
  </FullScreenContainer>
</template>
