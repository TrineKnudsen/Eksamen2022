using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DataAcces.Documents;

namespace SOSU2022_BackEnd.DataAcces.Converters
{
    public class CitizenConverter
    {
        public Citizen Convert(CitizenDocument document)
        {
            return new Citizen
            {
                Id = document._id.ToString(),
                Age = document.Alder,
                Name = document.Navn
            };
        }

        public CitizenDocument Convert(Citizen citizen)
        {
            return new CitizenDocument
            {
                Alder = citizen.Age,
                Navn = citizen.Name,
            };
        }
    }
}