using MongoDB.Bson;

namespace SOSU2022_BackEnd.DTOs
{
    public class CitizenDto
    {
        public string Id { get; set; }
        public string Navn { get; set; }
        public int Alder { get; set; }
    }
}