<script setup lang="ts">
import GenericDataTable from "@/components/tables/GenericDataTable.vue";
import FullScreenContainer from "@/components/containers/FullScreenContainer.vue";
import {onMounted, ref} from "vue";
import axios from "@/api/axios.ts";
import type {ProductModel, CategoryModel} from "@/types/Models.ts";
import {ManageEndpoints} from "@/enums/ManageEndpoints.ts";
import {defineColumns} from "@/composables/typeHelper.ts";
import {Severity} from "@/enums/Severity.ts";
import {ButtonLabel} from "@/enums/ButtonLabel.ts";
import {PrimeIcons} from '@primevue/core/api';
import Button from 'primevue/button';

const productList = ref<ProductModel[]>([]);
const categories = ref<CategoryModel[]>([]);
const selectedCategoryId = ref<number | null>(null);
const isLoading = ref(true);

const columnConfig = defineColumns<ProductModel>(
    {field: 'id', header: 'Id', hidden: true},
    {field: 'name', header: 'Name'},
    {field: 'price', header: 'Price'},
    {field: 'stock', header: 'Stock'},
    {field: 'productStatus', header: 'Status'},
    {field: 'expirationDate', header: 'Expiry Date', hidden: true},
    {field: 'createdOn', header: 'Created On', hidden: true},
    {field: 'lastModifiedOn', header: 'Last Modified', hidden: true},
    {
      field: 'id', header: 'Actions', actions: [
        {
          label: ButtonLabel.ViewDetails,
          icon: PrimeIcons.EYE,
          severity: Severity.SUCCESS,
          action: (product: ProductModel) => {
            console.log('Viewing details for:', product);
          }
        },
        {
          label: ButtonLabel.Edit,
          icon: PrimeIcons.PENCIL,
          severity: Severity.INFO,
          action: (product: ProductModel) => {
            console.log('Editing product:', product);
          }
        },
        {
          label: ButtonLabel.Delete,
          icon: PrimeIcons.TRASH,
          severity: Severity.DANGER,
          action: (product: ProductModel) => {
            console.log('Deleting product:', product);
            if (confirm(`Are you sure you want to delete ${product.name}?`)) {
              // Perform delete action
            }
          }
        }
      ]
    }
);

const createSkeletonData = (): ProductModel[] => {
  return Array.from({length: 5}, (_, index) => ({
    id: `skeleton-${index}`,
    name: '',
    price: 0,
    stock: 0,
    productStatus: '',
    expirationDate: new Date(),
    createdOn: new Date(),
    lastModifiedOn: new Date(),
    createdBy: '',
    lastModifiedBy: ''
  })) as ProductModel[];
};

const fetchAllCategories = async (): Promise<void> => {
  try {
    const response = await axios.get<CategoryModel[]>(ManageEndpoints.GetAllCategories);
    categories.value = response.data;
  } catch (error) {
    console.log('Error fetching categories:', error);
  }
};

const fetchAllProductsForCategory = async (categoryId: number): Promise<void> => {
  try {
    isLoading.value = true;
    selectedCategoryId.value = categoryId;
    const response = await axios.get<ProductModel[]>(`${ManageEndpoints.GetAllProductsForCategory}/${categoryId}`);
    productList.value = response.data;
  } catch (error) {
    console.log('Error fetching products:', error);
  } finally {
    isLoading.value = false;
  }
};

onMounted(async () => {
  await fetchAllCategories();
  if (categories.value.length > 0) {
    await fetchAllProductsForCategory(categories.value[0].id);
  }
});
</script>

<template>
  <FullScreenContainer>
    <template #title>Manage Shop Products</template>
    <template #body>
      <!-- Category Buttons -->
      <div class="mb-4 flex flex-wrap gap-2">
        <Button
          v-for="category in categories"
          :key="category.id"
          :label="category.name"
          :severity="selectedCategoryId === category.id ? 'info' : 'secondary'"
          @click="fetchAllProductsForCategory(category.id)"
          class="mb-2"
        />
      </div>
      
      <!-- Products Table -->
      <GenericDataTable
          :data="isLoading ? createSkeletonData() : productList"
          :columns="columnConfig"
          :is-loading="isLoading"
      />
    </template>
  </FullScreenContainer>
</template>