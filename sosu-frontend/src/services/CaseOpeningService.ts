
import http from "@/services/http.client";
import type {CaseOpening} from "@/models/CaseOpening";

export class CaseOpeningService {

    async getCaseOpeningByCitizen(citizenId: string): Promise<CaseOpening[]> {
        const res = await http.get<CaseOpening>("/api/CaseOpening/"+citizenId)
        return res.data;
    }
}