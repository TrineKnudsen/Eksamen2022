import {defineStore} from "pinia";
import type {Citizen} from "@/models/Citizen";

export const CitizenStore = defineStore({
    id: "CitizenStore",
    state: () => ({
        selectedCitizen: {id: "", name: ""} as Citizen,
    }),
    getters: {
        id: (state) => {
            if (state.selectedCitizen != undefined) return state.selectedCitizen.id;
            else return "";
        },
        name: (state) => {
            if (state.selectedCitizen != undefined) return state.selectedCitizen.name;
            else return "";
        },
    },
    actions: {
        setCitizen(citizen: Citizen){
            this.selectedCitizen = citizen;
        }
    }
});