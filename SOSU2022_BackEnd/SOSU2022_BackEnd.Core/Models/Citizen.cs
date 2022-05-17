using MongoDB.Bson;

namespace SOSU2022_BackEnd.Core.Models
{
    public class Citizen
    {
        public ObjectId _id { get; set; }
        public string Navn { get; set; }
        public int Alder { get; set; }
    }
}