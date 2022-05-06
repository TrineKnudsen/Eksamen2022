using MongoDB.Bson;

namespace SOSU2022_BackEnd.Core.Models
{
    public class Citizen
    {
        public ObjectId Id { get; set; }
        public string Navn { get; set; }
        
        public string Adresse { get; set; }
        
        public string Telefon { get; set; }
    }
}