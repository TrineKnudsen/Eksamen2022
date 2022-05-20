using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DataAcces.Converters;
using SOSU2022_BackEnd.DataAcces.Documents;

namespace SOSU2022_BackEnd.DataAcces.Repositories
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly IMongoCollection<CitizenDocument> _citizens;
        private readonly CitizenConverter _citizenConverter;

        public CitizenRepository(ICitizenDatabaseSettings settings)
        {
            _citizenConverter = new CitizenConverter();
            var client = new MongoClient("mongodb+srv://Eksamen2022:UUTu4zvESzEUcL9k@cluster0.oowmj.mongodb.net/SOSU2022?retryWrites=true&w=majority");
            var db = client.GetDatabase("SOSU2022");

            _citizens = db.GetCollection<CitizenDocument>("Borger");
        }

        public Citizen Create(Citizen citizen)
        {
            var documentToInsert = _citizenConverter.Convert(citizen);
            _citizens.InsertOne(documentToInsert);
            var citizenToReturn = _citizenConverter.Convert(documentToInsert);
            return citizenToReturn;
        }
        
        public List<Citizen> GetCitizens()
        {
            var documents = _citizens.Find(citizen => true).ToList();
            return documents.Select(document => _citizenConverter.Convert(document)).ToList();
        }

        public Citizen Update(string citizenToUpdate, Citizen updatedCitizen)
        {
            var filter = Builders<CitizenDocument>.Filter.Eq("_id", new ObjectId(citizenToUpdate));
            var update = Builders<CitizenDocument>.Update
                .Set("Navn", updatedCitizen.Name)
                .Set("Alder", updatedCitizen.Age);
            
            _citizens.FindOneAndUpdate(filter, update);
            
            return updatedCitizen;
        }

        public void Delete(string citizenToDelete)
        {
            var deleteFilter = Builders<CitizenDocument>.Filter.Eq("_id", new ObjectId(citizenToDelete));
            _citizens.DeleteOne(deleteFilter);
        }
    }
}