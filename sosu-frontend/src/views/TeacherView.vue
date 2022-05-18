<template>

  <div>
    <button style="margin-left: 1%; margin-bottom: 1%" @click="$router.push('/laerer/nyborger')" type="button" class="btn btn-outline-success">Ny borger</button><span></span>
    <button style="margin-bottom: 1%; margin-left: 1%" type="button" class="btn btn-outline-danger">Slet borger</button>
  </div>

  <div style="background: cornflowerblue; padding: 1rem; border-radius: 0.3rem">
    <select id="selectC" class="browser-default custom-select custom-select-lg mb-3" @change="getCaseOps($event), getGenerals($event), getFunctionals($event)">
      <option>Vælg en borger</option>
      <option v-for="(c) in citizens" :value="c.id"> {{c.navn}} | {{c.alder}}</option>
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
        <textarea class="form-control" rows="2" v-text="c.fritekst"></textarea>
      </div>
    </div>
  </div>
  </div>

  <div>
    <div style="width: 50%" class="collapse" id="collapse-generals">
      <div v-for="g in generals" class="card card-body">
        <div>
          <a>{{g.emne}}</a>
          <b-button pill variant="outline-info" data-toggle="tooltip">?</b-button>
          <textarea class="form-control" rows="2" v-text="g.tekst"></textarea>
        </div>
      </div>
    </div>
  </div>

  <div style="width: 50%" >
    <b-collapse id="collapse-functionals" class="mt-2" >
      <b-card v-for="f in functionals">
        <p class="card-text">
          <b-button v-b-toggle.collapse-func-inner size="sm">{{f.emne}}</b-button>
          <b-collapse id="collapse-func-inner" class="mt-2">
            <b-card>{{f.subreading}}</b-card>
          </b-collapse>
        </p>
      </b-card>
    </b-collapse>
  </div>



  <div id="buttons">

  <button type="button" class="btn btn-outline-success">Opdater sagsoplysninger</button>
     |
    <button @click="$router.push('/laerer/nysag')" type="button" class="btn btn-outline-success">Ny sagsåbning</button>
    <button type="button" class="btn btn-outline-success">Rediger sag</button>
    <button type="button" class="btn btn-outline-danger">Slet sag</button>
  </div>

  <div id="student">
  <b-form-group label="Vælg Elever:" v-slot="{ ariaDescribedby }">
    <b-form-checkbox-group
        id="checkbox-group-2"
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
  let selectedC: null;

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

  async function getFunctionals(event: { target: { value: string; }; }){
    let functionalState = await functionalStateService.getFunctionalStateByCitizen(event.target.value);
    functionals.value = functionalState;
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