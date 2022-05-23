<template>
  <div class="p-5 text-center bg-light">
    <h1 class="mb-3">SOSU fs3 læringsplatform</h1>
    <h4 class="mb-3"></h4>
    <a>Vælg en borger for for at se og redigere i sagsåbninger, sagsoplysning, funktionsevnetilstand og helbredstilstand</a>
  </div>

  <div style="background: cornflowerblue; padding: 1rem; border-radius: 0.3rem">
    <select
      id="selectC"
      class="browser-default custom-select custom-select-lg mb-3"
      v-model="selectedC"
      @change="setCitizen(selectedC)">
      <option>Vælg en borger</option>
      <option v-for="(c,key) in citizens" :value="c" v-bind:key="key" :key="c.id">
        {{ c.name }} | {{ c.age }}
      </option>
    </select>
  </div>

  <div>
    <button
        style="width: 20%; margin-left: 1%; margin-top: 1%;"
        @click="$router.push('/laerer/nyborger')"
        type="button"
        class="btn btn-outline-success">
      Ny borger
    </button>
    <button style="width: 45%; margin-left: 1%; margin-top: 1%" class="btn btn-outline-success"
            @click="$router.push('/sagsoplysning')">Gå til sagsåbninger, sagsoplysninger, funktionstilstand og helbredtilstand ⤑
    </button>
    <button style="width: 30%; margin-left: 1%; margin-top: 1%" class="btn btn-outline-danger"
                          @click="deleteCitizen(citizenStore.id,index)">Slet borger
    </button>
  </div>


</template>

<script setup lang="ts">
import {CitizenService} from "@/services/CitizenService";
import type {Ref} from "vue";
import {ref} from "vue";
import type {Citizen} from "@/models/Citizen";
import {CitizenStore} from "@/stores/CitizenStore";

const citizenService = new CitizenService();
const citizenStore = new CitizenStore();

let selectedC = ref();
let citizens: Ref<Citizen[]> = ref([]);

citizenService.getCitizen().then((obj) => {
  citizens.value = obj;
});

function setCitizen(citizen: Citizen){
  citizenStore.setCitizen(citizen);
}

async function deleteCitizen(citizenToDelete: string,index: number) {
  await citizenService.deleteCitizen(citizenToDelete)
  .then(() => {
    citizens.value.splice(index, 1);
  });
}

</script>

<style scoped>


#selectC {
  width: 100%;
  text-align: center;
}
</style>
