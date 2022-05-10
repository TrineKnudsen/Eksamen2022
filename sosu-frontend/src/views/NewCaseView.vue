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
    <button @click="$router.push('/laerer')" type="submit" class="btn btn-primary">Gem sag</button>
    </div>
  </form>
</template>

<script>
export default {
  name: "NewCaseView"
}
</script>

<style scoped>

</style>