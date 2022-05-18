using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BackEnd.DataAcces.Repositories
{
    public class FunctionalStateRepository : IFunctionalStateRepository
    {
        private readonly IMongoCollection<FunctionalState> _functionals;
        public FunctionalStateRepository()
        {
            var client = new MongoClient("mongodb+srv://Eksamen2022:UUTu4zvESzEUcL9k@cluster0.oowmj.mongodb.net/SOSU2022?retryWrites=true&w=majority");
            var db = client.GetDatabase("SOSU2022");

            _functionals = db.GetCollection<FunctionalState>("Sagsoplysninger");
        }
        
        
        public List<FunctionalState> GetByCitizen(string citizenId)
        {
            return _functionals
                .Find(functionals => functionals.BorgerId == new ObjectId(citizenId) && functionals.Overemne == "Funktionsevnetilstande").ToList();
        }
    }
}