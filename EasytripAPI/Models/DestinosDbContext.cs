using Microsoft.EntityFrameworkCore;

namespace EasytripAPI.Models
{
    public class DestinosDbContext : DbContext
    {
        public DestinosDbContext(DbContextOptions<DestinosDbContext> options)
            : base(options) { }
        public DbSet<Destinos> Destinos { get; set; }
    }
}
