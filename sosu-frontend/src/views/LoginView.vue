<template>
  <form>
    <label for="defaultFormLoginEmailEx" class="grey-text">Din skole-mail</label>
    <input v-model="email" type="email" id="defaultFormLoginEmailEx" class="form-control" />
    <br />
    <label for="defaultFormLoginPasswordEx" class="grey-text">Dit password</label>
    <input v-model="password" type="password" id="defaultFormLoginPasswordEx" class="form-control" />
    <div class="text-center mt-4">
      <button @click="login" class="btn btn-indigo" type="submit">Login</button>
    </div>
  </form>
</template>

<script setup lang="ts">
import {ref} from "vue";
import {UserStore} from "@/stores/userStore";

const userStore = new UserStore();

let username = ref("");
let password = ref("");

function login(){
  userStore.login(username,password);
}


</script>

<style scoped>

</style>