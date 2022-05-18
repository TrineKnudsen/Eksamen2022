using MongoDB.Bson;

namespace SOSU2022_BackEnd.Core.Models
{
    public class GeneralInfo : CaseInformation
    {
        public string Tekst { get; set; }
        public string Hjaelp { get; set; }
    }
}