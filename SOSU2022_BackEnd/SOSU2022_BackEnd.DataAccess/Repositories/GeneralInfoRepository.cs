using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BackEnd.DataAcces.Repositories
{
    public class GeneralInfoRepository : IGeneralInfoRepository
    {
        private readonly IMongoCollection<GeneralInfo> _generals;
        
        public GeneralInfoRepository(ICitizenDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb+srv://Eksamen2022:UUTu4zvESzEUcL9k@cluster0.oowmj.mongodb.net/SOSU2022?retryWrites=true&w=majority");
            var db = client.GetDatabase("SOSU2022");

            _generals = db.GetCollection<GeneralInfo>("Sagsoplysninger");
        }
        
        public List<GeneralInfo> GetByCitizen(string citizenId)
        {
            return _generals
                .Find(generals => generals.BorgerId == new ObjectId(citizenId) && generals.Overemne == "Generelle_oplysninger").ToList();
        }
    }
}