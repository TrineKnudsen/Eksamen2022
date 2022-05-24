using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BackEnd.Core.Test
{
    public class TestHelper
    {
        public Citizen SetCitizen(string id = "citizenId")
        {
            return new Citizen
            {
                Id = id
            };
        }
        
        public Citizen GetCitizen()
        {
            return new Citizen();
        }
    }
}