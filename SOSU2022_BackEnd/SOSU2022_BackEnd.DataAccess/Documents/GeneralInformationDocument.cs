using MongoDB.Bson;

namespace SOSU2022_BackEnd.DataAcces.Documents
{
    public class GeneralInformationDocument
    {
        public ObjectId _id { get; set; }
        public string BorgerId { get; set; }
        public string Emne { get; set; }
        public string Tekst { get; set; }
    }
}