using System.Collections.Generic;
using System.IO;
using System.Linq;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DataAcces.Entities;

namespace SOSU2022_BackEnd.DataAcces.Repositories
{
    public class CitizenRepository : ICitizenRepository
    {

        private readonly MainDbContext _ctx;

        public CitizenRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new InvalidDataException();
        }
        
        public List<Citizen> GetCitizens()
        {
            return _ctx.Citizens
                .Select(ce => new Citizen
                {
                    Id = ce.Id,
                    Name = ce.Name
                }).ToList();
        }

        public Citizen CreateCitizen(Citizen citizen)
        {
            var citizenEntity = new CitizenEntity
            {
                Name = citizen.Name,
            };

            _ctx.Citizens.Add(citizenEntity);
            _ctx.SaveChanges();

            return citizen;
        }
    }
}