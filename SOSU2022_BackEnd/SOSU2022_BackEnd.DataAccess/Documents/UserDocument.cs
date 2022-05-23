using MongoDB.Bson;

namespace SOSU2022_BackEnd.DataAcces.Documents
{
    public class UserDocument
    {
        public ObjectId _id { get; set; }
        public string Brugernavn { get; set; }
        public string Adgangskode { get; set; }
        public string Rolle { get; set; }
    }
}