<template>
  <blockquote class="blockquote text-center">
    <p class="mb-0">Ny sag</p>
  </blockquote>

  <form>
    <div class="form-row">
      <div class="form-row">
        <label>Beskriv hændelsen</label>
        <textarea v-model="text" class="form-control" rows="3"></textarea>
      </div>
      <div class="form-row">
        <label>Hvem retter henvendelse?</label>
        <textarea v-model="reference" class="form-control" rows="3"></textarea>
      </div>
    <button @click="saveCaseOpening()" type="submit" class="btn btn-primary">Gem sag</button>
    </div>
  </form>

  <div>

  </div>
  {{text}}
  {{reference}}
  {{citizen}}
</template>

<script setup lang="ts">
import {ref} from "vue";
import {CaseOpeningService} from "@/services/CaseOpeningService";

const caseOpeningService = new CaseOpeningService();
let text = "";
let reference = "";
let citizen ="";

function saveCaseOpening(this: any){
  citizen = this.href.substring(this.href.lastIndexOf("/")+1)

  console.log(citizen);
  console.log(text);
  console.log(reference);
  caseOpeningService.createCaseOpening(citizen, text, reference);
}

</script>

<style scoped>

</style>