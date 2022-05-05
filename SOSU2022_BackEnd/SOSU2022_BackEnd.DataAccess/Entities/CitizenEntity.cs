using System;
using System.Collections.Generic;

namespace SOSU2022_BackEnd.DataAcces.Entities
{
    public class CitizenEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<CaseOpeningEntity> CaseOpenings { get; set; }
    }
}