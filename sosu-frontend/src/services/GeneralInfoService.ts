import http from "./http.client"
import type {GeneralInfo} from "@/models/GeneralInfo";


export class GeneralInfoService {
    async getGeneralByCitizen(citizenId: string): Promise<GeneralInfo[]> {
        const res = await http.get<GeneralInfo[]>("/api/GeneralInfo/" + citizenId);
        return res.data;
    }
}