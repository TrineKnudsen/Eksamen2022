import type {Citizen} from "@/models/Citizen";
import http from "./http.client";
import type {CitizenList} from "@/models/CitizenList";

export class CitizenService {


    async getCitizen(): Promise<Citizen[]> {
        const res = await http.get<Citizen[]>("/api/Citizen")
        return res.data;
    }

    async createCitizen(name: string, age: string): Promise<Citizen> {
        const res = await http.post<Citizen>("/api/Citizen", {Name: name, Age: age})
        return res.data;
    }
}