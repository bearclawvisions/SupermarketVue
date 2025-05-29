<script setup lang="ts">
import {ref} from "vue";
import LargeTextContainer from "@/components/containers/LargeTextContainer.vue";
import ParagraphContainer from "@/components/containers/ParagraphContainer.vue";
import PortraitContainer from "@/components/containers/PortraitContainer.vue";
import BlueCardContainer from "@/components/containers/BlueCardContainer.vue";
import AccessInfoComponent from "@/components/AccessInfoComponent.vue";

const teamMembers = ref([
  {
    id: 'NV-772-H',
    name: 'Haruto Nakamura',
    role: 'Facility Director (Aug-Class 2)',
    photo: 'src/assets/images/haruto.png'
  },
  {
    id: 'NV-985-N',
    name: 'Naomi Tanaka',
    role: 'Hydroponics Specialist',
    photo: 'src/assets/images/naomi.png'
  },
  {
    id: 'NV-440-R',
    name: 'RK-7 "Riku"',
    role: 'Security & Compliance',
    photo: 'src/assets/images/riku.png'
  },
  {
    id: 'NV-621-A',
    name: 'Akira Yoshida',
    role: 'Synthetic Food Engineer',
    photo: 'src/assets/images/akira.png'
  }
]);

const commitments = ref([
  {
    title: 'Clean Sustenance',
    body: 'All our lab-grown products are certified 98.7% toxin-free, exceeding government standards by 3.2%. Our underground hydroponics lab produces rare authentic vegetables with minimal radiation signatures.',
  },
  {
    title: 'Community Shield',
    body: 'Our reinforced walls provide refuge during routine air quality alerts and civil compliance sweeps. We maintain emergency rations for registered neighborhood residents.',
  },
  {
    title: 'Accessible Pricing',
    body: 'We accept all standard credits, corporation scrip, and approved cryptocurrencies. Multi-tier pricing ensures nutrition access across social strata in accordance with Ordinance 5529-B.',
  },
  {
    title: 'Resource Efficiency',
    body: 'Our water reclamation system operates at 94.6% efficiency. All packaging is processed into building materials or nutrition substrate for our insect protein cultivation chambers.',
  }
]);
</script>

<template>
  <LargeTextContainer>
    <template #title>About Neo-Vision Food Cube</template>
    <template #subtitle>Our secure nutrition facility located in Sector 7, Level B3 of the Megastructure</template>
    
    <template #body>
      <ParagraphContainer>
        <template #title>Our History</template>
        <template #body>
          <p>
            Welcome to Neo-Vision Food Cube, your authorized synthetic and organic nutrition provider since the Great Collapse of 2089.
            What began as an emergency ration distribution center has evolved into the sector's premier food acquisition hub,
            offering both corporate-approved nutrition modules and rare authentic organics.
          </p>
          <br/>
          <p>
            Founded by the Nakamura Collective during the Resource Wars, our facility remains one of the few independent
            nutrition centers not fully absorbed by the MegaCorp Conglomerate. We operate under special permit NK-42775,
            allowing us to serve citizens across all social credit tiers.
          </p>
        </template>
      </ParagraphContainer>

      <ParagraphContainer>
        <template #title>Our Commitment</template>
        <template #body>
          <BlueCardContainer :card-info="commitments"/>
        </template>
      </ParagraphContainer>
      
      <ParagraphContainer>
        <template #title>Our Personnel</template>
        <template #body>
          Our staff consists of both augmented specialists and natural humans, all vetted and compliance-tagged for your security.
          All food handlers undergo weekly decontamination and are certified free of prohibited genetic modifications.
          <PortraitContainer :portraits="teamMembers"/>
        </template>
      </ParagraphContainer>
      
      <ParagraphContainer>
        <template #title>Access Information</template>
        <template #body><AccessInfoComponent/></template>
      </ParagraphContainer>
    </template>
  </LargeTextContainer>
</template>
