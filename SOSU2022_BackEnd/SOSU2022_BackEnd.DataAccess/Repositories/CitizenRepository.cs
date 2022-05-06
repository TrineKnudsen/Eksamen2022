using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DataAcces.Entities;

namespace SOSU2022_BackEnd.DataAcces.Repositories
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly IMongoCollection<Citizen> _citizens;

        public CitizenRepository(ICitizenDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb+srv://Eksamen2022:UUTu4zvESzEUcL9k@cluster0.oowmj.mongodb.net/SOSU2022?retryWrites=true&w=majority");
            var db = client.GetDatabase("SOSU2022");

            _citizens = db.GetCollection<Citizen>("Borger");
        }
        
        public List<Citizen> GetCitizens()
        {
            return _citizens.Find(citizen => true).ToList();
        }
    }
}