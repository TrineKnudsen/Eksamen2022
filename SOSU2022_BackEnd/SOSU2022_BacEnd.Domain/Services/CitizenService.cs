using System.Collections.Generic;
using System.IO;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BacEnd.Domain.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository _citizenRepository;

        public CitizenService(ICitizenRepository citizenRepository)
        {
            _citizenRepository = citizenRepository ?? throw new InvalidDataException("Repo cannot be null");
        }
        
        public List<Citizen> GetAllCitizens()
        {
            
            return _citizenRepository.GetCitizens();
        }

        public Citizen CreateCitizen(Citizen citizen)
        {
            return _citizenRepository.Create(citizen);
        }
        

        public Citizen Update(string idToUpdate, Citizen updatedCitizen)
        {
            return _citizenRepository.Update(idToUpdate, updatedCitizen);
        }

        public void Delete(string idToDelete)
        {
            _citizenRepository.Delete(idToDelete);
        }
    }
}