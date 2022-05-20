using MongoDB.Bson;

namespace SOSU2022_BackEnd.DTOs
{
    public class CaseOpeningDto
    {
        public string Id { get; set; }
        public string CitizenId { get; set; }
        public string Summary { get; set; }
        public string Reference { get; set; }
    }
}