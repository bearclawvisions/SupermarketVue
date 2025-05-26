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
          secure experience when using our services. This Privacy Policy explains how we collect, use, and safeguard your information.
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Personal Information</h3>
          <ul>
            <li>- Name, email address, and phone number for account creation</li>
            <li>- Delivery address (if applicable)</li>
            <li>- Payment information (processed securely through our payment providers)</li>
          </ul>
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Usage Information</h3>
          <ul>
            <li>- Shopping habits and purchase history</li>
            <li>- App usage statistics and interactions</li>
            <li>- Device information (device type, operating system, app version)</li>
            <li>- Location data (with your permission, for store locator features)</li>
          </ul>
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">How We Use Your Information</h3>
          <ul>
            <li>- To process your orders and transactions</li>
            <li>- To provide personalized shopping recommendations</li>
            <li>- To improve our services and app functionality</li>
            <li>- To communicate with you about orders, promotions, and updates</li>
            <li>- To manage our loyalty program and rewards</li>
          </ul>
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Data Sharing and Disclosure</h3>
          We may share your information with:
          <ul>
            <li>- Service providers who help us operate our business</li>
            <li>- Payment processors to complete transactions</li>
            <li>- Delivery partners (if applicable)</li>
            <li>- Legal authorities when required by law</li>
          </ul>
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Your Choices and Rights</h3>
          We do not sell your personal information to third parties. You have the right to:
          <ul>
            <li>- Access, correct, or delete your personal information</li>
            <li>- Opt out of marketing communications</li>
            <li>- Disable location tracking</li>
            <li>- Request a copy of your data</li>
          </ul>
        </div>

        <div class="large-text-content">
          <h3 class="large-text-heading">Data Security</h3>
          We implement appropriate technical and organizational measures to protect your personal information against unauthorized access, alteration, disclosure, or destruction.
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