using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using web_24BM.Models;

namespace web_24BM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Persona> personas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}