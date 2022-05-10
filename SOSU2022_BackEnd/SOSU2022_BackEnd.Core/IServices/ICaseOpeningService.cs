using System.Collections.Generic;
using SOSU2022_BacEnd.Domain.IRepositories;

namespace SOSU2022_BackEnd.Core.IServices
{
    public interface ICaseOpeningService
    {
        List<CaseOpening> GetAll();
    }
}