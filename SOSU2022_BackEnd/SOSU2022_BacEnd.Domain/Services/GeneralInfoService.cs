using System.Collections.Generic;
using System.IO;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BacEnd.Domain.Services
{
    public class GeneralInfoService : IGeneralInfoService
    {
        private readonly IGeneralInfoRepository _repo;

        public GeneralInfoService(IGeneralInfoRepository repo)
        {
            _repo = repo ?? throw new InvalidDataException();
        }
        
        public List<GeneralInfo> GetByCitizen(string citizenId)
        {
            return _repo.GetByCitizen(citizenId);
        }
    }
}