<template>

  <div>
    <button style="margin-left: 1%; margin-bottom: 1%" @click="$router.push('/laerer/nyborger')" type="button" class="btn btn-outline-success">Ny borger</button><span></span>
    <button style="margin-bottom: 1%; margin-left: 1%" type="button" class="btn btn-outline-danger">Slet borger</button>
  </div>

  <div style="background: cornflowerblue; padding: 1rem; border-radius: 0.3rem">
    <select id="selectC" class="browser-default custom-select custom-select-lg mb-3" v-model="selectedC" @change="getCaseOps($event), getGenerals($event), getFunctionals($event)">
      <option>Vælg en borger</option>
      <option v-for="(c) in citizens" :value="c.id"> {{c.name}} | {{c.age}}</option>
    </select>
  </div>

  <p>
    <button style="width: 20%; margin-left: 2%; margin-top: 1%" class="btn btn-default; border-dark" type="button"
            data-bs-toggle="collapse" data-bs-target="#collapse-cases">Sager</button>

    <button style="width: 20%; margin-left: 2%; margin-top: 1%" class="btn btn-default; border-dark" type="button"
            data-bs-toggle="collapse" data-bs-target="#collapse-generals">Generelle oplysninger</button>

    <button style="width: 20%; margin-left: 2%; background-color: yellow; margin-top: 1%;" class="btn btn default; border-dark" type="button"
            data-bs-toggle="collapse" data-bs-target="#collapse-functionals">Funktionsevnetilstand</button>

    <button style="width: 20%; background-color: cornflowerblue; margin-left: 2%; margin-top: 1%" class="btn btn-default; border-dark" type="button"
            data-bs-toggle="collapse" data-bs-target="#collapse-healthCon">Helbredstilstand</button>
  </p>

  <div>
  <div style="width: 50%" class="collapse" id="collapse-cases">
    <div v-for="c in caseOps" class="card card-body">
      <div>
        <a>Fritekst</a>
        <textarea class="form-control" rows="2" v-text="c.summary"></textarea>
      </div>
    </div>
  </div>
  </div>

  <div>
    <div style="width: 50%" class="collapse" id="collapse-generals">
      <div v-for="(g) in generals" class="card card-body">
        <div>
          <a>{{g.subject}}</a>
          <b-button pill variant="outline-info" data-toggle="tooltip">?</b-button>
          <textarea class="form-control" rows="2" v-text="g.text"></textarea>
          <button style="margin-left: 70%; margin-top: 1%" type="button" class="btn btn-success" @click="updateGeneral({selectedC, g})">Gem {{g.subject}}</button>
        </div>
      </div>
    </div>
  </div>

  <div style="width: 50%; border-color:yellow" >
    <b-collapse id="collapse-functionals" class="mt-2" >
      <b-card v-for="f in functionals">
        <p class="card-text">
          <b-button v-b-toggle.collapse-func-inner size="sm">{{f.emne}}</b-button>
          <b-collapse id="collapse-func-inner" class="mt-2">
            <b-card><b-button>{{f.subreading}}</b-button></b-card>
          </b-collapse>
        </p>
      </b-card>
    </b-collapse>
  </div>

  <div id="buttons">

  <button type="button" class="btn btn-outline-success">Opdater sagsoplysninger</button>
     |
    <button @click="$router.push('/laerer/nysag/' + selectedC)" type="button" class="btn btn-outline-success">Ny sagsåbning</button>
    <button type="button" class="btn btn-outline-success">Rediger sag</button>
    <button type="button" class="btn btn-outline-danger">Slet sag</button>
  </div>


  Valgt borger: <strong>{{ selectedC }}</strong>

</template>

<script setup lang="ts">
  import {CitizenService} from "@/services/CitizenService"
  import type {Ref} from "vue";
  import type {Citizen} from "@/models/Citizen";
  import {ref} from "vue";
  import type {CaseOpening} from "@/models/CaseOpening";
  import {CaseOpeningService} from "@/services/CaseOpeningService";
  import {GeneralInfoService} from "@/services/GeneralInfoService";
  import type {GeneralInfo} from "@/models/GeneralInfo";
  import type {FunctionalState} from "@/models/FunctionalState";
  import {FunctionalStateService} from "@/services/FunctionalStateService";
  const citizenService = new CitizenService();
  const caseOpeningService = new CaseOpeningService();
  const generalInfoService = new GeneralInfoService();
  const functionalStateService = new FunctionalStateService();

  let selectedC: "";
  let citizens: Ref<Citizen[]> = ref([]);
  let caseOps: Ref<CaseOpening[]> = ref([]);
  let generals: Ref<GeneralInfo[]> = ref([]);
  let functionals: Ref<FunctionalState[]> = ref([]);

  citizenService.getCitizen().then(obj => {
    citizens.value = obj;
  })

  async function getCaseOps(event: { target: { value: string; }; }) {
    let caseops = await caseOpeningService.getCaseOpeningByCitizen(event.target.value);
    caseOps.value = caseops;
  }

  async function getGenerals(event: { target: { value: string; }; }) {
    let generalInfo = await  generalInfoService.getGeneralByCitizen(event.target.value);
    generals.value = generalInfo;
  }

  async function saveGeneral(selectedCitizen: string, general: GeneralInfo){
    generalInfoService.saveGeneral(selectedCitizen, general);
  }

  async function getFunctionals(event: { target: { value: string; }; }){
    let functionalState = await functionalStateService.getFunctionalStateByCitizen(event.target.value);
    functionals.value = functionalState;
  }

  async function openSub(){
    document.getElementById("subDialog");
  }

</script>

<style scoped>
#containerlist {
  width:50%;
}
#caselist {
  float:left;
  width:25%;
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

#selectC {
  width: 100%;
  text-align: center;
}


</style>