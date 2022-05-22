import http from "./http.client"
import type {GeneralInfo} from "@/models/GeneralInfo";


export class GeneralInfoService {
    async getGeneralByCitizen(citizenId: string): Promise<GeneralInfo[]> {
        const res = await http.get<GeneralInfo[]>("/api/GeneralInfo/" + citizenId);
        return res.data;
    }

    async saveGeneral(generalToUpdate: string, updatedText: string): Promise<GeneralInfo> {
        const res = await http.put<GeneralInfo>("/api/GeneralInfo/"+generalToUpdate, {
            text: updatedText
        });
        console.log(updatedText);
        console.log(generalToUpdate);
        return res.data;
    }
}