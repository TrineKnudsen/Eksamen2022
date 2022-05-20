using MongoDB.Bson;

namespace SOSU2022_BackEnd.DataAcces.Documents
{
    public class CaseOpeningDocument
    {
        public ObjectId _id { get; set; }
        public string BorgerId { get; set; }
        public string Henvisning { get; set; }
        public string Fritekst { get; set; }
    }
}