using Microsoft.EntityFrameworkCore;

namespace LocationFInder.Model
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Location> Location { get; set; }
    }
}
