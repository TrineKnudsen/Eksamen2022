using System.Collections.Generic;
using System.IO;
using MongoDB.Bson;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.IServices;

namespace SOSU2022_BacEnd.Domain.Services
{
    public class CaseOpeningService : ICaseOpeningService
    {
        private readonly ICaseOpeningRepository _repo;

        public CaseOpeningService(ICaseOpeningRepository repo)
        {
            _repo = repo ?? throw new InvalidDataException("Repo cannot be null");
        }
        
        public CaseOpening Create(CaseOpening caseOpening)
        {
            return _repo.Create(caseOpening);
        }

        public List<CaseOpening> GetAll()
        {
            return _repo.GetAll();
        }

        public List<CaseOpening> GetByCitizen(string citizenId)
        {
            return _repo.GetByCitizen(citizenId);
        }

        public CaseOpening Update(string idToUpdate, CaseOpening updatedCaseOpening)
        {
            return _repo.Update(idToUpdate, updatedCaseOpening);
        }

        public void Delete(string idToDelete)
        {
            _repo.Delete(idToDelete);
        }
    }
}