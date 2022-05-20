<template>
  <blockquote class="blockquote text-center">
    <p class="mb-0">Ny sag</p>
  </blockquote>

  <form>
    <div class="form-row">
      <div class="form-row">
        <label>Beskriv hændelsen</label>
        <textarea class="form-control" rows="3"></textarea>
      </div>
      <div class="form-row">
        <label>Hvem retter henvendelse?</label>
        <textarea v-model="text" class="form-control" rows="3"></textarea>
      </div>
      <div>
        <label>BorgerId</label><textarea></textarea>
      </div>
    <button @click="saveCaseOpening" type="submit" class="btn btn-primary">Gem sag</button>
    </div>
  </form>
</template>

<script setup lang="ts">
import {ref} from "vue";
import {CaseOpeningService} from "@/services/CaseOpeningService";

const caseOpeningService = new CaseOpeningService();
let text = ref("");
let reference = ref("");
let citizenId = ref("");
let citizen:string = "";


function saveCaseOpening(this: any){
  citizen = this.href.substring(this.href.lastIndexOf("/")+1);
  console.log(citizen);
  caseOpeningService.createCaseOpening(citizen, text.value, reference.value);
}

</script>

<style scoped>

</style>