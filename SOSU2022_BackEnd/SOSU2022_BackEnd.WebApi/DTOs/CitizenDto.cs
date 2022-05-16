using MongoDB.Bson;

namespace SOSU2022_BackEnd.DTOs
{
    public class CitizenDto
    {
        public ObjectId Id { get; set; }
        public string Navn { get; set; }
        public int Alder { get; set; }
    }
}