
import http from "@/services/http.client";
import type {CaseOpening} from "@/models/CaseOpening";

export class CaseOpeningService {

    async createCaseOpening(citizenId: string,
                            reference: string,
                            text: string):
        Promise<CaseOpening> {
        const res = await http.post<CaseOpening>("/api/CaseOpening", {
            citizenId: citizenId,
            reference: reference,
            summary: text
        });
        return res.data;
    }

    async getCaseOpeningByCitizen(citizenId: string): Promise<CaseOpening[]> {
        const res = await http.get<CaseOpening[]>("/api/CaseOpening/"+citizenId)
        return res.data;
    }

    async deleteCaseOpening(coToDelete: string): Promise<CaseOpening> {
        const res = await http.delete<CaseOpening>("api/CaseOpening/"+coToDelete);
        return res.data;
    }
}