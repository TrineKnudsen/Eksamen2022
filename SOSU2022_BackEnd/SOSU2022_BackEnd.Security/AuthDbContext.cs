using Microsoft.EntityFrameworkCore;
using SOSU2022_BackEnd.Security.Models;

namespace SOSU2022_BackEnd.Security
{
    public class AuthDbContext: DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        { }

        public DbSet<LoginUserEntity> LoginUsers { get; set; }
    }
}