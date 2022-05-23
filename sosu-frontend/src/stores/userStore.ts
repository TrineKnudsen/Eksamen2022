import {defineStore} from "pinia";
import type {User} from "@/models/User";
import {UserService} from "@/services/user.service";

const userService: UserService = new UserService();

export const UserStore = defineStore({
    id: "userStore",
    state: () => ({
        loggedInUser: {name: "", uuid: ""} as User,
        foundUser: {name: "", uuid: ""} as User,
    }),
    getters: {
        username: (state) => {
            if (state.loggedInUser.name != undefined) return state.loggedInUser.name;
            else return "";
        },
        uuid: (state) => {
            if (state.loggedInUser.name != undefined) return state.loggedInUser.uuid;
        },
    },
    actions: {
        login(email:string,password:string) {
            userService
                .login(email,password)
                .then((user) => (this.loggedInUser =user))
                .catch((err) => console.log(err));
        },
        logout(){
        }
    },
});