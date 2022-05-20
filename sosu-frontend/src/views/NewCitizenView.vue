<template>
  <blockquote class="blockquote text-center">
    <p class="mb-0">Ny borger</p>
  </blockquote>

  <form>
    <div class="form-row">
      <div class="form-group col-md-6">
        <label for="firstname">Fornavn</label>
        <input v-model="name" type="text" class="form-control" id="firstname" placeholder="">
      </div>
    </div>

    <div class="form-row">
      <div class="form-group col-md-6">
        <label for="inputCity">Alder</label>
        <input v-model="age" type="text" class="form-control" id="inputCity">
      </div>
    </div>
    <button @click="saveCitizen" type="submit" class="btn btn-primary">Gem borger</button>
  </form>
</template>

<script setup lang="ts">
import {ref} from "vue";
import {CitizenService} from "@/services/CitizenService";

const citizenService = new CitizenService();
let name =ref("");
let age = ref("");

function saveCitizen(){
  citizenService.createCitizen(name.value, age.value)
}

</script>

<style scoped>

</style>