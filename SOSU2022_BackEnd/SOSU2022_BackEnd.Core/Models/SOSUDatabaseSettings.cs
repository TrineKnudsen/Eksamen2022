namespace SOSU2022_BackEnd.Core.Models
{
    public class SOSUDatabaseSettings : ICitizenDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CitizenCollectionName { get; set; }
    }

    public interface ICitizenDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CitizenCollectionName { get; set; }
    }
}