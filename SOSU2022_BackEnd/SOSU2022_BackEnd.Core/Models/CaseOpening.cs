using MongoDB.Bson;

namespace SOSU2022_BacEnd.Domain.IRepositories
{
    public class CaseOpening
    {
        public ObjectId Id { get; set; }
        public ObjectId BorgerId { get; set; }
        public string Henvisning { get; set; }
        public string Fritekst { get; set; }
    }
}