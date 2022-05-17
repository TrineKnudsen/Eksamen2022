using System.Collections.Generic;
using MongoDB.Bson;
using SOSU2022_BacEnd.Domain.IRepositories;

namespace SOSU2022_BackEnd.Core.IServices
{
    public interface ICaseOpeningService
    {
        CaseOpening Create(CaseOpening caseOpening);
        List<CaseOpening> GetAll();
        List<CaseOpening> GetByCitizen(string citizenId);
        CaseOpening Update(string idToUpdate, CaseOpening updatedCaseOpening);
        void Delete(string idToDelete);
    }
}