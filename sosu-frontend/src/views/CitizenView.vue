<template>

  <div class="p-5 text-center bg-light">
    <h4 class="mb-3">{{citizenStore.name}}</h4>
  </div>

  <header></header>

  <p>
    <button
        style="width: 20%; margin-left:40%; margin-top: 1%"
        type="button"
        class="btn btn-outline-success"
        data-bs-toggle="collapse"
        data-bs-target="#newcase"
    >
      Ny sag
    </button>


  </p>
  <div>
    <div style="width: 50%; margin-left:20%" class="collapse" id="newcase">
      <div class="card card-body">
        <div>
          <a>Hvem henvender sig?</a>
          <input
              v-model="reference"
              type="text"
              id="inputreference"
              class="form-control"
              rows="2"
          />
          <a>Beskriv hændelsen</a>
          <textarea
              v-model="text"
              type="text"
              id="inputtext"
              class="form-control"
              rows="20"
          />
          <button  style="margin-left: 80%; margin-top: 1%" class="btn btn-outline-success" @click="saveCase">Gem</button>
        </div>
      </div>
    </div>
  </div>


  <p>
    <button
        style="width: 20%; margin-left: 7%; margin-top: 1%"
        class="btn btn-default; border-dark"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#collapse-cases"
    >
      Sager
    </button>

    <button
        style="width: 20%; margin-left: 2%; margin-top: 1%"
        class="btn btn-default; border-dark"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#collapse-generals"
    >
      Generelle oplysninger
    </button>

    <button
        style="
        width: 20%;
        margin-left: 2%;
        background-color: yellow;
        margin-top: 1%;
      "
        class="btn btn default; border-dark"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#collapse-functionals"
    >
      Funktionsevnetilstand
    </button>

    <button
        style="
        width: 20%;
        background-color: cornflowerblue;
        margin-left: 2%;
        margin-top: 1%;
      "
        class="btn btn-default; border-dark"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#collapse-healthCon"
    >
      Helbredstilstand
    </button>
  </p>

  <div>
    <div style="width: 50%;margin-left: 7%" class="collapse" id="collapse-cases">
      <div v-for="(c) in caseOps" :key="c.id" class="card card-body">
        <div>
        <a>Fritekst</a>
        <textarea class="form-control" rows="2" v-text="c.summary"></textarea>
        <b-button @click="removeCase(c.id)">Fjern sag</b-button>
          </div>
      </div>
    </div>
  </div>

  <div>
    <div style="width: 50%;margin-left: 7%" class="collapse" id="collapse-generals">
      <div v-for="(g,index) in generals" :key="g.id" class="card card-body">
        <div>
          <a>{{ g.subject }}</a>
          <b-button pill variant="outline-info" data-toggle="tooltip"
          >?</b-button
          >
          <textarea type="text" v-text="g.text" id="updatetext" class="form-control" rows="2"></textarea>
          <button
              style="margin-left: 70%; margin-top: 1%"
              type="button"
              class="btn btn-success"
              @click="updateGeneral(g.id)"
          >
            Gem {{ g.subject }}
          </button>
        </div>
      </div>
    </div>
  </div>

  <div style="width: 50%; border-color: yellow;margin-left: 7%">
    <b-collapse id="collapse-functionals" class="mt-2">
      <b-card v-for="f in functionals">
        <p class="card-text">
          <b-button v-b-toggle.collapse-func-inner size="sm">{{
              f.subject
            }}</b-button>
          <b-collapse id="collapse-func-inner" class="mt-2">
            <b-card
            ><b-button>{{ f.subreading }}</b-button></b-card
            >
          </b-collapse>
        </p>
      </b-card>
    </b-collapse>
  </div>
</template>

<script setup lang="ts">
import {CitizenStore} from "@/stores/CitizenStore";
import {CitizenService} from "@/services/CitizenService";
import {CaseOpeningService} from "@/services/CaseOpeningService";
import {GeneralInfoService} from "@/services/GeneralInfoService";
import {FunctionalStateService} from "@/services/FunctionalStateService";
import {ref} from "vue";
import type {Ref} from "vue";
import type {CaseOpening} from "@/models/CaseOpening";
import type {GeneralInfo} from "@/models/GeneralInfo";
import type {FunctionalState} from "@/models/FunctionalState";

const citizenStore = new CitizenStore();
const citizenService = new CitizenService();
const caseOpeningService = new CaseOpeningService();
const generalInfoService = new GeneralInfoService();
const functionalStateService = new FunctionalStateService();

let text = ref("");
let reference = ref("");
let caseOps: Ref<CaseOpening[]> = ref([]);
let generals: Ref<GeneralInfo[]> = ref([]);
let functionals: Ref<FunctionalState[]> = ref([]);

caseOpeningService.getCaseOpeningByCitizen(citizenStore.selectedCitizen.id).then((obj) => {
  caseOps.value = obj;
})

generalInfoService.getGeneralByCitizen(citizenStore.id).then((obj) => {
  generals.value =obj;
})

functionalStateService.getFunctionalStateByCitizen(citizenStore.id).then((obj)=> {
  console.log(citizenStore.id)
  functionals.value.push(obj);
})

async function removeCase(caseToDelete: string, index: number) {
  await caseOpeningService.deleteCaseOpening(caseToDelete)
      .then(() => {
        caseOps.value.splice(index,1);
      });
}

async function saveCase() {
  await caseOpeningService.createCaseOpening(
      citizenStore.selectedCitizen.id,
      reference.value,
      text.value
  ).then((obj) => caseOps.value.push(obj));
}

async function updateGeneral(generalToUpdate: string) {
  await generalInfoService.saveGeneral(generalToUpdate, document.getElementById("updatetext").value);
}




</script>

<style scoped>
#containerlist {
  width: 50%;
}
#caselist {
  float: left;
  width: 25%;
  padding-left: 1%;
}

#student {
  margin-top: 5%;
}
#buttons {
  margin-top: 15%;
}

#toggles2 {
  margin-left: 30%;
}

#collapse-generals {
  width: 60%;
}
</style>