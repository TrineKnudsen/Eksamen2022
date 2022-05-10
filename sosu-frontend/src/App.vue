<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
import HelloWorld from "@/components/HelloWorld.vue";
</script>

<template>
  <nav>
    <RouterLink to="/">Velkommen</RouterLink> |
    <RouterLink to="/login">Login</RouterLink> |
    <RouterLink to="/laerer">For lærere</RouterLink> |
    <RouterLink to="/elev">For elever</RouterLink>
  </nav>
  <br />
  <RouterView />
</template>

<style>
</style>
