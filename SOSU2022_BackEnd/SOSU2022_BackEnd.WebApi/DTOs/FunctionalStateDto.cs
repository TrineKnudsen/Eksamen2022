using MongoDB.Bson;

namespace SOSU2022_BackEnd.DTOs
{
    public class FunctionalStateDto
    {
        public ObjectId Id { get; set; }
        public ObjectId BorgerId { get; set; }
        public string Overemne { get; set; }
        public string Emne { get; set; }
        public string Subreading { get; set; }
        public int NuværendeNiveau { get; set; }
        public int ForventetNiveau { get; set; }
        public string FaligNotat { get; set; }
        public string Udførelse { get; set; }
        public bool Betydning { get; set; }
        public string ØnskerMål { get; set; }
    }
}