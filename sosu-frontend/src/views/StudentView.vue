<template>
  <div id="containerlist">
    <b-list-group id="list2">
      <b-list-group-item>Dorte Hansen</b-list-group-item>
      <b-list-group-item active>Robert Andersen</b-list-group-item>
      <b-list-group-item>Hanne Andersen</b-list-group-item>
      <b-list-group-item>Benny Larsen</b-list-group-item>
      <b-list-group-item>Margit Nielsen</b-list-group-item>
    </b-list-group>

    <b-list-group id="list2">
      <b-list-group-item active>Brækket hofte</b-list-group-item>
    </b-list-group>
  </div>
  v-b-toggle.collapse-generals
  <p>
    <button
      class="btn btn-default"
      type="button"
      data-bs-toggle="collapse"
      data-bs-target="#multicollapse"
      aria-controls="multicollapse"
      aria-expanded="false"
    >
      >Generelle oplysninger
    </button>

    <button class="btn btn-default" type="button" data-bs-toggle="collapse">
      >Helbredstilstande
    </button>

    <button class="btn btn-default" type="button" data-bs-toggle="collapse">
      >Funktionsevnetilstande
    </button>
  </p>

  <div class="col">
    <div class="collapse multi-collapse" id="multicollapse">
      <div class="card card-body">
        <div>
          <a>Mestring</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres, hvordan borgeren positivt eller negativt mestrer den modgang vedkommende møder."
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Motivation</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres borgerens ønsker for sit liv (overordnet mål), og hvad der motiverer borgeren."
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Ressourcer</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres de ressourcer, borgeren har i forhold til at løse dagligdagens opgaver. Det kan være både fysiske og mentale funktioner. "
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Roller</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres de roller, borgeren angiver at have. Det kan fx være rolle som ægtefælle, bedsteforælder eller aktiv i beboerforening"
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Vaner</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres borgerens vaner, som er en naturlig del af hverdagen, og som borgeren plejer at gøre. Det kan både være vaner, som borgeren gør af fysiske og psykiske årsager."
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Uddannelse og job</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres borgerens oplysninger om uddannelse og erhverv. Fx hvilke job borgeren har haft, hvilken betydning arbejdslivet har haft for borgeren, og har borgeren evt. stadig tilknytning til arbejdspladsen og kolleger"
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Livshistorie</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres borgerens fortælling om sit liv.
            Her dokumenteres borgerens ønsker for den sidste tid. "
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Netværk</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres borgerens netværk i bredere forstand."
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Helbredsoplysninger</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her kan borgerens sygdomme og handicap dokumenteres for at give et samlet overblik.
            Hvis oplysningen kommer fra borgeren eller pårørende, skal dette fremgå.
            Her kan behandlingsansvarlig læge/ambulatorie ift. en konkret sygdom dokumenteres, hvis dette ikke er angivet andre steder. "
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Hjælpemidler</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres de hjælpemidler borger selv har anskaffet.  Bevilligede hjælpemidler kan også dokumenteres eller vises her."
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
        <div>
          <a>Boligens indretning</a>
          <b-button
            pill
            variant="outline-info"
            data-toggle="tooltip"
            title="Her dokumenteres både det der hæmmer og fremmer borgerens funktionsevne i hverdagen.  Kan suppleres med praktiske oplysninger fx om der er elevator, dørtrin eller trapper. "
            >?</b-button
          >
          <textarea class="form-control" rows="2"></textarea>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
</script>

<style scoped>
#containerlist {
  width: 50%;
  background: black;
}
#list2 {
  float: left;
  width: 49.9%;
}

#buttons {
  margin-top: 20%;
}
</style>
