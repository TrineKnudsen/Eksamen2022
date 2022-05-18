using System.Collections.Generic;
using System.IO;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.Core.Models;


namespace SOSU2022_BacEnd.Domain.Services
{
    public class FunctionalStateService : IFunctionalStateService
    {
        private readonly IFunctionalStateRepository _repo;

        public FunctionalStateService(IFunctionalStateRepository repo)
        {
            _repo = repo ?? throw new InvalidDataException();
        }
        
        public List<FunctionalState> GetByCitizen(string citizenId)
        {
            return _repo.GetByCitizen(citizenId);
        }
    }
}