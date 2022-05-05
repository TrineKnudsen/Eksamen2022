using System.Collections.Generic;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BackEnd.Core.IServices
{
    public interface ICitizenService
    {
        List<Citizen> GetAllCitizens();

        Citizen CreateCitizen(Citizen citizen);
    }
}