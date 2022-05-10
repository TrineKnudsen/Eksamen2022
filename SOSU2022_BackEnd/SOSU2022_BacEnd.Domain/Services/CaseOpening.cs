using System.Collections.Generic;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.IServices;

namespace SOSU2022_BacEnd.Domain.Services
{
    public class CaseOpening : ICaseOpeningService
    {

        private readonly ICaseOpeningRepository _caseOpeningRepository;

        public ICaseOpeningService(ICaseOpeningRepository repo)
        {
            
        }
        public List<IRepositories.CaseOpening> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}