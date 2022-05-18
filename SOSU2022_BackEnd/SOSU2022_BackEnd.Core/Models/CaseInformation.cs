using MongoDB.Bson;

namespace SOSU2022_BackEnd.Core.Models
{
    public class CaseInformation
    {
        public ObjectId _id { get; set; }
        public ObjectId BorgerId { get; set; }
        public string Overemne { get; set; }
        public string Emne { get; set; }
    }
}