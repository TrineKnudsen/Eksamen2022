using MongoDB.Bson;

namespace SOSU2022_BackEnd.DTOs
{
    public class CaseOpeningDto
    {
        public ObjectId Id { get; set; }
        public ObjectId BorgerId { get; set; }
        public string Henvisning { get; set; }
        public string Fritekst { get; set; }
        
    }
}