using CustomerConnect.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CustomerConnect.Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
