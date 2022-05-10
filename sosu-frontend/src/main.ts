import { createApp } from "vue";
import { createPinia } from "pinia";
import BootstrapVue3 from 'bootstrap-vue-3'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue-3/dist/bootstrap-vue-3.css'
import App from "./App.vue";
import router from "./router";
import * as ModalDialogs from "vue-modal-dialogs";

const app = createApp(App).use(BootstrapVue3).use(ModalDialogs);
app.use(createPinia());
app.use(router);
app.mount("#app");