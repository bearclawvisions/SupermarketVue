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
import Button from "primevue/button";

</script>

<template>
  <h1>basic landing</h1>
  <Button label="test" />
</template>
