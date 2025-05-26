<script setup lang="ts">
import Panel from 'primevue/panel';
</script>

<template>
  <div class="large-text-container">
    <Panel>
      <template #header>
        <div>
        <span class="font-bold">
          Privacy Policy for Supermarket App
        </span>
        </div>
      </template>

      <template #default>
        <div class="large-text-content">
          Welcome to our Supermarket App. We are committed to protecting your privacy and providing a safe and
          secure experience when using our services. This Privacy Policy
          explains how we collect, use, and safeguard your information.
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Personal Information</h3>
          - Name, email address, and phone number for account creation
          - Delivery address (if applicable)
          - Payment information (processed securely through our payment providers)
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Usage Information</h3>
          - Shopping habits and purchase history
          - App usage statistics and interactions
          - Device information (device type, operating system, app version)
          - Location data (with your permission, for store locator features)
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">How We Use Your Information</h3>
          - To process your orders and transactions
          - To provide personalized shopping recommendations
          - To improve our services and app functionality
          - To communicate with you about orders, promotions, and updates
          - To manage our loyalty program and rewards
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Data Sharing and Disclosure</h3>
          We may share your information with:
          - Service providers who help us operate our business
          - Payment processors to complete transactions
          - Delivery partners (if applicable)
          - Legal authorities when required by law
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Your Choices and Rights</h3>
          We do not sell your personal information to third parties.
          You have the right to:
          - Access, correct, or delete your personal information
          - Opt out of marketing communications
          - Disable location tracking
          - Request a copy of your data
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Data Security</h3>
          We implement appropriate technical and organizational measures to protect your personal information against unauthorized access,
          alteration, disclosure, or destruction.
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Children's Privacy</h3>
          Our services are not directed to children under 13. We do not knowingly collect personal information from children under 13.
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Changes to This Policy</h3>
          We may update this Privacy Policy periodically. We will notify you of any significant changes through the app or via email.
        </div>

      </template>
    </Panel>
  </div>
</template>

<style scoped>

</style>