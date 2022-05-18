using MongoDB.Bson;

namespace SOSU2022_BackEnd.Core.Models
{
    public class GeneralInfo
    {
        public ObjectId _id { get; set; }
        public ObjectId BorgerId { get; set; }
        public string Overemne { get; set; }
        public string Emne { get; set; }
        public string Tekst { get; set; }
        public string Hjaelp { get; set; }
    }
}