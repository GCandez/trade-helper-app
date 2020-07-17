using Microsoft.EntityFrameworkCore;
using tradehelperapi.Models;

namespace tradehelperapi
{
    public class DatabaseContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Shop> Shops { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
    }
}