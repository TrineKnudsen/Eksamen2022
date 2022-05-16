using System.Collections.Generic;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BacEnd.Domain.IRepositories
{
    public interface ICitizenRepository
    {
        List<Citizen> GetCitizens();
        Citizen CreateCitizen(Citizen citizen);
        Citizen Update(string citizenToUpdate, Citizen updatedCitizen);
        void Delete(string citizenToDelete);
    }
}