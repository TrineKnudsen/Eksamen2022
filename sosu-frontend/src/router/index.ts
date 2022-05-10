import { createRouter, createWebHistory } from "vue-router";
import TeacherView from "../views/TeacherView.vue";
import StudentView from "../views/StudentView.vue";
import LoginView from "../views/LoginView.vue";
import NewCitizenView from "../views/NewCitizenView.vue"
import NewCaseView from "../views/NewCaseView.vue"
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/laerer",
      name: "forTeachers",
      component: TeacherView,
    },
    {
      path: "/elev",
      name: "forStudents",
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: StudentView,
    },
    {
      path: "/login",
      name: "login",
      component: LoginView,
    },
    {
      path: "/laerer/nyborger",
      name: "nyborger",
      component: NewCitizenView,
    },
    {
      path: "/laerer/nysag",
      name: "nysag",
      component: NewCaseView,
    },
  ],
});

export default router;
