using MongoDB.Bson;

namespace SOSU2022_BackEnd.DataAcces.Documents
{
    public class UserDocument
    {
        public ObjectId _id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}