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
    public class GeneralInfoRepository : IGeneralInfoRepository
    {
        private readonly GeneralInformationConverter _converter;
        private readonly IMongoCollection<GeneralInformationDocument> _generals;
        
        public GeneralInfoRepository(ICitizenDatabaseSettings settings)
        {
            _converter = new GeneralInformationConverter();
            var client = new MongoClient("mongodb+srv://Eksamen2022:UUTu4zvESzEUcL9k@cluster0.oowmj.mongodb.net/SOSU2022?retryWrites=true&w=majority");
            var db = client.GetDatabase("SOSU2022");

            _generals = db.GetCollection<GeneralInformationDocument>("Generelle_oplysninger");
        }
        
        public List<GeneralInfo> GetByCitizen(string citizenId)
        {
            var documents = _generals
                .Find(general => general.BorgerId == citizenId).ToList();
            return documents.Select(generals => _converter.Convert(generals)).ToList();
        }

        public GeneralInfo UpdateGeneralInformation(GeneralInfo generalInfoToUpdate, GeneralInfo updatedGeneralInfo)
        {
            var docToUpdate = new GeneralInformationDocument
            {
                BorgerId = generalInfoToUpdate.CitizenId,
                Emne = generalInfoToUpdate.Subject,
                Tekst = generalInfoToUpdate.Text,
            };
            var filter = Builders<GeneralInformationDocument>.Filter.Eq("BorgerId", generalInfoToUpdate.CitizenId);
            var update = Builders<GeneralInformationDocument>.Update
                .Set(docToUpdate.Emne, updatedGeneralInfo.Subject);

            _generals.FindOneAndUpdate(filter, update);

            return updatedGeneralInfo;
        }
    }
}