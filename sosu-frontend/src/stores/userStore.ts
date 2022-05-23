import {defineStore} from "pinia";
import type {User} from "@/models/User";
import {UserService} from "@/services/user.service";

const userService: UserService = new UserService();

export const UserStore = defineStore({
    id: "userStore",
    state: () => ({
        loggedInUser: {email: "", id: ""} as User,
    }),
    getters: {
        username: (state) => {
            if (state.loggedInUser.email != undefined) return state.loggedInUser.email;
            else return "";
        },
        id: (state) => {
            if (state.loggedInUser.id != undefined) return state.loggedInUser.id;
        },
    },
    actions: {
        loginUser(email:string,password:string) {
            userService
                .login(email,password)
                .then((user) => (this.loggedInUser =user))
                .catch((err) => console.log(err));
        },
        logout(){
        }
    },
});