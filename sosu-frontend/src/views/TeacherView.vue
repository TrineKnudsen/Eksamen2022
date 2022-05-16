<template>
  
  <div id="containerlist">
    <b-list-group id="list2">
    <b-list-group-item href="#" class="flex-column align-items-start" v-for="c in citizens" v-bind:key="index">
      <div class="d-flex w-100 justify-content-between">
        <h6 class="mb-1">{{c.navn}}</h6>
        <h6 class="mb-1">{{c.alder}}</h6>
      </div>
    </b-list-group-item>

  </b-list-group>

    <b-list-group id="list2">
      <b-list-group-item>Brækket hofte</b-list-group-item>
    </b-list-group>
  </div>

  <div id="buttons">
  <button @click="$router.push('/laerer/nyborger')" type="button" class="btn btn-outline-success">Ny borger</button>
  <button type="button" class="btn btn-outline-success">Opdater sagsoplysninger</button>
    <button type="button" class="btn btn-outline-danger">Slet borger</button> |
    <button @click="$router.push('/laerer/nysag')" type="button" class="btn btn-outline-success">Ny sagsåbning</button>
    <button type="button" class="btn btn-outline-success">Rediger sag</button>
    <button type="button" class="btn btn-outline-danger">Slet sag</button>
  </div>

  <div id="student">
  <b-form-group label="Vælg Elever:" v-slot="{ ariaDescribedby }">
    <b-form-checkbox-group
        id="checkbox-group-2"
        v-model="selected"
        :aria-describedby="ariaDescribedby"
        name="flavour-2">
      <b-form-checkbox value="Lea Sørensen">Lea Sørensen</b-form-checkbox>
      <b-form-checkbox value="Simon Jensen">Simon Jensen</b-form-checkbox>
      <b-form-checkbox value="Michelle Christensen">Michelle Christensen</b-form-checkbox>
      <b-form-checkbox value="Trine Jacobsen">Trine Jacobsen</b-form-checkbox>
    </b-form-checkbox-group>
  </b-form-group>

  Valgte elever: <strong>{{ selected }}</strong>

  </div>
</template>

<script setup lang="ts">
  import {CitizenService} from "@/services/CitizenService"
  import type {Ref} from "vue";
  import type {Citizen} from "@/models/Citizen";
  import {ref} from "vue";
  const citizenService = new CitizenService();

  let citizens: Ref<Citizen[]> = ref([]);

  citizenService.getCitizen().then(obj => {
    citizens.value = obj;
  })

  async function getList(){
    return await citizenService.getCitizen();
  }
</script>

<style scoped>
#containerlist {
  width:50%;
}
#list2 {
  float:left;
  width:49.9%;
  padding-left: 10%;
}
#student {
  margin-top: 5%;
}
#buttons {
  margin-top: 15%;
}
</style>