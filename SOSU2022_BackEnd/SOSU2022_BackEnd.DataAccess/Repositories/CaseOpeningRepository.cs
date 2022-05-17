using System.Collections.Generic;
using MongoDB.Bson;
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
            var db = client.GetDatabase("SOSU2022");
            _caseOpenings = db.GetCollection<CaseOpening>("Sagsåbning");
        }

        public CaseOpening Create(CaseOpening caseOpening)
        {
            _caseOpenings.InsertOne(caseOpening);
            return caseOpening;
        }

        public List<CaseOpening> GetAll()
        {
            return _caseOpenings.Find(caseOpening => true).ToList();
        }

        public List<CaseOpening> GetByCitizen(string citizenId)
        {
            return _caseOpenings.Find(caseOpening => caseOpening.BorgerId == new ObjectId(citizenId)).ToList();
        }

        public CaseOpening Update(string caseToUpdate, CaseOpening updatedCaseOpening)
        {
            var filter = Builders<CaseOpening>.Filter.Eq("_id", new ObjectId(caseToUpdate));
            var update = Builders<CaseOpening>.Update
                .Set("Henvisning", updatedCaseOpening.Henvisning)
                .Set("Fritekst", updatedCaseOpening.Fritekst);

            _caseOpenings.FindOneAndUpdate(filter, update);

            return updatedCaseOpening;
        }

        public void Delete(string caseOpeningToDelete)
        {
            var deleteFilter = Builders<CaseOpening>.Filter.Eq("_id", new ObjectId(caseOpeningToDelete));
            _caseOpenings.DeleteMany(deleteFilter);
        }
    }
}