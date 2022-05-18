import http from "./http.client"
import type {FunctionalState} from "@/models/FunctionalState";

export class FunctionalStateService {
    async getFunctionalStateByCitizen(citizenId: string): Promise<FunctionalState[]>{
        const res = await http.get<FunctionalState[]>("/api/FunctionalState/"+citizenId);
        return res.data;
    }
}