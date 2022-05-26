using System.Collections.Generic;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BacEnd.Domain.IRepositories
{
    public interface IFunctionalStateRepository
    {
        List<FunctionalState> GetByCitizen(string citizenId, string subject);
    }
}