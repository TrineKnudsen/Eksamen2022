import type {Citizen} from "@/models/Citizen";
import http from "http";
import type {CitizenList} from "@/models/CitizenList";

export class CitizenService {


    async getTeachers(): Promise<CitizenList> {
        const res = await http.get<CitizenList>("/Citizen")
        return res.data;
    }
}