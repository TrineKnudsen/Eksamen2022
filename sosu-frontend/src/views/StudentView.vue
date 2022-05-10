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
        <b-list-group>
          <b-list-group-item>Mestring</b-list-group-item>
          <b-list-group-item>Motivation</b-list-group-item>
          <b-list-group-item>Ressourcer</b-list-group-item>
          <b-list-group-item>Roller</b-list-group-item>
          <b-list-group-item>Vaner</b-list-group-item>
          <b-list-group-item>Uddanelse og job</b-list-group-item>
          <b-list-group-item>Livshistorie</b-list-group-item>
          <b-list-group-item>Netværk</b-list-group-item>
          <b-list-group-item>Helbredsoplysninger</b-list-group-item>
          <b-list-group-item>Hjælpemidler</b-list-group-item>
          <b-list-group-item>Boligens indretning</b-list-group-item>
        </b-list-group>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
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
