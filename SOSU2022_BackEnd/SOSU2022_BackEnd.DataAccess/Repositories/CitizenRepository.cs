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

        public Citizen CreateCitizen(Citizen citizen)
        {
            var ce = new CitizenEntity
            {
                Name = citizen.Navn,
                Age = citizen.Alder
            };
            
            _citizens.InsertOne(citizen);

            return new Citizen
            {
                Navn = ce.Name,
                Alder = ce.Age
            };
        }

        public Citizen Update(string citizenToUpdate, Citizen updatedCitizen)
        {
            var filter = Builders<Citizen>.Filter.Eq("_id", new ObjectId(citizenToUpdate));
            var update = Builders<Citizen>.Update
                .Set("Navn", updatedCitizen.Navn)
                .Set("Alder", updatedCitizen.Alder);
            
            _citizens.FindOneAndUpdate(filter, update);
            
            return updatedCitizen;
        }

        public void Delete(string citizenToDelete)
        {
            var deleteFilter = Builders<Citizen>.Filter.Eq("_id", new ObjectId(citizenToDelete));
            _citizens.DeleteMany(deleteFilter);
        }
    }
}