using MongoDB.Bson;

namespace SOSU2022_BackEnd.DTOs
{
    public class GeneralInfoDto
    {
        public string Id { get; set; }
        public string CitizenId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}