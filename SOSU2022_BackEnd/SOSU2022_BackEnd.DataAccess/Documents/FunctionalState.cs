using MongoDB.Bson;

namespace SOSU2022_BackEnd.DataAcces.Documents
{
    public class FunctionalState
    {
        public ObjectId _id { get; set; }
        public string Id { get; set; }
        public string Emne { get; set; }
        public int Egenomsorg { get; set; }
        public int Kropspleje { get; set; }
    }
}