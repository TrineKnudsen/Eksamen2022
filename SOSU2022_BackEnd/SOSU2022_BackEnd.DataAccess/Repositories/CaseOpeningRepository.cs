using System.Collections.Generic;
using MongoDB.Driver;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BackEnd.DataAcces.Repositories
{
    public class CaseOpeningRepository : ICaseOpeningRepository
    {
        private readonly IMongoCollection<CaseOpening> _caseOpenings;

        public CaseOpeningRepository(ICitizenDatabaseSettings settings)
        {
            var client =
                new MongoClient(
                    "mongodb+srv://Eksamen2022:UUTu4zvESzEUcL9k@cluster0.oowmj.mongodb.net/SOSU2022?retryWrites=true&w=majority");
            var db = client.GetDatabase("CaseOpening");
        }
        
        public List<CaseOpening> GetAll()
        {
            return _caseOpenings.Find(caseOpening => true).ToList();
        }
    }
}