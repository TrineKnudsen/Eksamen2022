<template>
  <blockquote class="blockquote text-center">
    <p class="mb-0">Ny borger</p>
  </blockquote>

  <form>
    <div class="form-row">
      <div class="form-group col-md-6">
        <label for="firstname">Fornavn</label>
        <input type="text" class="form-control" id="firstname" placeholder="">
      </div>
      <div class="form-group col-md-6">
        <label for="lastname">Efternavn</label>
        <input type="text" class="form-control" id="lastname" placeholder="">
      </div>
    </div>
    <div class="form-group">
      <label for="inputAddress">Adresse</label>
      <input type="text" class="form-control" id="inputAddress" placeholder="">
    </div>
    <div class="form-group">
      <label for="inputAddress2">Postnummer</label>
      <input type="text" class="form-control" id="inputAddress2" placeholder="">
    </div>
    <div class="form-row">
      <div class="form-group col-md-6">
        <label for="inputCity">By</label>
        <input type="text" class="form-control" id="inputCity">
      </div>
    </div>
    <button @click="$router.push('/laerer')" type="submit" class="btn btn-primary">Gem borger</button>
  </form>
</template>

<script>
export default {
  name: "NewCitizenView"
}
</script>

<style scoped>

</style>