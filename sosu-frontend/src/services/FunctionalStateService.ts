import http from "./http.client"

export class FunctionalStateService {
    async getFunctionalStateByCitizen(citizenId: string): Promise<FunctionalState[]>{
        const res = await http.get<FunctionalState[]>("/api/FunctionalState/"+citizenId);
        return res.data;
    }
}