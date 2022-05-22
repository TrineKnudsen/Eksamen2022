using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace SOSU2022_BacEnd.Domain.IRepositories
{
    public interface ICaseOpeningRepository
    {
        CaseOpening Create(CaseOpening caseOpening);
        List<CaseOpening> GetAll();
        List<CaseOpening> GetByCitizen(string citizenId);
        CaseOpening Update(string caseToUpdate, CaseOpening updatedCaseOpening);
        CaseOpening Delete(string caseOpeningToDelete);
    }
}