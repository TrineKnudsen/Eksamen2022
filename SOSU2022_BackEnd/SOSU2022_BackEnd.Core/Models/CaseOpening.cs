using MongoDB.Bson;

namespace SOSU2022_BacEnd.Domain.IRepositories
{
    public class CaseOpening
    {
        public string Id { get; set; }
        public string CitizenId { get; set; }
        public string Reference { get; set; }
        public string Summary { get; set; }
    }
}