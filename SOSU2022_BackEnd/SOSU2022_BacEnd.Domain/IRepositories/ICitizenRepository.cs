using System.Collections.Generic;
using MongoDB.Bson;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BacEnd.Domain.IRepositories
{
    public interface ICitizenRepository
    {
        Citizen Create(Citizen citizen);
        List<Citizen> GetCitizens();
        Citizen Update(string citizenToUpdate, Citizen updatedCitizen);
        void Delete(string citizenToDelete);
    }
}