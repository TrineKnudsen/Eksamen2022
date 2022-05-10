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
      <b-list-group-item>Brækket hofte</b-list-group-item>
    </b-list-group>
  </div>

  <div id="student">
  <b-form-group label="Vælg Elever:" v-slot="{ ariaDescribedby }">
    <b-form-checkbox-group
        id="checkbox-group-2"
        v-model="selected"
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

<script>
export default {
  data() {
    return {
      selected: [], // Must be an array reference!
      options: [
        { text: 'Lea Sørensen', value: 'Lea Sørensen' },
        { text: 'Simon Jensen', value: 'Simon Jensen' },
        { text: 'Michelle Christensen', value: 'Michelle Christensen' },
        { text: 'Trine Jacobsen', value: 'Trine Jacobsen' }
      ]
    }
  }
}
</script>

<style scoped>
#containerlist {
  width:50%;
  background:black;
}
#list2 {
  float:left;
  width:49.9%;
}
#student {
  margin-top: 20%;
}
</style>