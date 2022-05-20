using MongoDB.Bson;

namespace SOSU2022_BackEnd.DTOs
{
    public class CitizenDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}