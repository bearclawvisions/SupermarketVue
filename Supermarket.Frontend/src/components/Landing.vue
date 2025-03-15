<script setup lang="ts">
// import { onMounted } from 'vue'
//
// const openReadmeInEditor = () => fetch('/__open-in-editor?file=README.md')
//
//
// const fetchData = async () => {
//   debugger;
//   try {
//     const response = await fetch('https://localhost:7296/WeatherForecast'); // Example API
//     if (!response.ok) {
//       throw new Error('Network response was not ok');
//     }
//     const jsonData = await response.json();
//     console.log(jsonData);
//   } catch (err) {
//     // error.value = `Error: ${err.message}`; // Handle errors
//     // console.error(err.message);
//   } finally {
//     // loading.value = false; // Data loading is complete
//   }
// }
//
// onMounted(fetchData())
import Panel from "primevue/panel";

</script>

<template>
  <div class="basic-container">
    <Panel>
      <template #header>
        <div>
          <span class="pi pi-shopping-bag"/>
          <span class="font-bold"> Supermarket</span>
        </div>
      </template>
      <p>
        The place that has all your daily needs!
      </p>
    </Panel>
  </div>
  
  <div class="basic-container">
    <Panel header="Supermarket">
      <template #header>
        <div>
          <span class="font-bold"> Supermarket</span>
        </div>
      </template>
      <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore
        magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
        consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
        pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est
        laborum.
      </p>
    </Panel>
  </div>
  
</template>
