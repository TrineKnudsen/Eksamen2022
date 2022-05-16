import type {Citizen} from "@/models/Citizen";
import http from "./http.client";
import type {CitizenList} from "@/models/CitizenList";

export class CitizenService {


    async getCitizen(): Promise<Citizen[]> {
        const res = await http.get<Citizen[]>("/api/Citizen")
        return res.data;
    }
}