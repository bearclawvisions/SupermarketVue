<script setup lang="ts">
import LargeTextContainer from "@/components/containers/LargeTextContainer.vue";
import ParagraphContainer from "@/components/containers/ParagraphContainer.vue";
</script>

<template>
  <LargeTextContainer>
    <template #title>Privacy Policy for Supermarket App</template>
    <template #subtitle>Your privacy is safe with us</template>
    
    <template #body>
      <ParagraphContainer>
        <template #body>
          Welcome to our Supermarket App. We are committed to protecting your privacy and providing a safe and
          secure experience when using our services. This Privacy Policy explains how we collect, use, and safeguard your information.  
        </template>
      </ParagraphContainer>

      <ParagraphContainer>
        <template #title>Personal Information</template>
        <template #body>
          <ul>
            <li>- Name, email address, and phone number for account creation</li>
            <li>- Delivery address (if applicable)</li>
            <li>- Payment information (processed securely through our payment providers)</li>
          </ul>
        </template>
      </ParagraphContainer>

      <ParagraphContainer>
        <template #title>Usage Information</template>
        <template #body>
          <ul>
            <li>- Shopping habits and purchase history</li>
            <li>- App usage statistics and interactions</li>
            <li>- Device information (device type, operating system, app version)</li>
            <li>- Location data (with your permission, for store locator features)</li>
          </ul>
        </template>
      </ParagraphContainer>

      <ParagraphContainer>
        <template #title>How We Use Your Information</template>
        <template #body>
          <ul>
            <li>- To process your orders and transactions</li>
            <li>- To provide personalized shopping recommendations</li>
            <li>- To improve our services and app functionality</li>
            <li>- To communicate with you about orders, promotions, and updates</li>
            <li>- To manage our loyalty program and rewards</li>
          </ul>
        </template>
      </ParagraphContainer>

      <ParagraphContainer>
        <template #title>Data Sharing and Disclosure</template>
        <template #body>
          We may share your information with:
          <ul>
            <li>- Service providers who help us operate our business</li>
            <li>- Payment processors to complete transactions</li>
            <li>- Delivery partners (if applicable)</li>
            <li>- Legal authorities when required by law</li>
          </ul>
        </template>
      </ParagraphContainer>

      <ParagraphContainer>
        <template #title>Your Choices and Rights</template>
        <template #body>
          We do not sell your personal information to third parties. You have the right to:
          <ul>
            <li>- Access, correct, or delete your personal information</li>
            <li>- Opt out of marketing communications</li>
            <li>- Disable location tracking</li>
            <li>- Request a copy of your data</li>
          </ul>
        </template>
      </ParagraphContainer>

      <ParagraphContainer>
        <template #title>Data Security</template>
        <template #body>
          We implement appropriate technical and organizational measures to protect your personal information against unauthorized access, alteration, disclosure, or destruction.
        </template>
      </ParagraphContainer>

      <ParagraphContainer>
        <template #title>Children's Privacy</template>
        <template #body>
          Our services are not directed to children under 13. We do not knowingly collect personal information from children under 13.
        </template>
      </ParagraphContainer>

      <ParagraphContainer>
        <template #title>Changes to This Policy</template>
        <template #body>
          We may update this Privacy Policy periodically. We will notify you of any significant changes through the app or via email.
        </template>
      </ParagraphContainer>
    </template>
  </LargeTextContainer>

</template>