<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <nav div id="navbar">
    <RouterLink id="link" to="/">Velkommen</RouterLink> |
    <RouterLink id="link" to="/login">Login</RouterLink> |
    <RouterLink id="link" to="/laerer">For lærere</RouterLink> |
    <RouterLink id="link" to="/elev">For elever</RouterLink>
  </nav>
  <br />
  <RouterView />
</template>

<style>
#navbar {
  background-color: cornflowerblue;
  padding-left: 2%;
  alignment: center;
  height: 50px;
  size: 20px;
}
#link {
  color: #f2f2f2;
}
</style>
