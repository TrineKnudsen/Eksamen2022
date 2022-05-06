using MongoDB.Bson;

namespace SOSU2022_BackEnd.DTOs
{
    public class CitizenDto
    {
        public ObjectId Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        
        public string Telefon { get; set; }
    }
}