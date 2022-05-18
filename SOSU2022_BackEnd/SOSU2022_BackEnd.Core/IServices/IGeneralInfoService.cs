using System.Collections.Generic;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BackEnd.Core.IServices
{
    public interface IGeneralInfoService
    {
        List<GeneralInfo> GetByCitizen(string citizenId);
    }
}