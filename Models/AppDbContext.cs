using Microsoft.EntityFrameworkCore;

namespace RestfulApiExample.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Advert> Adverts { get; set; }
    }
}
