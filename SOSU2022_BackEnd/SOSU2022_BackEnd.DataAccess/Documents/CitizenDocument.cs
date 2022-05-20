using MongoDB.Bson;

namespace SOSU2022_BackEnd.DataAcces.Documents
{
    public class CitizenDocument
    {
        public ObjectId _id { get; set; }
        public string Navn { get; set; }
        public int Alder { get; set; }
    }
}