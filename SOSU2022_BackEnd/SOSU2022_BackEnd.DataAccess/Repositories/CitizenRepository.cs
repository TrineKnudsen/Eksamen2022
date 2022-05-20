using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        private readonly IMongoCollection<GeneralInformationDocument> _generals;

        public CitizenRepository(ICitizenDatabaseSettings settings)
        {
            _citizenConverter = new CitizenConverter();
            var client = new MongoClient("mongodb+srv://Eksamen2022:UUTu4zvESzEUcL9k@cluster0.oowmj.mongodb.net/SOSU2022?retryWrites=true&w=majority");
            var db = client.GetDatabase("SOSU2022");

            _citizens = db.GetCollection<CitizenDocument>("Borger");
            _generals = db.GetCollection<GeneralInformationDocument>("Generelle_oplysninger");
        }

        public Citizen Create(Citizen citizen)
        {
            var strArray = Array.Empty<string>();
            var documentToInsert = _citizenConverter.Convert(citizen);
            
            var citizenToReturn = _citizenConverter.Convert(documentToInsert);
            
            using var sr = new StreamReader(Directory.GetCurrentDirectory()+ "/Files/test.txt");
            while (sr.Peek() >=0)
            {
                var str = sr.ReadToEnd();
                strArray = str.Split(",");
            }
            _citizens.InsertOne(documentToInsert);
            var allDocs =_citizens.Find(citizenLastCreated => true)
                .SortByDescending(sort => sort._id).ToList();
            var lastCreated = allDocs[0];
            
            var generalDocToInsert = new GeneralInformationDocument
            {
                Emne = strArray[3],
                Tekst = strArray[5],
                BorgerId = lastCreated._id.ToString()
            };
            
            _generals.InsertOne(generalDocToInsert);

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
            var deletefilterdocs = Builders<GeneralInformationDocument>
                .Filter.Eq("BorgerId", value:citizenToDelete);
            
            var deleteFilter = Builders<CitizenDocument>.Filter.Eq("_id", new ObjectId(citizenToDelete));
            
            _generals.DeleteManyAsync(deletefilterdocs);
            _citizens.DeleteOne(deleteFilter);
        }
    }
}