using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DataAcces.Converters;
using SOSU2022_BackEnd.DataAcces.Documents;

namespace SOSU2022_BackEnd.DataAcces.Repositories
{
    public class CaseOpeningRepository : ICaseOpeningRepository
    {
        private readonly IMongoCollection<CaseOpeningDocument> _caseOpenings;
        private readonly CaseOpeningConverter _converter;

        public CaseOpeningRepository(ICitizenDatabaseSettings settings)
        {
            _converter = new CaseOpeningConverter();
            var client =
                new MongoClient(
                    "mongodb+srv://Eksamen2022:UUTu4zvESzEUcL9k@cluster0.oowmj.mongodb.net/SOSU2022?retryWrites=true&w=majority");
            var db = client.GetDatabase("SOSU2022");
            _caseOpenings = db.GetCollection<CaseOpeningDocument>("Sagsåbning");
        }
        
       

        public CaseOpening Create(CaseOpening caseOpening)
        {
            var documentToInsert = _converter.Convert(caseOpening);
            _caseOpenings.InsertOne(documentToInsert);
            var coToReturn = _converter.Convert(documentToInsert);
            return coToReturn;
        }
        public List<CaseOpening> GetAll()
        {
            var cos = new List<CaseOpening>();
            var documents = _caseOpenings.Find(co => true).ToList();
            foreach (var caseOpening in documents)
            {
                var co = _converter.Convert(caseOpening);
                cos.Add(co);
            }
            return cos;
        }
        
        public List<CaseOpening> GetByCitizen(string citizenId)
        {
            var documents = _caseOpenings
                .Find(co => co.BorgerId == citizenId).ToList();
            return documents.Select(caseOpening => _converter.Convert(caseOpening)).ToList();
        }

        public CaseOpening Update(string caseToUpdate, CaseOpening updatedCaseOpening)
        {
            var filter = Builders<CaseOpeningDocument>.Filter.Eq("_id", new ObjectId(caseToUpdate));
            var update = Builders<CaseOpeningDocument>.Update
                .Set("Henvisning", updatedCaseOpening.Reference)
                .Set("Fritekst", updatedCaseOpening.Summary);

            _caseOpenings.FindOneAndUpdate(filter, update);

            return updatedCaseOpening;
        }

        public CaseOpening Delete(string caseOpeningToDelete)
        {
            var document = _caseOpenings
                .Find(c => c._id.ToString() == caseOpeningToDelete)
                .FirstOrDefault();
            var deleteFilter = Builders<CaseOpeningDocument>.Filter.Eq("_id", new ObjectId(caseOpeningToDelete));
            _caseOpenings.DeleteOne(deleteFilter);

            return new CaseOpening
            {
                Id = document._id.ToString(),
                CitizenId = document.BorgerId,
                Reference = document.Henvisning,
                Summary = document.Fritekst,
            };
        }
    }
}