using MongoDB.Bson;

namespace SOSU2022_BackEnd.Core.Models
{
    public class Citizen
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}