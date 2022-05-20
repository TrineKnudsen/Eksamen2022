
import http from "@/services/http.client";
import type {CaseOpening} from "@/models/CaseOpening";

export class CaseOpeningService {

    async createCaseOpening(citizenId: string,
                            text: string,
                            reference: string):
        Promise<CaseOpening> {
        const res = await http.post<CaseOpening>("/api/CaseOpening", {
            CitizenId: citizenId,
            Reference: reference,
            Summary: text
        });
        return res.data;
    }

    async getCaseOpeningByCitizen(citizenId: string): Promise<CaseOpening[]> {
        console.log(citizenId);
        const res = await http.get<CaseOpening[]>("/api/CaseOpening/"+citizenId)
        return res.data;
    }
}