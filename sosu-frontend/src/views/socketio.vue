<template>
  <div>
    <h1>Current Progress: {{ progress }}</h1>
  </div>
</template>

<script>
export default {
  name: "SocketIo",
  data: function () {
    return {
      progress: null,
    };
  },
  sockets: {
    connect() {
      console.log("client connected to server");
    },
    toClient(data) {
      console.log("Data received from .Net Core: ", data);
      this.progress = data;
    },
  },
};
</script>

<style scoped>

</style>