<template>
  <form>
    <label for="defaultFormLoginEmailEx" class="grey-text">Din skole-mail</label>
    <input type="email" id="defaultFormLoginEmailEx" class="form-control" />
    <br />
    <label for="defaultFormLoginPasswordEx" class="grey-text">Dit password</label>
    <input type="password" id="defaultFormLoginPasswordEx" class="form-control" />
    <div class="text-center mt-4">
      <button class="btn btn-indigo" type="submit">Login</button>
    </div>
  </form>
</template>

<script>
export default {
  name: "LoginView"
}
</script>

<style scoped>

</style>