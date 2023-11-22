using Microsoft.EntityFrameworkCore;
using OttoNetMVCServer.Models.DBEntities;

namespace OttoNetMVCServer.DAL
{
    public class OttoDbContext : DbContext
    {
        public OttoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Manufacturer> Manufacturer { get; set; }
    }
}
