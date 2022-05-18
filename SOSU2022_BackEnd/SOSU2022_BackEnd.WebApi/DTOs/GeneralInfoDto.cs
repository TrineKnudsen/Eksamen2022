using MongoDB.Bson;

namespace SOSU2022_BackEnd.DTOs
{
    public class GeneralInfoDto
    {
        public ObjectId Id { get; set; }
        public ObjectId BorgerId { get; set; }
        public string Overemne { get; set; }
        public string Emne { get; set; }
        public string Tekst { get; set; }
        public string Hjaelp { get; set; }
    }
}