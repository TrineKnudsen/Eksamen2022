using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace SOSU2022_BacEnd.Domain.IRepositories
{
    public interface ICaseOpeningRepository
    {
        List<CaseOpening> GetAll();
    }
}