using Microsoft.EntityFrameworkCore;
using SOSU2022_BackEnd.DataAcces.Entities;

namespace SOSU2022_BackEnd.DataAcces
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options){}
        
        public virtual DbSet<CitizenEntity> Citizens { get; set; }
        public virtual DbSet<CaseOpeningEntity> CaseOpenings { get; set; }
    }
}