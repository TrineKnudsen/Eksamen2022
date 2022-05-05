namespace SOSU2022_BackEnd.DataAcces.Entities
{
    public class CaseOpeningEntity
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        public string Cause { get; set; }
        public string Contact { get; set; }
        public string Diagnosis { get; set; }
    }
}