using System.Collections.Generic;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BacEnd.Domain.IRepositories
{
    public interface IGeneralInfoRepository
    {
        List<GeneralInfo> GetByCitizen(string citizenId);
        GeneralInfo UpdateGeneralInformation(string generalInfoToUpdate, GeneralInfo updatedGeneral);
    }
}