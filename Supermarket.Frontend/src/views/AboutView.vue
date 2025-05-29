<script setup lang="ts">
import {ref} from "vue";
import LargeTextContainer from "@/components/containers/LargeTextContainer.vue";
import ParagraphContainer from "@/components/containers/ParagraphContainer.vue";
import BlueCard from "@/components/card/BlueCard.vue";

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
          <div class="grid md:grid-cols-2 gap-6">
            <BlueCard v-for="commitment in commitments">
              <template #title>{{commitment.title}}</template>
              <template #body>{{commitment.body}}</template>
            </BlueCard>
          </div>
        </template>
      </ParagraphContainer>
      
      <ParagraphContainer>
        <template #title>Our Personnel</template>
        <template #body>
          Our staff consists of both augmented specialists and natural humans, all vetted and compliance-tagged for your security.
          All food handlers undergo weekly decontamination and are certified free of prohibited genetic modifications.
          
          <div class="flex flex-wrap justify-center gap-6 mt-6">
            <div class="text-center" v-for="member in teamMembers" :key="member.id">
              <div class="w-30 h-50 rounded-2xl bg-gray-800 mx-auto mb-2 overflow-hidden border border-cyan-700">
                <img :src="member.photo" :alt="member.name" class="w-full h-full object-cover filter saturate-50">
              </div>
              <h3 class="font-medium">{{ member.name }}</h3>
              <p class="text-sm text-gray-400">{{ member.role }}</p>
              <p class="text-xs text-cyan-600">ID: {{ member.id }}</p>
            </div>
          </div>
        </template>
      </ParagraphContainer>
      
      <ParagraphContainer>
        <template #title>Access Information</template>
        <template #body>
          <div class="bg-gray-900 p-6 rounded-lg border border-cyan-800">
            <div class="flex flex-col md:flex-row gap-6">
              <div class="flex-1">
                <h3 class="text-xl font-medium text-cyan-300 mb-2">Location</h3>
                <p>Sector 7, Level B3<br>Megastructure Block 4592<br>Neo-Tokyo District</p>
                <h3 class="text-xl font-medium text-cyan-300 mt-4 mb-2">Operating Hours</h3>
                <p>Cycle 1-5: 0600-2300<br>Cycle 6: 0800-2000<br>Closed during Purification Day</p>
                <h3 class="text-xl font-medium text-cyan-300 mt-4 mb-2">Communication</h3>
                <p>InfoNet: NT-FOODCUBE-7B3<br>EmergencyBeacon: 7B3-FC-EMERGENCY<br>Messenger Drone Dock: #FC-45921</p>
              </div>
              <div class="flex-1">
                <div class="h-64 bg-gray-800 rounded-lg border border-cyan-800 overflow-hidden">
                  <div class="w-full h-full flex items-center justify-center">
                    <div class="text-center">
                      <p class="text-cyan-500 mb-2">[ AUTHORIZED HOLO-MAP ]</p>
                      <p class="text-xs text-gray-400">Scan citizen implant for navigation assistance</p>
                      <p class="text-xs text-gray-400 mt-4">*Unauthorized reproduction of this location data is punishable under Security Act 9218-Ω</p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="mt-6 pt-4 border-t border-gray-700">
              <p class="text-amber-500 text-sm">⚠ ALERT: Sector 7 air filtration operating at reduced capacity (74%). Breathing apparatus recommended for non-augmented customers.</p>
            </div>
          </div>
        </template>
      </ParagraphContainer>
    </template>
  </LargeTextContainer>
</template>
