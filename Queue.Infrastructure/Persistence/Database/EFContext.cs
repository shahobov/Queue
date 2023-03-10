using Microsoft.EntityFrameworkCore;
using Queue.Domain.Model;

namespace Queue.Infrastructure.Persistence.Database
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<EntityBase>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TableConfigurations.ProductTablesConfigurations).Assembly);
        }
    }
}
