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
            var gDocs = new List<GeneralInformationDocument>();
            var documentToInsert = _citizenConverter.Convert(citizen);
            _citizens.InsertOne(documentToInsert);
            var citizenToReturn = _citizenConverter.Convert(documentToInsert);
            var generalDocToInsert1 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Mestring",
                Tekst = ""
            };
            var generalDocToInsert2 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Motivation",
                Tekst = ""
            };
            var generalDocToInsert11 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Ressourcer",
                Tekst = ""
            };
            var generalDocToInsert3 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Roller",
                Tekst = ""
            };
            var generalDocToInsert4 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Vaner",
                Tekst = ""
            };
            var generalDocToInsert5 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Udannelse_job",
                Tekst = ""
            };
            var generalDocToInsert6 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Livshistorie",
                Tekst = ""
            };
            var generalDocToInsert7 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Helbreds_oplysninger",
                Tekst = ""
            };
            var generalDocToInsert8 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Hjaelpemidler",
                Tekst = ""
            };
            var generalDocToInsert9 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Boligens_indretning",
                Tekst = ""
            };
            var generalDocToInsert10 = new GeneralInformationDocument
            {
                BorgerId = citizenToReturn.Id,
                Emne = "Netværk",
                Tekst = ""
            };
            gDocs.Add(generalDocToInsert1);
            gDocs.Add(generalDocToInsert2);
            gDocs.Add(generalDocToInsert3);
            gDocs.Add(generalDocToInsert4);
            gDocs.Add(generalDocToInsert5);
            gDocs.Add(generalDocToInsert6);
            gDocs.Add(generalDocToInsert7);
            gDocs.Add(generalDocToInsert8);
            gDocs.Add(generalDocToInsert9);
            gDocs.Add(generalDocToInsert10);
            gDocs.Add(generalDocToInsert11);
            _generals.InsertMany(gDocs);
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